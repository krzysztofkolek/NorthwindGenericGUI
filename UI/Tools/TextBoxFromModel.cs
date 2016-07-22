namespace RAD_Project.UI.Tools
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class TextBoxFromModel<T> : GenericTool<T>, RAD_Project.UI.Tools.ITextBoxFromModel<T>
        where T : class, new()
    {
        private T _item { get; set; }
        private bool _isReadOnly { get; set; }

        public TextBoxFromModel()
        {
            SetReadOnly();
        }
        public TextBoxFromModel(T item)
        {
            _item = item;
            SetReadOnly();
        }

        public ITextBoxFromModel<T> SetItem(T item)
        {
            _item = item;
            return this as ITextBoxFromModel<T>;
        }

        private Dictionary<string, string> Get()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            foreach (var item in _filedsName)
            {
                ret.Add(item, item.SplitOnCapitals());
            }
            return ret;
        }

        public List<TextBox> GetTextBoxes()
        {
            List<TextBox> ret = new List<TextBox>();
            foreach (var item in Get())
            {
                ret.Add(new TextBox()
                {
                    Name = item.Key
                });
            }
            return ret;
        }

        public ITextBoxFromModel<T> SetReadOnly(bool isReadOnly)
        {
            _isReadOnly = isReadOnly;
            return this;
        }

        private void SetReadOnly()
        {
            _isReadOnly = true;
        }

        public GroupBox GetFormatedOutput()
        {
            GroupBox groupBox = new GroupBox()
            {
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            Panel panel = new Panel()
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            groupBox.Name = _name + "_group";
            groupBox.Text = _name.SplitOnCapitals();
            int top = 20;
            int incrementTop = 30;

            foreach (var item in Get())
            {
                Label lab = new Label()
                {
                    Name = item.Key + "_lbl",
                    Text = item.Value,
                    Location = new System.Drawing.Point(10, top),
                    Size = new System.Drawing.Size(60, 20),
                    Width = 100
                };

                object obj = "";
                obj = _item.GetType().GetProperty(item.Key).GetValue(_item, null);

                if (obj == null)
                {
                    obj = "";
                }

                TextBox textBox = new TextBox()
                {
                    Name = item.Key + "_txtBox",
                    Location = new System.Drawing.Point(110, top),
                    Size = new System.Drawing.Size(60, 400),
                    Width = 200,
                    Enabled = true,
                    Text = obj.ToString(),
                    ReadOnly = _isReadOnly
                };

                top += incrementTop;

                panel.Controls.Add(lab);
                panel.Controls.Add(textBox);
            }

            groupBox.Controls.Add(panel);
            return groupBox;
        }
    }
}
