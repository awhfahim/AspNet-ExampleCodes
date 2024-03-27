namespace DelegateExample;

public static class Mock
{
    public static void SetUp<T>(Func<T,object> test) where T : class
    {
        var t = default(T);
        var s = test(t);
    }
}

public class Repo
{
    public int Age { get; set; }
    public string Demo { get; set; }
}