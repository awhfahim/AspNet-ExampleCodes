namespace MapsterExmple;

public class StudentDTO : Validator
{
    public int  Id { get; set; }
    public Guid  IId { get; set; }
    public string Name { get; set; }
    public string BothAddress { get; set; }
    public DateTime DateOfBirth { get; set; }
}