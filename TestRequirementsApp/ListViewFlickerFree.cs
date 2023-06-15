using System.Windows.Forms;

namespace Requirements_Builder
{
    class ListViewFlickerFree : ListView
    {
        public ListViewFlickerFree()
        {
            //Activate optimized double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
    }

    class TreeViewFlickerFree : TreeView
    {
        public TreeViewFlickerFree()
        {
            //Activate optimized double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)0x0014)
                m.Msg = 0x0;

            base.WndProc(ref m);
        }
    }
}
