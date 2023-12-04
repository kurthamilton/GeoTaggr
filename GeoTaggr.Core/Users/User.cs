namespace GeoTaggr.Core.Users
{
    public class User(int userId, string email)
    {
        public string Email { get; set; } = email;

        public int UserId { get; } = userId;
    }
}
