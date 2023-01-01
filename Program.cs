using DeAnThucTap;

internal class Program
{
    private static void Main(string[] args)
    {
        FileReader.HashInputFile();
        Console.WriteLine("Input message:");
        string message = Console.ReadLine();
        string result = MD5_Demo.Hash_MD5(message);
        Console.WriteLine("MD5: {0}", result);
        result = SHA1_Demo.Hash_SHA1(message);
        Console.WriteLine("SHA1: {0}", result);
        //CheckInputFile();

        Console.ReadLine();
    }
}