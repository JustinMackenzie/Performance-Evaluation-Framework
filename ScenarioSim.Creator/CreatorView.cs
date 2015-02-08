using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;

namespace ScenarioSim.Creator
{
    class CreatorView : GoView
    {

        public CreatorView() { }

        public bool CopiesSubtrees
        {
            get { return myCopiesSubtrees; }
            set { myCopiesSubtrees = value; }
        }

        // change the behavior of CopyToClipboard so that it may or
        // may not include all subtrees
        public override void CopyToClipboard(IGoCollection coll)
        {
            if (this.CopiesSubtrees && coll == this.Selection)
            {
                GoCollection newcoll = new GoCollection();
                foreach (GoObject obj in coll)
                {
                    newcoll.Add(obj);
                }
                TreeDraggingTool.AddSubtrees(newcoll);
                base.CopyToClipboard(newcoll);
            }
            else
            {
                base.CopyToClipboard(coll);
            }
        }

        private bool myCopiesSubtrees = true;
    }
}
