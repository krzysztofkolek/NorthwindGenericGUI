namespace RAD_Project.UI
{
    using DB_Repository;
    using Ninject;
    using RAD_Project.UI.Tools;
    using System;
    using Telerik.WinControls.UI;

    public partial class TextBoxFormFromModel<T> : RadForm
        where T : class, new()
    {
        private T _data { get; set; }
        private GenericRepository<T> _repository { get; set; }
        private TextBoxFromModel<T> _presenter { get; set; }

        public TextBoxFormFromModel(T dataitem)
        {
            InitializeComponent();
            _data = dataitem;
        }

        [Inject]
        public void SetRepository(GenericRepository<T> repository)
        {
            _repository = repository;
        }

        [Inject]
        public void SetPresenter(TextBoxFromModel<T> presenter)
        {
            _presenter = presenter;
        }

        public TextBoxFormFromModel<T> SetData(T dataitem)
        {
            _data = dataitem;
            return this;
        }

        public TextBoxFormFromModel<T> SetTitle(String title)
        {
            Text = title;
            return this;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            _repository.Edit(_data);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.content.Controls.Add(_presenter.SetItem(_data).GetFormatedOutput());
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            _repository.Delete(_data);
        }
    }
}
