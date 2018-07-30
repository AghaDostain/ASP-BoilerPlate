namespace BoilerPlate.Common
{
    public interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
    }

    public class CurrentUser : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
