using System.Collections;
using Northwoods.Go;

namespace ScenarioSim.Creator
{
    class TreeDraggingTool : GoToolDragging
    {
        public TreeDraggingTool(GoView view)
            : base(view)
        {
            this.CopiesEffectiveSelection = true;  // in other words, copies subtrees
        }

        public bool MovesSubtrees
        {
            get { return myMovesSubtrees; }
            set { myMovesSubtrees = value; }
        }

        // produce a selection that includes all subtrees starting with the selected nodes
        public override GoSelection ComputeEffectiveSelection(IGoCollection sel, bool move)
        {
            GoSelection result = base.ComputeEffectiveSelection(sel, move);
            if ((move && this.MovesSubtrees) ||
                (!move && this.CopiesEffectiveSelection))
            {
                AddSubtrees(result);
            }
            return result;
        }

        // extend the collection by recursively adding all of the destination links and nodes
        // of all of the collection's nodes and links
        public static void AddSubtrees(IGoCollection sel)
        {
            Hashtable coll = new Hashtable();
            foreach (GoObject obj in sel)
            {
                AddReachable(coll, obj as IGoNode);
            }
            foreach (GoObject obj in coll.Keys)
            {
                sel.Add(obj);
            }
        }

        // recurse through graph
        private static void AddReachable(Hashtable coll, IGoNode inode)
        {
            if (inode == null) return;
            GoObject obj = inode.GoObject;
            if (!coll.ContainsKey(obj))
            {
                coll.Add(obj, obj);
                foreach (IGoLink ilink in inode.DestinationLinks)
                {
                    GoObject link = ilink.GoObject;
                    if (!coll.ContainsKey(link))
                        coll.Add(link, link);
                    AddReachable(coll, ilink.ToNode);
                }
            }
        }

        private bool myMovesSubtrees = true;
    }
}
