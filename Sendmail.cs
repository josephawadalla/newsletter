using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class mailbalk : System.Web.UI.Page
{
    public static string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection(ConnectionString);
    SqlConnection con2 = new SqlConnection(ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsnd_Click(object sender, EventArgs e)
    {

        int Mno = 0;
        string tomail = "";
        SqlCommand cmdExmno = new SqlCommand("Select ISNULL(max(id),0) AS Count From mails", con);
        SqlDataReader readerExmno = null;
        con.Open();
        readerExmno = cmdExmno.ExecuteReader();
        if (readerExmno.HasRows)
        {
            readerExmno.Read();
            Mno = Convert.ToInt32(readerExmno["Count"].ToString());
        }
        con.Close();
        for (int i = 216; i <= Mno; i++)
        {

            SqlCommand cmdmail = new SqlCommand("Select mail From mails where (id=@id)", con);
            cmdmail.Parameters.AddWithValue("@id", i);
            SqlDataReader readermail = null;
            con.Open();
            readermail = cmdmail.ExecuteReader();
            if (readermail.HasRows)
            {
                readermail.Read();
                tomail = readermail["mail"].ToString();
                txtmail.Text = tomail;
                try
                {
                    sendpassword(tomail);
                }
                catch
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Failure  (Failure) Values (@Failure) ", con2);

                    cmd.Parameters.AddWithValue("@Failure", tomail);

                    cmd.Connection = con2;
                    con2.Open();
                    cmd.ExecuteNonQuery();
                    con2.Close();
                }

            }
            con.Close();
            
        }

        //string tomail = "jasaad@smart-itbusiness.com";
        //sendpassword(tomail);


       
    }
    void sendpassword(string tomail)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.IsBodyHtml = true;
        mailMessage.To.Add(tomail);
        mailMessage.From = new MailAddress("j.bishara@smart-itbusiness.com", "Smart Business");
        mailMessage.Subject = "EGYSEC 2018 Invitation";

        mailMessage.Body = "<!DOCTYPE html> <html><head><title>Smart Business</title>";
        mailMessage.Body += @"<meta name=""viewport"" content=""width=device-width,initial-scale=1""/>";
        mailMessage.Body += @"</head>";
        mailMessage.Body += @"<body style=""font-family:Tahoma;color:black;""><div style=""width: 500px;border-bottom-style:solid;border-width:1px;border-color:gray;""><table style=""border:unset;border-color:transparent;table-layout: fixed;width: 500px;margin: auto;"">";
        mailMessage.Body += @"<tr><td colspan=""3"" align=""center""><img style=""margin:auto; width: 500px;"" src=""http://smart-itbusiness.com/mailimg/banner2.jpg""/></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><br/ ><h4 style=""font-family:Tahoma;color:balck;""> DON'T MISS THE UPCOMING EVENT </h4></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><h3 style=""font-family:Tahoma;color:#1d70b7;""> Egypt International Conference for Safety and the Sustainable Development</h3></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><br/ ><p style=""font-family:Tahoma;color:black;font-size:small;"">The EGYSEC organising committee will be working closely with the Cabinet of Ministers & the Ministry of Interior; leading the global organisations to put together a through overview of the Security, Safety, Health and Environmental Protection with Sustainable Development Concept not only in Egypt but also in GCC and beyond. </p></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><br/ ><h4 style=""font-family:Tahoma;color:#1d70b7"">Smart Business Invite you </h4></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><h5 style=""font-family:Tahoma;color:black;font-size:small;"">We are honored inviting you to visit Smart Business Suite </h5></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><p style=""font-family:Tahoma;color:black;font-size:small;"">We will be showing our latest Software Solutions and how it works with the hardware equipments to establish the maximum security environment for business and home residence </p></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><br/ ><p style=""font-family:Tahoma;color:black;font-size:small;""><strong>Address : </strong><a href= ""https://goo.gl/maps/gvW5jygarqJ2""> Al Manara International conference Center, New Cairo </a></p></td></tr>";
        mailMessage.Body += @"<tr><td colspan=""3""><p style=""font-family:Tahoma;color:black;font-size:small;""><strong>Date : </strong>8 - 10 MAY, 2018 <strong> Time : </strong>09:00 AM - 10:00 PM </p></td></tr>";
       
        mailMessage.Body += @"<tr><td align=""center""><a href=""http://smart-itbusiness.com/HRMS.aspx""><img width=""100px"" src=""http://smart-itbusiness.com/mailimg/b01.png"" /></a></td>
                            <td align= ""center""><a href=""http://smart-itbusiness.com/hardware.aspx""><img width =""100px"" src =""http://smart-itbusiness.com/mailimg/b02.png"" /></a></td>
                            <td align =""center"" ><a href=""http://smart-itbusiness.com/hardware.aspx""><img width = ""100px"" src = ""http://smart-itbusiness.com/mailimg/b03.png"" /></a></td></tr></table>";
        mailMessage.Body += @"<br/ > <table style=""background-color:#bdbdbd;width: 500px;border-color:#bdbdbd;""><tr style=""font-family:Tahoma;""><td colspan = ""3""><br /><strong style=""margin:5px;""> Contact US </strong></td></tr>";
        mailMessage.Body += @"<tr style=""font-family:Tahoma;""><td colspan =""2"">
                            <ul>
                            <li>Head Office : Villa 66 - 4th District , 5th Settellment , New Cairo, Egypt.</li>
                            <li>Heliopolis Branch : 3 Elshekh Mahmoud Abou El Eyon St. Ellnozha, Cairo, Egypt.</li>
                            <li> 26422152 - 01006047084 - 01202641967 </li>
                            </ul></td>
                            <td style = ""float: right;"">
                            <ul style = ""display: flex; list-style-type:none;font-family:Tahoma;color:#bdbdbd;"">
                            <li style = ""padding:5px;""><a href = ""mailto:Info@smart-itbusiness.com""><img height=""32"" width=""32"" src=""http://smart-itbusiness.com/mailimg/mail.png"" /></a></li>
                            <li style = ""padding:5px;""><a target = ""_blank"" href = ""https://www.facebook.com/smart.it.business""><img height=""32"" width=""32"" src=""http://smart-itbusiness.com/mailimg/facebook.png"" /></a></li></ul></td></tr>";
        mailMessage.Body += @"<tr  style=""font-family:Tahoma;""><td colspan=""3"" style=""text-align: center;"">you can <a href=""http://smart-itbusiness.com/ContactUs.aspx"">unsubscribe</a> here</td></tr></table></div></body></html>";



        mailMessage.Priority = MailPriority.Normal;

        SmtpClient smtpClient = new SmtpClient("mail.smart-itbusiness.com");
        smtpClient.Credentials = new NetworkCredential("j.bishara@smart-itbusiness.com", "SMART@smart33");
        smtpClient.Port = 587;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = false;
        smtpClient.Send(mailMessage);
    }
    
}
