using DeAnThucTap;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Input message:");
        //string message = Console.ReadLine();
        //string result = MD5_Demo.Test(message);
        //Console.WriteLine("MD5: {0}", result);
        //result = SHA1_Demo.Test(message);
        //Console.WriteLine("SHA1: {0}", result);
        Read_file();

        Console.ReadLine();
    }

    private static void Check()
    {
        //if (File.Exists("C:\\random text folder\\Setting.txt"))
        if (File.Exists("Input.txt"))
        {
            Read_file();
        }
        else
        {
            Console.WriteLine("File Input khong ton tai");
        }
    }

    public static void Read_file()
    {
        FileStream fsi = File.OpenRead("Input.txt");
        FileStream fso = File.Create("Output.txt");
        StreamReader reader = new(fsi);
        StreamWriter writer = new(fso);
        string a;
        int count = 0;
        while(!reader.EndOfStream)
        {

            a = reader.ReadLine();
            Console.WriteLine("{0}. Input = {1}", count, a);
            writer.WriteLine("{0}. Input = {1}", count, a);
            string result = MD5_Demo.Test(a);
            Console.WriteLine("MD5: {0}", result);
            writer.WriteLine("MD5: {0}", result);
            result = SHA1_Demo.Test(a);
            Console.WriteLine("SHA1: {0}", result);
            writer.WriteLine("SHA1: {0}", result);
            count++;
        }
        reader.Close();
        fsi.Close();
        fso.Close();
    }
}