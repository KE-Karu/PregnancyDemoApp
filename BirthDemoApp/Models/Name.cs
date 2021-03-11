namespace PregnancyDemoApp.Models
{
    public class Name : Dates
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

    }
}
