using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp3.UserControls
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            button1.Click += Button1OnClick;
            button2.Click += Button2OnClick;
        }

        private void Button2OnClick(object sender, EventArgs e) // Save
        {
            this.Close();
        }

        private void Button1OnClick(object sender, EventArgs e) // CLose
        {
            User user = new User();
            
            if (CheckForValues())
            {
                user.Name = textBox1.Text;
                user.LastName = textBox2.Text;
                user.Age = Convert.ToInt16(textBox3.Text);
                user.MobileNumber = textBox4.Text;
                user.ImagePath = textBox5.Text;
                
                (this.Owner as Form1).UserList.Add(user);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill boxes correctly!");
            }
        }

        private bool CheckForValues()
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z]+$") || textBox1.Text == String.Empty)
            {
                return false;
            }

            if (!Regex.IsMatch(textBox2.Text, @"^[a-zA-Z]+$") || textBox2.Text == String.Empty)
            {
                return false;
            }

            if (textBox3.Text == String.Empty || textBox3.Text.Contains("&")) // "&" symbol is used for serializing
            {
                return false;
            }

            if (textBox4.Text == String.Empty || textBox3.Text.Contains("&")) // "&" symbol is used for serializing
            {
                return false;
            }
            
            return true;
        }
        
    }
}