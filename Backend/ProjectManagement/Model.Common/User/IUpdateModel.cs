namespace Model.Common
{
    public interface IUpdateModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
