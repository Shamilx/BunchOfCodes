using System;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        private Data data = null;
        
        public Form4(Data obj)
        {
            InitializeComponent();

            data = obj;
            progressBar1.Value = data.progressBarValue;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Data.path))
            {
                File.Create(Data.path);
            }
            
            using (StreamWriter writer = new StreamWriter(Data.path,true))
            {
                writer.WriteLine(textBox1.Text + "&" + textBox2.Text);

                string dataOptions = data._options[0] + "|" + data._options[1] + "|" + data._options[2];
                
                writer.WriteLine(data._name + "&" + dataOptions + "&" + data._email + "&" + data._contactNumber + 
                                 "&" + data._dateOfBirth);
            }

            progressBar1.Value = progressBar1.Maximum;
            
            // SendMessage();

            Application.Exit();
        }

        private void SendMessage()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("testEmail@gmail.com");
                mail.To.Add(data._email);
                mail.Subject = "Test Mail";
                mail.Body = "You have registered good job!";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("x", "x");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}