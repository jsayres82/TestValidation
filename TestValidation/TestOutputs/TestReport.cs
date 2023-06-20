using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using Nuvo.TestValidation.Limits.Validators;
using System;

namespace Nuvo.TestValidation.TestResults
{
    public class TestReport
    {
        public string SerialNumber { get; set; }
        public string PartDisposition { get; set; }
        public string PartNumber { get; set; }

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

        public void WriteToXml()
        {
            UpdatePassFail();
            XmlSerializer serializer = new XmlSerializer(typeof(TestReport), new[] { typeof(TestResult<int>), typeof(TestResult<string>) });

            using (TextWriter writer = new StreamWriter($"SN{SerialNumber}_Result.xml"))
            {
                serializer.Serialize(writer, this);
            }
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
            Image image = iTextSharp.text.Image.GetInstance(@"C:\Users\214782\source\repos\TestValidation\TestRequirementsApp\bin\Debug\net5.0-windows\Nuvotronic_Logo.jpg");
            image.ScaleAbsolute(100,150);
            PdfPCell imageCell = new PdfPCell();
            imageCell.HorizontalAlignment = Element.ALIGN_TOP;
            imageCell.AddElement(image);
            tableHeader1.AddCell(imageCell);
            document.Add(tableHeader1);

            // Create a table
            PdfPTable tableHeader = new PdfPTable(1); // Number of columns
            tableHeader.WidthPercentage = 50;
            tableHeader.SpacingBefore = 10f;
            tableHeader.SpacingAfter = 10f;

            // Create and format the header cells
            PdfPCell headerCell1 = new PdfPCell();
            Paragraph headerParagraph = new Paragraph();
            Paragraph headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Program:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase("1180   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);

            //headerCell1.BackgroundColor = BaseColor.LightGray;
            headerCell1 = new PdfPCell();
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
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Description:", new Font(Font.TIMES_ROMAN,14,Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"Module RF Test   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
            headerParagraph2.SpacingAfter = 10f;
            headerCell1.AddElement(headerParagraph2);
            tableHeader.AddCell(headerCell1);

            headerCell1 = new PdfPCell();
            headerParagraph = new Paragraph();
            headerParagraph2 = new Paragraph();
            //headerParagraph.AddTabStops(new float[] { 100f, 200f, 300f }); // Set the tab stop positions

            headerParagraph.Add(new Phrase($"Test Date:", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            headerCell1.AddElement(headerParagraph);
            headerParagraph2.Add(new Phrase($"{File.GetCreationTime(TestFile)}   ", new Font(Font.TIMES_ROMAN, 14)));
            headerParagraph2.Alignment = Element.ALIGN_RIGHT;
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
            cell = new PdfPCell(new Phrase("Limit", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Value", new Font(Font.TIMES_ROMAN, 14, Font.BOLD)));
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
                string symbol = LimitToSymbol(limitType, limitValue);
                string failed = (!passed) ? "X" : "";
                Font f = new Font(Font.TIMES_ROMAN, 10, Font.NORMAL);
                if (!passed)
                    f = new Font(Font.TIMES_ROMAN, 10, Font.NORMAL, BaseColor.Red);
                cell = new PdfPCell(new Phrase(rowNum.ToString(), f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(requirementName, f));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(symbol));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase((minimumMargin + Convert.ToDouble(limitValue)).ToString("0.###E+0"), f));
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
