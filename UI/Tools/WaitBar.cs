
namespace RAD_Project.UI.Tools
{
    using System;
    using System.Threading.Tasks;
    using Telerik.WinControls.UI;

    public static class WaitBar
    {
        private static RadWaitingBar _bar { get; set; }

        static WaitBar()
        {
        }

        public static void SetWatingBar(RadWaitingBar bar)
        {
            _bar = bar;
            _bar.SendToBack();
        }

        public static async Task Wait(Action t)
        {
            _bar.BringToFront();
            _bar.StartWaiting();

            await Task.Factory.StartNew(() =>
            {
                t.Invoke();

            });

            _bar.StopWaiting();
            _bar.SendToBack();
        }
    }
}
