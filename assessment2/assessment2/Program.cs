public class Record
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Record(string name, int age)
    {
        Name = name;
        Age = age;
    }


}
public class Database
{
    public void Save(List<Record> records)
    {
        Console.WriteLine("Records saved to database.");
    }
}
public delegate void UploadCompletedHandler();

public class UploadService
{
    public event UploadCompletedHandler UploadCompleted;

    private Database _database;

    public UploadService(Database database)
    {
        _database = database;
    }

    public void Upload()
    {
        Console.WriteLine("Uploading CSV...");

        // Convert CSV data into records
        List<Record> records = new List<Record>
        {
            new Record("Sara", 20),
            new Record("Omar", 25),
            new Record("Ali", 30)
        };

        Console.WriteLine("Data converted into records.");

        // Save records
        _database.Save(records);

        // Raise Event
        UploadCompleted?.Invoke();
    }
}
public class NotificationService
{
    public void Notify()
    {
        Console.WriteLine("Upload completed! Notification sent.");
    }
}
internal class Program
{
    static void Main()
    {
        Database database = new Database();

        UploadService uploadService = new UploadService(database);

        NotificationService notificationService = new NotificationService();

        // Subscribe
        uploadService.UploadCompleted += notificationService.Notify;

        // Start upload
        uploadService.Upload();
    }
}