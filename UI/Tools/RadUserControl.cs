namespace RAD_Project.UI.Tools
{
    using System;
    using System.Windows.Forms;

    public partial class RadUserControl<T> : UserControl
        where T : class, new()
    {
        //private UIDataContext<T> _context { get; set; }

        public RadUserControl()
            : base()
        {
            InitializeComponent();

            //if (!IsInDesignMode())
            //{
            //    //_context = new UIDataContext<T>();
            //}
        }

        public static bool IsInDesignMode()
        {
            if (Application.ExecutablePath.IndexOf("devenv.exe", StringComparison.OrdinalIgnoreCase) > -1)
            {
                return true;
            }
            return false;
        }
    }
}
