namespace mvcPL.Models
{
    public class RegisterUserModel
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
    }
}