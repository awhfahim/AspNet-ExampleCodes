namespace StackOverflow.Domain.Entities;

public class Tag : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}