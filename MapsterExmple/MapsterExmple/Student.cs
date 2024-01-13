namespace MapsterExmple;

public class Student
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ParmanentAddress { get; set; }
    public DateTime DateOfBirth { get; set; }
    
    public Student[] Students { get; set; }
}