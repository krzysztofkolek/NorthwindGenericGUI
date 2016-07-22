namespace RAD_Project.UI.TelerikTools
{
    using RAD_Project.UI.Tools;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Telerik.Charting;
    using Telerik.WinControls.UI;

    public class GenericTeeChart<T> : GenericTool<T>
        where T : class, new()
    {
        private String _title { get; set; }
        private List<KeyValuePair<double, string>> _data { get; set; }
        private String _chartTitleAndLegend { get { return String.Format("{0} Analysis\n{1}", _name, _title); } }

        public GenericTeeChart<T> SetItem(List<KeyValuePair<double, string>> data)
        {
            _data = data;
            return this;
        }

        public GenericTeeChart<T> SetTitle(String title)
        {
            _title = title;
            return this;
        }

        public RadChartView GetFormatedOutput()
        {
            RadChartView ret = new RadChartView()
            {
                Dock = System.Windows.Forms.DockStyle.Fill
            };

            ret.AreaType = ChartAreaType.Pie;
            ret.ShowSmartLabels = true;
            ret.LabelFormatting += ret_LabelFormatting;
            ret.Title = _chartTitleAndLegend;
            ret.ShowTitle = true;
            ret.ChartElement.TitlePosition = TitlePosition.Top;
            ret.ChartElement.TitleElement.TextAlignment = ContentAlignment.MiddleCenter;

            ret.ShowToolTip = true;

            ret.LegendTitle = _chartTitleAndLegend;
            ret.ShowLegend = true;

            SmartLabelsController smartLabelController = new SmartLabelsController();
            smartLabelController.Strategy = new PieTwoLabelColumnsStrategy();
            ret.Controllers.Add(smartLabelController);

            PieSeries pie = new PieSeries();
            pie.LabelMode = PieLabelModes.Horizontal;
            pie.ShowLabels = true;
            pie.DrawLinesToLabels = true;
            pie.SyncLinesToLabelsColor = true;
            foreach (KeyValuePair<double, string> dataItem in _data)
            {
                PieDataPoint point = new PieDataPoint(dataItem.Key, dataItem.Value.ToString());
                point.Label = dataItem.Value.ToString();
                pie.DataPoints.Add(point);
            }
            ret.Series.Add(pie);

            ret.View.PerformRefresh(ret.View, false);

            return ret;
        }

        void ret_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
        {
            e.LabelElement.ResetValue(LabelElement.BorderColorProperty, Telerik.WinControls.ValueResetFlags.Local);
            e.LabelElement.ResetValue(LabelElement.BorderWidthProperty, Telerik.WinControls.ValueResetFlags.Local);
            e.LabelElement.ResetValue(LabelElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
        }
    }
}
