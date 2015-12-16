using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.ComponentModel;
using System.Management;
using System.Management.Instrumentation;
using com.epson.pos.driver;
using System.Drawing;
using System.Drawing.Printing;
//using com.epson.pos.driver;


/// <summary>
/// Summary description for PrintReceipt
/// </summary>
public class PrintReceipt
{
    private StatusAPI m_objAPI = new StatusAPI();
    private string Queuno;
	public PrintReceipt()
	{
		
	}

    public void PrintQueuno(string _queuno)
    {
        Queuno = _queuno;
    }

    public void ReceiptPrint(object sender, EventArgs e)
    {
        Boolean isFinish;
        PrintDocument pdPrint = new PrintDocument();

        pdPrint.PrintController = new StandardPrintController();
        pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);

        // Change the printer to the indicated printer.
        pdPrint.PrinterSettings.PrinterName = "EPSON TM-T88IV Receipt";

        try
        {
            // Open a printer status monitor for the selected printer.
            if (m_objAPI.OpenMonPrinter(OpenType.TYPE_PRINTER, pdPrint.PrinterSettings.PrinterName) == ErrorCode.SUCCESS)
            {
                if (pdPrint.PrinterSettings.IsValid)
                {
                    // pdPrint.DocumentName = "Resceipt Printing";
                    // Start printing.
                    //pdPrint.d
                    pdPrint.Print();



                    // Check printing status.
                    isFinish = false;

                    // Perform the status check as long as the status is not ASB_PRINT_SUCCESS.
                    do
                    {
                        if (m_objAPI.Status.ToString().Contains(ASB.ASB_PRINT_SUCCESS.ToString()))
                            isFinish = true;

                    } while (!isFinish);
                    pdPrint.Dispose();
                    // Notify printing completion.
                    // MessageBox.Show("Printing complete.", "Program06", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                else
                    MessageBox.Show("Printer is not available.");

                // Always close the Status Monitor after using the Status API.
                if (m_objAPI.CloseMonPrinter() != ErrorCode.SUCCESS)
                    MessageBox.Show("Failed to close printer status monitor.");

            }
            else
                MessageBox.Show("Failed to open printer status monitor.");
        }
        catch
        {
            MessageBox.Show("Failed to open StatusAPI.");
            pdPrint.Dispose();
        }
    }
    private void pdPrint_PrintPage(object sender, PrintPageEventArgs e)
    {
        float x, y = 0, lineOffset;

        // Instantiate font objects used in printing.
        Font printFont = new Font("Microsoft Sans Serif", (float)10, FontStyle.Regular, GraphicsUnit.Point); // Substituted to FontA Font

        e.Graphics.PageUnit = GraphicsUnit.Point;
        lineOffset = printFont.GetHeight(e.Graphics) - (float)2.5; //3.5
        // Draw the bitmap

        x = 0;
        y = 14 + lineOffset; //24
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        e.Graphics.DrawString("QueuNO             : " + Queuno, printFont, Brushes.Black, x, y);
        y += lineOffset;
        y += lineOffset;
        y = y + lineOffset * (float)2;//5


        // Indicate that no more data to print, and the Print Document can now send the print data to the spooler.
        e.HasMorePages = false;
    }
}