namespace RestfullDemo.Models
{
    public class LoginResponseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string UserToken { get; set; }
    }
}
