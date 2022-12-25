using DeAnThucTap;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Input message:");
        string message = Console.ReadLine();
        string result = MD5_Demo.Test(message);
        Console.WriteLine(result);
        result = SHA1_Demo.Test(message);
        Console.WriteLine(result);
    }
}