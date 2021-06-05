namespace WinFormsApp3
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public short Age{ get; set; }
        public string MobileNumber { get; set; }
        public string ImagePath { get; set; }
        
        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }
}