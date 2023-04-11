using System.Runtime.Serialization.Formatters.Binary;

class Program
{
    static void Main(string[] args)
    {
        string StringValue;
        string Q = @"D:/VS/SkillFactory/BinaryFile.bin";

        using (BinaryWriter writer = new BinaryWriter(File.Open(Q, FileMode.Open)))
            writer.Write($"Дата: {DateTime.Now}, версия Windows {Environment.OSVersion}");

        using (BinaryReader reader = new BinaryReader(File.Open(Q, FileMode.Open)))
        {
            StringValue = reader.ReadString();
        }
        Console.WriteLine("Строка: " + StringValue);

        var contact = new Contact("Voi", 8900250, "mail");
        BinaryFormatter formatter = new BinaryFormatter();
        using (var fr = new FileStream("Fert.dat", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fr, contact);
        }
    }
}
[Serializable]
class Contact
{
    public string Name { get; set; }
    public long PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, long phoneNumber, string email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}