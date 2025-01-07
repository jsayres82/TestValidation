using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using Nuvo.TestValidation.Limits.Validators;
using System;
using System.Linq;
using iText.IO.Image;
using Nuvo.TestValidation.TestOutputs;
using ScottPlot;

namespace Nuvo.TestValidation.TestResults
{
    public class TestReport
    {
        public string SerialNumber { get; set; } = "";
        public string PartDisposition { get; set; } = "";
        public string PartNumber { get; set; } = "";
        public string TestName { get; set; } = "";
        public string WaferName { get; set; } = "";
        public string ProgramName { get; set; } = "";

        [XmlElement("Result", typeof(TestResult<Dictionary<string, List<double[]>>>))]
        public List<object> Results { get; set; }

        public string TestFile { get; set; }

        public TestReport()
        {
            Results = new List<object>();
        }

        public TestReport(string serialNum, string partNum)
        {
            SerialNumber = serialNum;
            PartNumber = partNum;
            Results = new List<object>();
        }

        public TestReport(string serialNum, string testName, string waferName, string program, string partNum)
        {
            TestName = testName;
            WaferName = waferName;
            ProgramName = program;
            SerialNumber = serialNum;
            PartNumber = partNum;
            Results = new List<object>();
        }

        public void WriteToXml()
        {
            UpdatePassFail();
            XmlSerializer serializer = new XmlSerializer(typeof(TestReport), new[] { typeof(TestResult<int>), typeof(TestResult<string>) });

            using (TextWriter writer = new StreamWriter($"SN{SerialNumber}_Result.xml"))
            {
                serializer.Serialize(writer, this);
            }
        }

        public void WriteToXml(string filePath)
        {
            UpdatePassFail();
            XmlSerializer serializer = new XmlSerializer(typeof(TestReport), new[] { typeof(TestResult<int>), typeof(TestResult<string>) });

            using (TextWriter writer = new StreamWriter($"{filePath}\\SN{SerialNumber}_Result.xml"))
            {
                serializer.Serialize(writer, this);
            }
        }

        public void CreatePdfFromXml(string filePath)
        {
            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"{filePath}\\SN{SerialNumber}_Result.xml");

            // Create a new PDF document
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream($"{filePath}\\SN{SerialNumber}_Result.pdf", FileMode.OpenOrCreate));

            // Open the PDF document
            document.Open();

            // Create a table
            PdfPTable tableHeader1 = new PdfPTable(1); // Number of columns
            tableHeader1.WidthPercentage = 100;
            tableHeader1.SpacingBefore = 10f;
            tableHeader1.SpacingAfter = 10f;
            // Add image to the document
            var image = iTextSharp.text.Image.GetInstance(Path.Combine(System.IO.Directory.GetCurrentDirectory(),"Nuvotronic_Logo.jpg"));
            image.ScaleAbsolute(100,150);
            PdfPCell imageCell = new PdfPCell();
            imageCell.HorizontalAlignment = Element.ALIGN_TOP;
            imageCell.AddElement(image);
            imageCell.Border = PdfPCell.NO_BORDER; // Remove cell borders
            tableHeader1.AddCell(imageCell);

            document.Add(tableHeader1);

            // Create a table
            PdfPTable tableHeader = new PdfPTable(1); // Number of columns
            tableHeader.WidthPercentage = 100;
            tableHeader.SpacingBefore = 10f;
            tableHeader.SpacingAfter = 10f;

            // Create and format the header cells
            PdfPCell headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            Paragraph headerParagraph = new Paragraph();
            Paragraph headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Program:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{ProgramName}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);

            //headerCell1.BackgroundColor = BaseColor.LightGray;
            headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Unit Serial Number:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{SerialNumber}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);


            headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Description:", new Font(Font.TIMES_ROMAN,14,Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{TestName}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);

            headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Test Date:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{File.GetCreationTime(TestFile)}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);;
            tableHeader.AddCell(headerCell1);

            // Add the table to the document
            tableHeader.HorizontalAlignment = Element.ALIGN_LEFT;
            document.Add(tableHeader);

            // Create a table
            PdfPTable table = new PdfPTable(5); // Number of columns
            table.WidthPercentage = 100;
            table.SpacingBefore = 10f;
            table.SpacingAfter = 10f;
            // Add table headers
            PdfPCell cell = new PdfPCell(new Phrase("#", new Font(Font.NORMAL, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Requirement", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Value", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Limit", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Fail", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            // Extract data from XML and add to table
            XmlNodeList resultNodes = xmlDoc.SelectNodes("//Result");
            int rowNum = 1;
            foreach (XmlNode resultNode in resultNodes)
            {
                string requirementName = resultNode.SelectSingleNode("RequirementName")?.InnerText;
                bool passed = resultNode.SelectSingleNode("Passed")?.InnerText.ToLower() == "true";
                double minimumMargin = double.Parse(resultNode.SelectSingleNode("MinimumMargin")?.InnerText);
                XmlNode n = resultNode.SelectSingleNode("DomainLimit").FirstChild;
                string limitType = n.Name;
                string limitValue = n.FirstChild.InnerText;
                string units = "(";
                if (n.ChildNodes[2].InnerText != "None")
                    units += n.ChildNodes[2].InnerText;
                requirementName += $"{units}{n.ChildNodes[1].InnerText})";
                string symbol = LimitToSymbol(limitType, limitValue);
                string failed = (!passed) ? "X" : "";
                Font f = new Font(Font.TIMES_ROMAN, 10, Font.NORMAL);
                if (!passed)
                    f = new Font(Font.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.Red);
                cell = new PdfPCell(new Phrase((rowNum*10).ToString(), f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(requirementName, f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                string value = (minimumMargin + Convert.ToDouble(limitValue)).ToString("0.###");
                if (Math.Abs(minimumMargin + Convert.ToDouble(limitValue)) < 0.001)
                    value = (minimumMargin + Convert.ToDouble(limitValue)).ToString("0.####E+0");
                cell = new PdfPCell(new Phrase(value, f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(symbol));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(failed, f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                rowNum++;
            }
            table.SetWidths(new float[] { 1, 4, 2, 2, 2 });
            // Add the table to the document
            document.Add(table);
            var generator = new PdfGraphGenerator();
            var fInfo = new FileInfo(TestFile);
            
            try
            {
                var csvFiles = Directory.EnumerateFiles(filePath, "*.csv")
                    .Where(file => Path.GetFileName(file).Contains(SerialNumber, StringComparison.OrdinalIgnoreCase));

                foreach (var file in csvFiles)
                {
                    var graphTableHeader = new PdfPTable(1);
                    graphTableHeader.WidthPercentage = 100;
                    graphTableHeader.SpacingBefore = 10f;
                    graphTableHeader.SpacingAfter = 10f;
                    var name = file.Split("\\").Last();
                    var reqName = name.Split("_").Last();
                    reqName = reqName.Split(".").First();
                    // Create and format the header cells
                    PdfPCell headerCell = new PdfPCell();
                    headerCell.BorderWidth = 0;
                    Paragraph paragraph = new Paragraph(new Phrase($"{reqName}", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));

                    paragraph.SpacingAfter = 0;
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    headerCell.AddElement(paragraph);
                    //graphTableHeader.AddCell(headerCell);
                    var pltImgBytes = generator.CreateGraphPdf(file);
                    var pltImg = iTextSharp.text.Image.GetInstance(pltImgBytes);
                    PdfPCell imageCell2 = new PdfPCell();
                    imageCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.AddElement(pltImg);
                    imageCell2.Border = PdfPCell.NO_BORDER; // Remove cell borders
                    graphTableHeader.AddCell(headerCell);
                    document.Add(graphTableHeader);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access to the path '{fInfo.Directory.Name}' is denied. Error: {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory '{fInfo.Directory.Name}' was not found. Error: {e.Message}");
            }
            // Close the PDF document
            document.Close();
            writer.Close();
        }


        public void CreatePdfFromXml()
        {
            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load($"SN{SerialNumber}_Result.xml");

            // Create a new PDF document
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream($"SN{SerialNumber}_Result.pdf", FileMode.Create));

            // Open the PDF document
            document.Open();

            // Create a table
            PdfPTable tableHeader1 = new PdfPTable(1); // Number of columns
            tableHeader1.WidthPercentage = 100;
            tableHeader1.SpacingBefore = 10f;
            tableHeader1.SpacingAfter = 10f;
            // Add image to the document
            var image = iTextSharp.text.Image.GetInstance(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Nuvotronic_Logo.jpg"));
            image.ScaleAbsolute(100, 150);
            PdfPCell imageCell = new PdfPCell();
            imageCell.HorizontalAlignment = Element.ALIGN_TOP;
            imageCell.AddElement(image);
            imageCell.Border = PdfPCell.NO_BORDER; // Remove cell borders
            tableHeader1.AddCell(imageCell);

            document.Add(tableHeader1);

            // Create a table
            PdfPTable tableHeader = new PdfPTable(1); // Number of columns
            tableHeader.WidthPercentage = 100;
            tableHeader.SpacingBefore = 10f;
            tableHeader.SpacingAfter = 10f;

            // Create and format the header cells
            PdfPCell headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            Paragraph headerParagraph = new Paragraph();
            Paragraph headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Program:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{ProgramName}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);

            //headerCell1.BackgroundColor = BaseColor.LightGray;
            headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Unit Serial Number:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{SerialNumber}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);


            headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Description:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{TestName}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);

            headerCell1 = new PdfPCell();
            headerCell1.BorderWidth = 2f;
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Test Date:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{File.GetCreationTime(TestFile)}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2); ;
            tableHeader.AddCell(headerCell1);

            // Add the table to the document
            tableHeader.HorizontalAlignment = Element.ALIGN_LEFT;
            document.Add(tableHeader);

            // Create a table
            PdfPTable table = new PdfPTable(5); // Number of columns
            table.WidthPercentage = 100;
            table.SpacingBefore = 10f;
            table.SpacingAfter = 10f;
            // Add table headers
            PdfPCell cell = new PdfPCell(new Phrase("#", new Font(Font.NORMAL, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Requirement", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Value", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Limit", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Fail", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            // Extract data from XML and add to table
            XmlNodeList resultNodes = xmlDoc.SelectNodes("//Result");
            int rowNum = 1;
            foreach (XmlNode resultNode in resultNodes)
            {
                string requirementName = resultNode.SelectSingleNode("RequirementName")?.InnerText;
                bool passed = resultNode.SelectSingleNode("Passed")?.InnerText.ToLower() == "true";
                double minimumMargin = double.Parse(resultNode.SelectSingleNode("MinimumMargin")?.InnerText);
                XmlNode n = resultNode.SelectSingleNode("DomainLimit").FirstChild;
                string limitType = n.Name;
                string limitValue = n.FirstChild.InnerText;
                string units = "(";
                if (n.ChildNodes[2].InnerText != "None")
                    units += n.ChildNodes[2].InnerText;
                requirementName += $"{units}{n.ChildNodes[1].InnerText})";
                string symbol = LimitToSymbol(limitType, limitValue);
                string failed = (!passed) ? "X" : "";
                Font f = new Font(Font.TIMES_ROMAN, 10, Font.NORMAL);
                if (!passed)
                    f = new Font(Font.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.Red);
                cell = new PdfPCell(new Phrase((rowNum * 10).ToString(), f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(requirementName, f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                string value = (minimumMargin + Convert.ToDouble(limitValue)).ToString("0.###");
                if (Math.Abs(minimumMargin + Convert.ToDouble(limitValue)) < 0.001)
                    value = (minimumMargin + Convert.ToDouble(limitValue)).ToString("0.####E+0");
                cell = new PdfPCell(new Phrase(value, f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(symbol));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(failed, f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                rowNum++;
            }
            table.SetWidths(new float[] { 1, 4, 2, 2, 2 });
            // Add the table to the document
            document.Add(table);
            var generator = new PdfGraphGenerator();
            var fInfo = new FileInfo(TestFile);

            try
            {
                var csvFiles = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.csv")
                    .Where(file => Path.GetFileName(file).Contains(SerialNumber, StringComparison.OrdinalIgnoreCase));

                foreach (var file in csvFiles)
                {
                    var graphTableHeader = new PdfPTable(1);
                    graphTableHeader.WidthPercentage = 100;
                    graphTableHeader.SpacingBefore = 10f;
                    graphTableHeader.SpacingAfter = 10f;
                    var name = file.Split("\\").Last();
                    var reqName = name.Split("_").Last();
                    reqName = reqName.Split(".").First();
                    // Create and format the header cells
                    PdfPCell headerCell = new PdfPCell();
                    headerCell.BorderWidth = 0;
                    Paragraph paragraph = new Paragraph(new Phrase($"{reqName}", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));

                    paragraph.SpacingAfter = 0;
                    paragraph.Alignment = Element.ALIGN_CENTER;
                    headerCell.AddElement(paragraph);
                    //graphTableHeader.AddCell(headerCell);
                    var pltImgBytes = generator.CreateGraphPdf(file);
                    var pltImg = iTextSharp.text.Image.GetInstance(pltImgBytes);
                    PdfPCell imageCell2 = new PdfPCell();
                    imageCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                    headerCell.AddElement(pltImg);
                    imageCell2.Border = PdfPCell.NO_BORDER; // Remove cell borders
                    graphTableHeader.AddCell(headerCell);
                    document.Add(graphTableHeader);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access to the path '{fInfo.Directory.Name}' is denied. Error: {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory '{fInfo.Directory.Name}' was not found. Error: {e.Message}");
            }
            // Close the PDF document
            document.Close();
        }

        private string LimitToSymbol(string limit, string value)
        {
            switch(limit)
            {
                case "GreaterThanValidator":
                    return $"> {value}";
                    break;

                case "GreaterThanOrEqualValidator":
                    return $">= {value}";
                    break;
                case "LessThanValidator":
                    return $"< {value}";
                    break;

                case "LessThanOrEqualValidator":
                    return $"<= {value}";
                    break;
                case "EqualValidator":
                    return $"= {value}";
                    break;

                case "NotEqualValidator":
                    return $"!= {value}";
                    break;
                default:
                    return "";
                    break;

            }
        }
        public void UpdatePassFail()
        {
            bool fail = false; 
            foreach(TestResult<Dictionary<string, List<double[]>>> r in Results)
                if(!r.Passed)
                    fail = true;
            if (fail)
                PartDisposition = "Failed";
            else
                PartDisposition = "Passed"; 
        }

    }

}
