using System;
using System.Collections.Generic;
using System.IO;

namespace WinFormsApp1
{
    public class Data
    {
        public string _name;
        public DateTime _dateOfBirth;
        public List<string> _options;
        public string _contactNumber;
        public string _email;

        public int progressBarValue = 0;
        public const string path = @"C:\test.txt";
    }
}