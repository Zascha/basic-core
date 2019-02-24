namespace WebApplication.Common
{
    public interface IEntity
    {
        int Id { get; set; }

        bool IsDefault();
    }
}
