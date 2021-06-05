using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WinFormsApp3.UserControls;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public BindingList<User> UserList;
        public const string FILE_PATH = @"C:\Portal\test.txt";
        
        public Form1()
        {
            InitializeComponent();
            
            this.Closing += OnClosing;
            
            button1.Click += Button1OnClick;
            button2.Click += Button2OnClick;
            button3.Click += Button3OnClick;
            button4.Click += Button4OnClick;
            button5.Click += Button5OnClick;
            
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(FILE_PATH))
            {
                foreach (var i in UserList)
                {
                    writer.WriteLine(i.Name + "&" + i.LastName + "&" + i.Age + "&" + i.MobileNumber + "&" + i.ImagePath);
                }
            }
        }

        private BindingList<User> LoadUsers()
        {
            BindingList<User> users = new BindingList<User>();

            string line;

            try
            {
                using (StreamReader reader = new StreamReader(FILE_PATH))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] datas = line.Split('&');

                        users.Add(new User
                        {
                            Name = datas[0],
                            LastName = datas[1],
                            Age = Convert.ToInt16(datas[2]),
                            MobileNumber = datas[3],
                            ImagePath = datas[4]
                        });
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(@"C:\Portal\test.txt not found,program is going to create itself");
                Thread.Sleep(2000);

                if (!Directory.Exists(FILE_PATH))
                {
                    Directory.CreateDirectory(FILE_PATH.Substring(0, 9));
                }

                if (!File.Exists(FILE_PATH))
                {
                    File.Create(FILE_PATH).Dispose();
                }

                MessageBox.Show("File created");
            }
            

            return users;
        }

        private void Button5OnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button4OnClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                UserList.Remove(listBox1.SelectedItem as User);
            }
        }

        private void Button3OnClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                InfoForm infoForm = new InfoForm(listBox1.SelectedItem as User);
                infoForm.ShowDialog();
            }
        }

        private void Button2OnClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                EditForm editForm = new EditForm(listBox1.SelectedItem as User);
                editForm.ShowDialog();

                listBox1.DataSource = null;
                listBox1.DataSource = UserList;
            }
        }

        private void Button1OnClick(object sender, EventArgs e)
        {
            AddForm control = new AddForm();
            control.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserList = LoadUsers();
            listBox1.DataSource = UserList;
            listBox1.FormattingEnabled = false;
        }
    }
}