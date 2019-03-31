namespace WebApplication.Data.Models
{
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public bool IsAdmin { get; set; }

        public override bool IsDefault
        {
            get
            {
                return string.IsNullOrEmpty(FirstName)
                       && string.IsNullOrEmpty(LastName)
                       && string.IsNullOrEmpty(Login);
            }
        }
    }
}
