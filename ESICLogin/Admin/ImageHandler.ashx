<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public class ImageHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState {

    string ConnectionString;
    string Decryption;
    
    public void ProcessRequest (HttpContext context) 
    {
        SqlDataReader rdr = null;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();
            ConnectionString = Decryptdata(Decryption);
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand("select img_image from tbl_image_mst where img_id =" + context.Request.QueryString["imgID"],conn);
            conn.Open();
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                context.Response.ContentType = "image/JPEG";
                context.Response.BinaryWrite((byte[])rdr["img_image"]);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //if ((context.Session["ImageBytes"]) != null)
        //{
        //    byte[] image = (byte[])(context.Session["ImageBytes"]);
        //    context.Response.ContentType = "image/JPEG";
        //    context.Response.BinaryWrite(image);
        //}   
    }
    private string Decryptdata(string encryptpwd)
    {
        string decryptpwd = string.Empty;

        UTF8Encoding encodepwd = new UTF8Encoding();
        System.Text.Decoder utf8Decode = encodepwd.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
    }
    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}