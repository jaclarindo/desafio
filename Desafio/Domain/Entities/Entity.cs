namespace Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public bool IsDeleted { get; protected set; }

    public void Create()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsDeleted = false;
    }

    public void ChangeRemoved(bool status)
    {
        IsDeleted = status;
    }
}
