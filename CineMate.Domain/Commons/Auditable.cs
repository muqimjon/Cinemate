namespace CineMate.Domain;

public abstract class Auditable
{
    public long Id { get; set; }
    public DateTime CreateAt { get; set; } =  new DateTimeOffset(DateTime.UtcNow).UtcDateTime;
    public DateTime? UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
}
