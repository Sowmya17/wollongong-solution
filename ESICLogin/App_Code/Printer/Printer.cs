using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using System.IO;


/// <summary>
/// Summary description for Printer
/// </summary>
public class Printer
{
	static Dictionary<Page, Queue> pageTable = null;
    static Printer()
	{
        // Create the store
        pageTable = new Dictionary<Page, Queue>();
       
	}

    public static void Show(string str, string str1, string str2, string str3)
    {
        // Lets find out what page is sending the request
        Page page = HttpContext.Current.Handler as Page;
       
        // If a valid page is found
        if (page != null)
        {
            // Check if this page is requesing message show for the first time
            if (pageTable.ContainsKey(page) == false)
            {
                // Lets create a message queue dedicated for this page.
                pageTable.Add(page, new Queue());
            }

            // Let us add messages of this to the queue now
            pageTable[page].Enqueue(str);
            pageTable[page].Enqueue(str1);
            pageTable[page].Enqueue(str2);
            pageTable[page].Enqueue(str3);

            // Now let put a hook on the page unload where we will show our message
            page.Unload += new EventHandler(page_Unload);
        }

       
    }

    static void page_Unload(object sender, EventArgs e)
    {
        // Lets find out which page is getting unloaded
        Page page = sender as Page;

        // If a valid page is founf
        if (page != null)
        {
           

            // Extract the messages for this page and push them to client side
            // HttpContext.Current.Response.Write("<script>alert('" + pageTable[page].Dequeue() + "');</script>");

            //HttpContext.Current.Response.Write("<script type='text/javascript'>"
            //    + "var DocumentContainer = '" + pageTable[page].Dequeue() + "';"
            //    + "var DocumentContainer1 = '" + pageTable[page].Dequeue() + "';"
            //    + "var DocumentContainer2 = '" + DateTime.Now.ToString("dd-MM-yyyy") + "';"
            //    + "var DocumentContainer3 = '" + DateTime.Now.ToString("T") + "';"
            //    + "var DocumentContainer4 = '" + pageTable[page].Dequeue() + "';"
            //    + "var DocumentContainer5 = '" + pageTable[page].Dequeue() + "';"
            //    + "var WindowObject = window.open('', 'PrintWindow', 'width=1,height=1,top=1000,left=1000,toolbars=no,scrollbars=no,status=no,resizable=no');"
            //    // +"WindowObject.document.writeln(DocumentContainer);"
            //    // +"WindowObject.document.writeln(DocumentContainer1);"

            //    + "WindowObject.document.write('<html><head>');"
            //    + "WindowObject.document.write('</head><body><table><tr><td><h1>ESIC No</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer + '</h1></td></tr>');"
            //    + "WindowObject.document.write('<tr><td><h1>Queue No</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer1 + '</h1></td></tr>');"
            //    + "WindowObject.document.write('<tr><td><h1>Date</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer2 + '</h1></td></tr>');"
            //    + "WindowObject.document.write('<tr><td><h1>Time</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer3 + '</h1></td></tr>');"
            //    + "WindowObject.document.write('<tr><td><h1>Waiting Queue Status</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer4 + '</h1></td></tr>');"
            //    + "WindowObject.document.write('<tr><td><h1>Average Waiting Time</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer5 + '</h1></td></tr></table>');"
            //    + "WindowObject.document.write('</body></html>');"
            //    + "WindowObject.document.close();"
            //    + "WindowObject.focus();"
            //    + "WindowObject.print();"
            //    + "WindowObject.close();"
            //    + "</script>");
          
        }
    }
}

