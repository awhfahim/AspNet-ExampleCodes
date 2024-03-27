namespace StackOverflow.Domain.Entities;

public class Vote : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid AnswerId { get; set; }
    public VoteType VoteType { get; set; }
    public DateTime VotedAt { get; set; }
}

public enum VoteType
{
    UpVote = 1,
    DownVote = 2
}