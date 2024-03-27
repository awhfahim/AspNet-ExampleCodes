namespace StackOverflow.Domain.Entities;

public class Answer : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
    public string Body { get; set; }
    public bool IsAccepted { get; set; }
    public int Votes { get; set; }
    public DateTime AnsweredAt { get; set; }
    public DateTime? EditedAt { get; set; }
}