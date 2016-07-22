

namespace RAD_Project.UI
{
    using System;
    using Telerik.WinControls.UI;

    public class CustomButton<T> : RadButton
        where T : class, new()
    {
        private Action<T> _clickedAction { get; set; }
        private T _data { get; set; }

        public CustomButton(T data, Action<T> action)
        {
            _data = data;
            _clickedAction = action;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _clickedAction(_data);
        }
    }
}
