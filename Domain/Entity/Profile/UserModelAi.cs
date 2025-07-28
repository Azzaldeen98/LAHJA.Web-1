using Shared.Interfaces;

namespace Domain.Entity
{
    public partial class UserModelAi : ITDso {

        
        public int Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        
        public string UserId { get; set; }

       
        public User User { get; set; }

        
        public string ModelAiId { get; set; }

        public ModelAi ModelAi { get; set; }

    }
}
