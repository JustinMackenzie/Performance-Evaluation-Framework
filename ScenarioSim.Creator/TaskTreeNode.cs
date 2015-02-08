using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwoods.Go;
using System.Drawing;
using ScenarioSim.Core;

namespace ScenarioSim.Creator
{
    class TaskTreeNode : GoBasicNode, IGoCollapsible
    {
        public TreeNode<Task> Task { get; set; }

        public const int ChangedCollapsible = 1235;
        public const int ChangedExpanded = 1236;

        // change this from true to false if the tree goes in the opposite direction
        private static bool ChildrenAreDestinations = true;

        private bool myExpanded = true;
        private bool myCollapsible = true;

        private static Random myRandom = new Random();

        public TaskTreeNode(TreeNode<Task> task)
        {
            Task = task;
            this.Port.AddObserver(this);
            this.LabelSpot = GoObject.Middle;
            this.Editable = true;
            this.Text = task.Value.Name;
            this.Label.Editable = true;
            this.MiddleLabelMargin = new SizeF(30, 15);
            GoCollapsibleHandle h = new GoCollapsibleHandle();
            h.Position = this.Position;
            Add(h);
            UpdateHandle();
        }

        protected override GoShape CreateShape(GoPort p)
        {
            // create the bigger circle/ellipse around and behind the port
            GoShape e = new GoRectangle();
            e.FillEllipseGradient(Color.FromArgb(63 * myRandom.Next(5), 63 * myRandom.Next(5), 63 * myRandom.Next(5)), Color.White);
            e.BrushFocusScales = new SizeF(.2f, .2f);
            e.Size = new SizeF(30, 26);
            e.Selectable = false;
            e.Resizable = false;
            e.Reshapable = false;
            return e;
        }

        //Position the Collapsible Handle at the topleft of node.
        public override void LayoutChildren(GoObject childchanged)
        {
            base.LayoutChildren(childchanged);
            foreach (GoObject obj in this)
            {
                GoCollapsibleHandle h = obj as GoCollapsibleHandle;
                if (h != null)
                {
                    h.Position = this.Shape.Position;
                    break;
                }
            }
        }

        // the visibility of the handle depends on whether there are any child links/nodes
        // for this node
        // using the Observer mechanism is less efficient in space and time than putting
        // the code into a Port subclass, but is more convenient
        protected override void OnObservedChanged(GoObject observed, int subhint,
                                                  int oldI, Object oldVal, RectangleF oldRect,
                                                  int newI, Object newVal, RectangleF newRect)
        {
            base.OnObservedChanged(observed, subhint, oldI, oldVal, oldRect, newI, newVal, newRect);
            if (observed == this.Port &&
                (subhint == GoPort.ChangedAddedLink || subhint == GoPort.ChangedRemovedLink))
            {
                SetExpanded(!HasAnyChildrenUnseen());
                UpdateHandle();
            }
        }

        protected void UpdateHandle()
        {
            foreach (GoObject obj in this)
            {
                GoCollapsibleHandle h = obj as GoCollapsibleHandle;
                if (h != null)
                {
                    h.Visible = HasChildren();
                    h.Printable = h.Visible;
                    break;
                }
            }
        }

        public virtual bool HasChildren()
        {
            return this.Collapsible &&
                   (ChildrenAreDestinations ?
                    this.Port.DestinationLinksCount > 0 :
                    this.Port.SourceLinksCount > 0);
        }

        public virtual bool HasAnyChildrenUnseen()
        {
            if (!this.Collapsible)
                return false;
            bool unseen = false;
            foreach (IGoNode n in (ChildrenAreDestinations ? this.Destinations : this.Sources))
            {
                if (!n.GoObject.CanView())
                {
                    unseen = true;
                    break;
                }
            }
            return unseen;
        }

        /// <summary>
        /// Make all child links and nodes not Visible.
        /// </summary>
        /// <remarks>
        /// This calls <see cref="TreeDraggingTool.AddSubtrees"/>
        /// to determine what should be made not visible.
        /// </remarks>
        public virtual void Collapse()
        {
            if (!this.Collapsible) return;
            SetExpanded(false);
            GoCollection coll = new GoCollection();
            coll.Add(this);
            TreeDraggingTool.AddSubtrees(coll);
            foreach (GoObject obj in coll)
            {
                if (obj == this) continue;
                TaskTreeNode tn = obj as TaskTreeNode;
                if (tn != null)
                {
                    // make this child not visible
                    tn.Visible = false;
                    tn.Printable = false;
                    // also update the visibility of any links coming into TN
                    foreach (IGoLink inlink in tn.SourceLinks)
                    {
                        inlink.GoObject.Visible = false;
                        inlink.GoObject.Printable = false;
                    }
                }
            }
        }

        /// <summary>
        /// Make child links and nodes visible.
        /// </summary>
        /// <remarks>
        /// Edit the code to govern how many/which children should become visible.
        /// </remarks>
        public virtual void Expand()
        {
            if (!this.Collapsible) return;
            SetExpanded(true);
           
            foreach (GoObject obj in (ChildrenAreDestinations ? this.Destinations : this.Sources))
            {
                if (obj == this) continue;
                TaskTreeNode tn = obj as TaskTreeNode;
                if (tn != null)
                {
                    // make this child visible
                    tn.Visible = true;
                    tn.Printable = true;
                    // also update the visibility of any links coming into TN
                    foreach (IGoLink inlink in tn.SourceLinks)
                    {
                        inlink.GoObject.Visible = true;
                        inlink.GoObject.Printable = true;
                    }
                    // expand children, if they were expanded when collapsed
                    if (tn.IsExpanded)
                        tn.Expand();
                }
            }
        }

        /// <summary>
        /// If <see cref="HasAnyChildrenUnseen"/>, then <see cref="Expand"/>, else <see cref="Collapse"/>.
        /// </summary>
        public virtual void Toggle()
        {
            if (HasAnyChildrenUnseen())
                Expand();
            else
                Collapse();
        }

        /// <summary>
        /// Gets whether <see cref="Expand"/> has been called.
        /// </summary>
        public bool IsExpanded
        {
            get { return myExpanded; }
        }

        protected void SetExpanded(bool e)
        {
            bool old = myExpanded;
            if (old != e)
            {
                myExpanded = e;
                Changed(ChangedExpanded, 0, old, NullRect, 0, e, NullRect);
                UpdateHandle();
            }
        }

        /// <summary>
        /// Gets or sets disabling of the collapse/expand behavior.
        /// </summary>
        public virtual bool Collapsible
        {
            get { return myCollapsible; }
            set
            {
                bool old = myCollapsible;
                if (old != value)
                {
                    myCollapsible = value;
                    Changed(ChangedCollapsible, 0, old, NullRect, 0, value, NullRect);
                    UpdateHandle();
                }
            }
        }

        /// <summary>
        /// If the Port gets replaced, update our observer.
        /// </summary>
        public override GoPort Port
        {
            set
            {
                GoPort old = base.Port;
                if (old != null)
                    old.RemoveObserver(this);
                base.Port = value;
                if (value != null)
                    value.AddObserver(this);
            }
        }

        public override void ChangeValue(GoChangedEventArgs e, bool undo)
        {
            switch (e.SubHint)
            {
                case ChangedCollapsible:
                    this.Collapsible = (bool)e.GetValue(undo);
                    return;
                case ChangedExpanded:
                    SetExpanded((bool)e.GetValue(undo));
                    return;
                default:
                    base.ChangeValue(e, undo);
                    return;
            }
        }
    }
}
