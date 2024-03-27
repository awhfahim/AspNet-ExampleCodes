namespace StackOverflow.Domain.Entities;

public class Question : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public int Votes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public uint AnswersCount { get; set; }
}