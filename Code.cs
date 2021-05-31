using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
        class User
        {
            private string _username;
            private string _age;
            private string _gender;
            private string _favoriteFilm;
            private string _favoriteCar;
            private const string path = @"C:\Html\test.txt";

            public bool ShouldWrite = false;

            public User(string username,string age,string gender,string favoriteFilm,string favoriteCar)
            {
                _username = username;
                _age = age;
                _gender = gender;
                _favoriteCar = favoriteCar;
                _favoriteFilm = favoriteFilm;

                ShouldWrite = this.checkForValues();
            }

            private bool checkForValues()
            {
                if(_username == String.Empty)
                {
                    ShowMessage("Username cant be empty.");
                    return false;
                }

                if (_age == String.Empty)
                {
                    ShowMessage("Age cant be empty.");
                    return false;
                }

                if (!Regex.IsMatch(_age, @"^[+-]?\d*\.\d+$|^[+-]?\d+(\.\d*)?$"))
                {
                    ShowMessage("Age cant be string.");
                    return false;
                }

                if(_gender == String.Empty)
                {
                    ShowMessage("Gender cant be empty.");
                    return false;
                }

                
                if(_favoriteCar == String.Empty)
                {
                    ShowMessage("Favorite car cant be empty.");
                    return false;
                }

                if (_favoriteFilm == String.Empty)
                {
                    ShowMessage("Favorite film cant be empty.");
                    return false;
                }

                return true;
            }

            private void ShowMessage(string msg)
            {
                MessageBox.Show(msg);
            }

            public static void WriteToFile(User obj)
            {
                using(StreamWriter writer = new StreamWriter(path,true))
                {
                    string line = obj._username + "&" + obj._age + "&" + obj._gender 
                        + "&" + obj._favoriteFilm + "&" + obj._favoriteCar;

                    writer.WriteLine(line);
                }
            }
        }

        private User obj = null;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;

            button1.Click += button1_onClick;
            button2.Click += button2_onClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_onClick(object sender, EventArgs e)
        {
            obj = new User(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);

            if(obj.ShouldWrite == false)
            {
                obj = null;
                return;
            }

            button2.Enabled = true;
        }

        private void button2_onClick(object sender,EventArgs e)
        {
            if(obj != null)
            {
                User.WriteToFile(obj);
            }

            button2.Enabled = false;
        }
    }
}
