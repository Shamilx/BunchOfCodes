using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.UserControls
{
    public partial class InfoForm : Form
    {
        public InfoForm(User user)
        {
            InitializeComponent();

            label5.Text = user.Name;
            label6.Text = user.LastName;
            label7.Text = user.Age.ToString();
            label8.Text = user.MobileNumber;
            try
            {
                pictureBox1.Image = Image.FromFile(user.ImagePath);
            }
            catch (Exception e)
            {
                MessageBox.Show("Image not found");
                
            }

            if (user.ImagePath != String.Empty)
            {
                pictureBox1.Image = Image.FromFile(user.ImagePath);
            }
            
            button2.Click += Button2OnClick;
        }

        private void Button2OnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}