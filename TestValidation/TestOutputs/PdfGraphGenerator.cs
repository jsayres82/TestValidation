using System;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using ScottPlot;
using ScottPlot.Collections;//.Plottables;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Globalization;
using iText.IO;
using System.Reflection.Emit;
using ScottPlot.DataSources;
using MicrowaveNetworks.Matrices;
using ScottPlot.Statistics;
using iText.IO.Image;
using System.Collections.Generic;

namespace Nuvo.TestValidation.TestOutputs
{
    public class PdfGraphGenerator
    {
        /// <summary>
        /// Generates a PDF with a graph from CSV data.
        /// </summary>
        /// <param name="csvFilePath">Path to the CSV file.</param>
        /// <param name="pdfOutputPath">Path where the PDF will be saved.</param>
        public byte[] CreateGraphPdf(string csvFilePath)
        {
            // Read CSV data
            var csvRecords = ReadCsvData(csvFilePath);

            // Create plot
            var plt = new Plot();
            var xValues = csvRecords.Frequency;
            var y1Values = csvRecords.TestValue;
            var y2Values = csvRecords.Limit;
            //Coordinates[,] measured = new Coordinates[xValues.Length, y1Values.Length];
            var measuredValue = Coordinates.Zip(xValues, y1Values);
            var measuredLimit = Coordinates.Zip(xValues, y2Values);

            var scatterMeasured = new ScatterSourceCoordinatesArray(measuredValue);
            var scatterLimit = new ScatterSourceCoordinatesArray(measuredLimit);
            var pAdder = new PlottableAdder(plt);
            var m = pAdder.ScatterPoints<double, double>(xValues, y1Values, Color.FromColor(System.Drawing.Color.Blue));
            var l = pAdder.ScatterPoints<double, double>(xValues, y2Values, Color.FromColor(System.Drawing.Color.Black));

            var legend = new Legend(plt);

            // Render plot to PNG
            byte[] pngBytes = plt.GetImageBytes(600, 400);
            return pngBytes;

        }

        private static CsvData ReadCsvData(string path)
        {
            List<double> lstRange = new List<double>();
            List<double> lstValues = new List<double>();
            List<double> lstLimit = new List<double>();
            string[] rows = File.ReadAllLines(path);
            bool isFirst = true;
            foreach (string r in rows.Skip(1))
            {
                if(isFirst)
                    isFirst = false;
                else
                {
                    string[] cols = r.Split(',');
                    lstRange.Add(Convert.ToDouble(cols[0])/1e9);
                    lstValues.Add(Convert.ToDouble(cols[1]));
                    lstLimit.Add(Convert.ToDouble(cols[3]));
                    //you can add other columns to lists
                }
            }
            var data = new CsvData();
            data.Frequency = lstRange.ToArray();
            data.TestValue = lstValues.ToArray();
            data.Limit = lstLimit.ToArray();
            return data;
        }

        private class CsvData
        {
            public double[] Frequency { get; set; }
            public double[] TestValue { get; set; }
            public double[] Limit { get; set; }
        }
    }
}