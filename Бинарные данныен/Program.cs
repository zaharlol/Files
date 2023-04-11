class Program
{
    public static void Main(string[] args)
    {
        string StringValue;
        string Q = @"D:/VS/SkillFactory/BinaryFile.bin";
        using (BinaryReader reader = new BinaryReader(File.Open(Q, FileMode.Open)))
        {
            StringValue = reader.ReadString();
        }
        Console.WriteLine("Строка: " + StringValue);
    }
}