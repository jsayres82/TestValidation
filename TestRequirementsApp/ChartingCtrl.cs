using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

public partial class GraphUserControl : UserControl
{
    private Panel panel1;
    private PlotView plotView;

    public GraphUserControl()
    {
        InitializeComponent();

        plotView = new PlotView
        {
            Dock = DockStyle.Fill
        };

        Controls.Add(plotView);
    }

    public void UpdateGraph(string key, Dictionary<string, List<double>> data)
    {
        var plotModel = new PlotModel { Title = key };

        if (data.ContainsKey(key))
        {
            var series = new LineSeries
            {
                MarkerType = MarkerType.Circle
            };

            for (int i = 0; i < data[key].Count; i++)
            {
                series.Points.Add(new DataPoint(i, data[key][i]));
            }

            plotModel.Series.Add(series);
        }

        plotView.Model = plotModel;
    }

    private void InitializeComponent()
    {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 0;
            // 
            // GraphUserControl
            // 
            this.Controls.Add(this.panel1);
            this.Name = "GraphUserControl";
            this.ResumeLayout(false);

    }
}