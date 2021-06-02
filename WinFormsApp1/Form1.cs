using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Data data = new Data();
        
        public Form1()
        {
            InitializeComponent();
            
            
            progressBar1.Value = data.progressBarValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data._name = textBox1.Text;
            data._dateOfBirth = dateTimePicker1.Value;
            progressBar1.Value = data.progressBarValue;
            data.progressBarValue = data.progressBarValue + 25;
            
            this.Hide();
            Form2 obj = new Form2(data);
            obj.Show();
        }
    }
}