using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private Data data = null;
        
        public Form3(Data obj)
        {
            InitializeComponent();

            data = obj;
            progressBar2.Value = data.progressBarValue;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            data._contactNumber = textBox2.Text;
            data._email = textBox1.Text;

            data.progressBarValue = data.progressBarValue + 25;
            
            this.Hide();
            Form4 form4 = new Form4(data);
            
            form4.Show();
            
        }

    }
}