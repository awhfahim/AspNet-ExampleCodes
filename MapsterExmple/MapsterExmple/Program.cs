// See https://aka.ms/new-console-template for more information

using Mapster;
using MapsterExmple;
using MapsterMapper;

var id = Guid.NewGuid();

var config = TypeAdapterConfig.GlobalSettings;
config.NewConfig<(Student student, Guid id), StudentDTO>()
    .Map(dest => dest.IId, src => src.id)
    .Map(dest => dest.BothAddress, src => $"{src.student.Address} {src.student.ParmanentAddress}")
    .Map(d => d, s => s.student);

// TypeAdapterConfig<(Student student, Guid Trace_id), StudentDTO>.NewConfig()
//     .Map(dest => dest.Id, src => src.Trace_id)
//     .Map(dest => dest.BothAddress, src => $"{src.student.Address} {src.student.ParmanentAddress}")
//     .Map(d => d, s => s.student);

config.ForDestinationType<Validator>()
    .AfterMapping(d => d.Validate());

var student = new Student(){Name = "fahim", Address = "Nichu Colony", Id = 127, DateOfBirth = DateTime.Today, ParmanentAddress = "Saidpur"};

student.Students = new[]
{
    new Student() { Name = "f", Id = 1, Address = "b", DateOfBirth = DateTime.Today },
    new Student() { Name = "f", Id = 1, Address = "b", DateOfBirth = DateTime.Today },
    new Student() { Name = "f", Id = 1, Address = "b", DateOfBirth = DateTime.Today }
};

var s = student.Students;

StudentDTO stuDTO = (student, id).Adapt<StudentDTO>();

Console.WriteLine($"{stuDTO.Name} ,{stuDTO.BothAddress}, {stuDTO.DateOfBirth}, {stuDTO.IId}");

IMapper mapper = new Mapper();
var stuDto = mapper.Map<StudentDTO>(student);

Console.WriteLine($"{stuDto.Name} ,{stuDto.BothAddress}, {stuDto.DateOfBirth}, {stuDto.Id}");

var teacher = new Teacher();

public interface Validator
{
    void Validate()
    {
        Console.WriteLine("Validating...");
    }
}