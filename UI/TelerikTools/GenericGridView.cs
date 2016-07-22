namespace RAD_Project.UI.TelerikTools
{
    using DB_Repository;
    using Ninject;
    using RAD_Project.DI;
    using RAD_Project.UI.Tools;
    using System;
    using System.Collections.Generic;
    using Telerik.WinControls.UI;

    public class GenericGridView<T> : GenericTool<T>
        where T : class, new()
    {
        private List<T> _data { get; set; }
        private GenericRepository<T> _repository { get; set; }

        public GenericGridView()
        {
            _repository = KernelDI.Kernel.Get<GenericRepository<T>>();
        }
        public GenericGridView(List<T> data)
        {
            _data = data;
        }

        public GenericGridView<T> SetData(List<T> data)
        {
            _data = data;
            return this;
        }

        public async void ShowFormForRowEdit(int id)
        {
            T selectedItem = await _repository.Details(id);
            KernelDI.Kernel.Get<TextBoxFormFromModel<T>>().SetTitle(_name).SetData(selectedItem).Show();
        }

        public async void ShowFormForRowEdit(String id)
        {
            T selectedItem = await _repository.Details(id);
            KernelDI.Kernel.Get<TextBoxFormFromModel<T>>().SetTitle(_name).SetData(selectedItem).Show();
        }


        public RadGridView Get()
        {
            RadGridView ret = new RadGridView()
            {
                AllowEditRow = false
            };

            foreach (var column in _filedsName)
            {
                ret.Columns.Add(column, column.SplitOnCapitals());
            }
            foreach (var dataEntry in _data)
            {
                int j = 0;
                var row = ret.Rows.AddNew();
                foreach (var fieldName in _filedsName)
                {
                    var value = dataEntry.GetType().GetProperty(fieldName).GetAccessors()[0].Invoke(dataEntry, new object[] { });
                    row.Cells[j++].Value = value;
                }
            }
            ret.Dock = System.Windows.Forms.DockStyle.Fill;
            ret.BestFitColumns();
            ret.MouseDoubleClick += ret_MouseDoubleClick;
            return ret;
        }

        void ret_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            String colNameForId = _repository.GetIDPropertyName();
            object cellValue = (sender as Telerik.WinControls.UI.RadGridView).SelectedRows[0].Cells[colNameForId].Value;
            if (cellValue != null)
            {
                int id = 0;
                if (int.TryParse(cellValue.ToString(), out id))
                {
                    ShowFormForRowEdit(id);
                }
                else
                {
                    ShowFormForRowEdit(cellValue.ToString());
                }
            }
        }
    }
}
