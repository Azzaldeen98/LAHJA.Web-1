using Shared.Interfaces;

namespace Domain.Entity
{


    public partial class UserService : ITDso {


        public int Id { get; set; }

        
        public DateTimeOffset CreatedAt { get; set; }

        
        public string UserId { get; set; }

        
        public User User { get; set; }

        
        public string ServiceId { get; set; }

        
        public Service Service { get; set; }

    }
}
