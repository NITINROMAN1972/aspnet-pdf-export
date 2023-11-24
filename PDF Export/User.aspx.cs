using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class User : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void BindGrid()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select Name,Email,MobileNo,City,State from PDFExport";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            GrdUser.DataSource = dt;
            GrdUser.DataBind();
        }
    }

    protected void btnPDF_Click(object sender, EventArgs e)
    {
        try
        {
            // Create a PDF document
            Document pdfDoc = new Document(PageSize.A4, 50f, 50f, 30f, 30f);

            // Create a memory stream to write the PDF content
            MemoryStream memoryStream = new MemoryStream();

            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, memoryStream);
            pdfDoc.Open();

            // Create an HTMLWorker to parse HTML content
            HTMLWorker htmlWorker = new HTMLWorker(pdfDoc);

            // Create a StringWriter to write the GridView content as HTML
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            // Disable paging and bind the GridView
            GrdUser.AllowPaging = false;
            BindGrid();
            GrdUser.RenderControl(hw);

            // Parse the HTML content and add it to the PDF document
            StringReader sr = new StringReader(sw.ToString());
            htmlWorker.Parse(sr);

            pdfDoc.Close();

            // Clear the response
            Response.Clear();

            // Set the content type and headers for the PDF file
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            // Write the PDF content to the response output stream
            Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();

            Response.End();
        }
        catch (Exception ex)
        {

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        
    }
}