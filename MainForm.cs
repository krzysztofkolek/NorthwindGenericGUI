namespace RAD_Project
{
    using DB_Model.DI;
    using Ninject;
    using RAD_Project.DecisionChain;
    using RAD_Project.DI;
    using RAD_Project.UI.Tools;
    using System;
    using Telerik.WinControls.UI;

    public partial class MainForm : RadForm
    {
        public MainForm()
        {
            InitializeComponent();
            WaitBar.SetWatingBar(this.radWaitingBar1);
            documentWindow1.Text = " ";
        }

        private void ActionManagement(object sender, bool insertSelectedRootAndElement, Action<String, String> action)
        {
            String rootMenuElement = ((Telerik.WinControls.UI.RadMenuItem)(((Telerik.WinControls.UI.RadMenuItemBase)(sender)).HierarchyParent)).AccessibleName;
            String selectedElement = ((Telerik.WinControls.UI.RadMenuItem)(sender)).AccessibleName;

            if (insertSelectedRootAndElement)
            {
                action(rootMenuElement, String.Format("{0}", selectedElement));
            }
            else
            {
                action(rootMenuElement, string.Empty);
            }

            documentWindow1.Text = String.Format("{0} -> {1}", rootMenuElement, selectedElement);
        }

        private void ActionCaller(String type, String methodName, String selectedElement = "")
        {
            IDBModel objType = null;
            if (ChainManager.Start(selectedElement))
            {
                objType = KernelDI.Kernel.Get<IDBModel>(selectedElement, new Ninject.Parameters.IParameter[] { });
            }
            else
            {
                objType = KernelDI.Kernel.Get<IDBModel>(type, new Ninject.Parameters.IParameter[] { });
            }
            var method = typeof(MainFormExtension).GetMethod(methodName);
            var methodToExecute = method.MakeGenericMethod(objType.GetType());
            methodToExecute.Invoke(this, new object[] { this });
        }

        private void ShowGrid(String type, String selectedElement = "")
        {
            ActionCaller(type, "GetData");
        }

        private void CreateNewObject(String type, String selectedElement = "")
        {
            ActionCaller(type, "CreateNewEntry");
        }

        private void Analize(String type, String selectedElement = "")
        {
            ActionCaller(type, "Analize", selectedElement);
        }

        private void displayGrid_radMenuItem_Click(object sender, System.EventArgs e)
        {
            ActionManagement(sender, false, ShowGrid);
        }

        private void createEntity_radMenuItem_Click(object sender, System.EventArgs e)
        {
            ActionManagement(sender, false, CreateNewObject);
        }

        private void analize_radMenuItem_Click(object sender, System.EventArgs e)
        {
            ActionManagement(sender, true, Analize);
        }

        private void applicationExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
