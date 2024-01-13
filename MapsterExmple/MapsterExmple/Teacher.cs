using Mapster;

namespace MapsterExmple;
[AdaptTo("TeacherDto")]
public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}