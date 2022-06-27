namespace WebApi.Models
{
    public class Users
    {
        public int id { get; set; }
        public int UserNo { get; set; }
        public string? UserName { get; set; }
        public string? UserLevel { get; set; }
        public string? Password { get; set; }
        public bool IsDelete { get; set; }

    }
}
