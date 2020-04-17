
namespace Model.Common
{
    public interface IRegisterModel
    {
        string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
