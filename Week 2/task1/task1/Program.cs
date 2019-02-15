class Program
{
    public static string ReverseString(string s)
    {
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }

    public static string ReverseStringDirect(string s)
    {
        char[] array = new char[s.Length];
        int forward = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            array[forward++] = s[i];
        }
        return new string(array);
    }

    static void Main()
    {
        int sum = 0;
        const int _max = 10000000;
        Console.WriteLine(ReverseString("test"));
        Console.WriteLine(ReverseStringDirect("test"));

        // Version 1: reverse with ToCharArray.
        var s1 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            sum += ReverseString("programmingisfun").Length;
        }
        s1.Stop();

        // Version 2: reverse with iteration.
        var s2 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            sum += ReverseStringDirect("programmingisfun").Length;
        }
        s2.Stop();

        Console.WriteLine(s1.Elapsed.TotalMilliseconds);
        Console.WriteLine(s2.Elapsed.TotalMilliseconds);
    }
}