using SQLite;


namespace XamPctForms
{
    [Table("Users")]
    public class UserDTO
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
