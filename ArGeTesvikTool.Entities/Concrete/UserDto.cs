using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class UserDto : IEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //public string Verified { get; set; }

        //public string Role { get; set; }

        //public string Status { get; set; }
    }
}
