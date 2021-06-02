using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private Data data = null;
        
        public Form2(Data obj)
        {
            data = obj;
            InitializeComponent();
            progressBar2.Value = obj.progressBarValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data._options = new List<string>();
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
            {
                data._options.Add((string) comboBox1.SelectedItem);
                data._options.Add((string) comboBox2.SelectedItem);
                data._options.Add((string) comboBox3.SelectedItem);
                data.progressBarValue = data.progressBarValue + 25;
            }
            else
            {
                MessageBox.Show("Please fill all!","Error",MessageBoxButtons.OK);
                return;
            }
            
            this.Hide();
            Form3 form3 = new Form3(data);
            form3.Show();
        }
    }
}