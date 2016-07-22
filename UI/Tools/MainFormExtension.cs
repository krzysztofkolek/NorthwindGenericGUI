
namespace RAD_Project.UI.Tools
{
    using DB_Repository;
    using Ninject;
    using RAD_Project.ChartAlgorithm;
    using RAD_Project.DI;
    using RAD_Project.UI.TelerikTools;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Telerik.WinControls.UI;

    public static class MainFormExtension
    {
        public static async void GetData<T>(this MainForm form)
            where T : class, new()
        {
            form.documentWindow1.Controls.Clear();

            RadGridView grid = null;
            await WaitBar.Wait(new Action(() =>
            {
                var data = KernelDI.Kernel.Get<GenericRepository<T>>().Index().Result.ToList();
                grid = KernelDI.Kernel.Get<GenericGridView<T>>().SetData(data).Get();

            }));
            form.radDock1.BringToFront();
            form.documentWindow1.BringToFront();

            form.radDock1.Show();
            form.documentWindow1.Show();

            form.documentWindow1.Controls.Clear();
            form.documentWindow1.Controls.Add(grid);
        }

        public static async void CreateNewEntry<T>(this MainForm form)
            where T : class, new()
        {
            form.documentWindow1.Controls.Clear();

            GroupBox box = null;
            await WaitBar.Wait(new Action(() =>
            {
                box = KernelDI.Kernel.Get<TextBoxFromModel<T>>()
                                        .SetItem(new T())
                                        .SetReadOnly(false)
                                        .GetFormatedOutput();

            }));

            T data = new T();
            Action<T> action = new Action<T>((_) =>
            {
                KernelDI.Kernel.Get<GenericRepository<T>>().Create(_);
            });

            box.Controls.Add(new Label()
            {
                Dock = DockStyle.Top,
                Text = "Leave th ID field blank"

            });

            box.Controls.Add(new CustomButton<T>(data, action)
            {
                Dock = DockStyle.Bottom,
                Text = "Save"
            });

            form.radDock1.BringToFront();
            form.documentWindow1.BringToFront();

            form.radDock1.Show();
            form.documentWindow1.Show();

            form.documentWindow1.Controls.Clear();
            form.documentWindow1.Controls.Add(box);
        }

        public static async void Analize<T>(this MainForm form)
            where T : class, new()
        {
            form.documentWindow1.Controls.Clear();

            RadChartView chart = null;
            await WaitBar.Wait(new Action(() =>
            {
                var data = KernelDI.Kernel.Get<GenericRepository<T>>().Index().Result;
                var retrivedData = data.ToList();

                var algorithm = KernelDI.Kernel.Get<IAlgorithm<T>>();
                var algorithmResult = algorithm.SetData(retrivedData).GetResult().Result;

                chart = KernelDI.Kernel.Get<GenericTeeChart<T>>()
                                        .SetTitle(algorithm.GetAlgorithmTitle())
                                        .SetItem(algorithmResult)
                                        .GetFormatedOutput();

            }));

            form.radDock1.BringToFront();
            form.documentWindow1.BringToFront();

            form.radDock1.Show();
            form.documentWindow1.Show();

            form.documentWindow1.Controls.Clear();
            form.documentWindow1.Controls.Add(chart);
        }
    }
}
