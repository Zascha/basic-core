namespace WebApplication.Common
{
    public interface IEntity
    {
        int Id { get; set; }

        bool IsNew { get; }

        bool IsDefault { get; }
    }
}
