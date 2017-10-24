using EEAFormI9Portal.EF;
using EEAFormI9Portal.Factory.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace EEAFormI9Portal.Factory.IServicesImplementation
{
    public class EmailManagement : IEmailManagement
    {
        private readonly EEAFORMI9Entities db = new EEAFORMI9Entities();
        public bool SendEmail(string sendToMail)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.To.Add(sendToMail);
                mail.From = new MailAddress("pavankumar091908@gmail.com");
                mail.Subject = "Email using Gmail";
                string Body = "Please click on the link for instructions, http://localhost:50132/Employee/Index ";
                mail.Body = Body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("meanstacklearner@gmail.com", "myfreedom");

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;

                smtp.Send(mail);

                return true;

            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public bool SendEmailPassword(string sendToEmail)
        {
            try
            {
                string password = generatePassword();
                if (password != null)
                {
                    var user = db.AspNetUsers.SingleOrDefault(x => x.Email == sendToEmail);
                    if (user != null)
                    {
                        user.TempCode = password;
                        db.SaveChanges();
                    }
                    
                    MailMessage mail = new MailMessage();

                    mail.To.Add(sendToEmail);
                    mail.From = new MailAddress("pavankumar091908@gmail.com");
                    mail.Subject = "Email using Gmail";
                    string Body = "Temporary Password : " + password + " \n" +
                        "Please click on the link to change password, http://localhost:50132/Employee/ChangePassword ";

                    mail.Body = Body;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("meanstacklearner@gmail.com", "myfreedom");

                    //Or your Smtp Email ID and Password
                    smtp.EnableSsl = true;

                    smtp.Send(mail);

                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string generatePassword()
        {
            try
            {
                string password = Membership.GeneratePassword(10, 1);

                return password;
            }
            catch(Exception ex)
            {
                return null;
            }
            

        }
        


    }
}
