/// <summary>
/// Model for Users table
/// </summary>
namespace Camomile
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
    }
}
