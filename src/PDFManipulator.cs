using System;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace FakturaMaker.src
{
    public static class PDFManipulator
    {
        public static void CreateAndWrite(Bill bill, string path)
        {
            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            Paragraph header = new Paragraph("Invoice")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(24)
                .SetBold();
            document.Add(header);

            Paragraph senderInfo = new Paragraph("Sender: " + bill.Sender.Name)
                .SetFontSize(12);
            document.Add(senderInfo);

            Paragraph receiverInfo = new Paragraph("Receiver: " + bill.Receiver.Name)
                .SetFontSize(12);
            document.Add(receiverInfo);

            Paragraph issueDate = new Paragraph("Date of Issue: " + bill.DateOfIssue)
                .SetFontSize(12);
            document.Add(issueDate);

            Paragraph dueDateInfo = new Paragraph("Due Date: " + bill.DueDate)
                .SetFontSize(12)
                .SetMarginBottom(20);
            document.Add(dueDateInfo);

            Table itemsTable = new Table(3)
                .UseAllAvailableWidth()
                .SetFontSize(12)
                .SetMarginBottom(20);

            itemsTable.AddHeaderCell("Item");
            itemsTable.AddHeaderCell("Unit Price");
            itemsTable.AddHeaderCell("Quantity");

            foreach (Item item in bill.Items)
            {
                itemsTable.AddCell(item.Name);
                itemsTable.AddCell("$100.00");
                itemsTable.AddCell("2");
            }

            document.Add(itemsTable);

            Paragraph totalAmount = new Paragraph("Total Amount: " + bill.Total)
                .SetBold()
                .SetFontSize(16);
            document.Add(totalAmount);

            document.Close();
        }
    }
}
