using JsonFormat;
using System.Collections.Specialized;
using System.Text.Json;

Course course = new();
var Jsonstring = JsonFormatter.ToJson<Course>(course);