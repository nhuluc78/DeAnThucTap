using DeAnThucTap;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Input message:");
        string message = Console.ReadLine();
        string result = MD5_Demo.Hash_MD5(message);
        Console.WriteLine("MD5: {0}", result);
        result = SHA1_Demo.Hash_SHA1(message);
        Console.WriteLine("SHA1: {0}", result);
        //CheckInputFile();

        Console.ReadLine();
    }

    private static void CheckInputFile()
    {
        //if (File.Exists("C:\\random text folder\\Setting.txt"))
        if (File.Exists("Input.txt"))
        {
            HashInputFile();
        }
        else
        {
            Console.WriteLine("File Input khong ton tai");
        }
    }

    public static void HashInputFile()
    {
        FileStream fsi = File.OpenRead("Input.txt");
        FileStream fso = File.Create("Output.txt");
        StreamReader reader = new(fsi);
        StreamWriter writer = new(fso);
        string salt, message, salted_message;
        int count = 0;
        while(!reader.EndOfStream)
        {

            message = reader.ReadLine();
            salt = reader.ReadLine();
            salted_message = message + salt;
            Console.WriteLine("{0}. Input = \"{1}\"", count, message);
            writer.WriteLine("{0}. Input = \"{1}\"", count, message);
            string result = MD5_Demo.Hash_MD5(message);
            Console.WriteLine("MD5 (Unsalted): {0}", result);
            writer.WriteLine("MD5 (Unsalted): {0}", result);
            result = SHA1_Demo.Hash_SHA1(message);
            Console.WriteLine("SHA1 (Unsalted): {0}", result);
            writer.WriteLine("SHA1 (Unsalted): {0}", result);
            Console.WriteLine("Salt = \"{0}\", Salted message = \"{1}\"", salt, salted_message);
            writer.WriteLine("Salt= \"{0}\", Salted message = \"{1}\"", salt, salted_message);
            result = MD5_Demo.Hash_MD5(salted_message);
            Console.WriteLine("MD5 (Salted): {0}", result);
            writer.WriteLine("MD5 (Salted): {0}", result);
            result = SHA1_Demo.Hash_SHA1(salted_message);
            Console.WriteLine("SHA1 (Salted): {0}", result);
            writer.WriteLine("SHA1 (Salted): {0}", result);
            count++;
        }
        reader.Close();
        fsi.Close();
        fso.Close();
    }
}