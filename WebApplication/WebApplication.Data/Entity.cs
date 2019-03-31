using WebApplication.Common;

namespace WebApplication.Data.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }

        public bool IsNew
        {
            get { return Id == 0; }
        }

        public abstract bool IsDefault { get; }
    }
}
