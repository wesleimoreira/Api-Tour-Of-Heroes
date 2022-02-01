namespace Api_Tour_Of_Heroes_Domain.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }

        public string Password { get; set; }    

        public string Role { get; set; }
    }
}
