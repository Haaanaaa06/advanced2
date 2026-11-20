public class Student
{

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

}
internal class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Sara", Age = 19, Grade = 85 },
            new Student { Id = 2, Name = "Omar", Age = 21, Grade = 55 },
            new Student { Id = 3, Name = "Ali", Age = 20, Grade = 92 },
            new Student { Id = 4, Name = "Mona", Age = 18, Grade = 70 },
            new Student { Id = 5, Name = "Youssef", Age = 22, Grade = 45 },
            new Student { Id = 6, Name = "Nour", Age = 19, Grade = 88 },
            new Student { Id = 7, Name = "Salma", Age = 23, Grade = 60 }
        };
        var highGrades = students.FindAll(s => s.Grade > 80);

        foreach (var student in highGrades)
        {
            Console.WriteLine($"{student.Name} - {student.Grade}");
        }
        var lowGrade = students.Find(s => s.Grade < 60);

        Console.WriteLine($"{lowGrade.Name} - {lowGrade.Grade}");
        int index = students.FindIndex(s => s.Name == "Sara");

        Console.WriteLine(index);
        bool allPassed = students.All(s => s.Grade >= 60);

        Console.WriteLine(allPassed);
        bool anyUnder20 = students.Any(s => s.Age < 20);

        Console.WriteLine(anyUnder20);
        int countHighGrades = students.Where(s => s.Grade > 80).Count();

        Console.WriteLine(countHighGrades);
        var orderedStudents = students.OrderBy(s => s.Age);

        foreach (var student in orderedStudents)
        {
            Console.WriteLine($"{student.Name} - {student.Age}");
        }
        var studentNames = students.Select(s => s.Name);

        foreach (var name in studentNames)
        {
            Console.WriteLine(name);
        }
        var student3 = students.Single(s => s.Id == 3);

        Console.WriteLine(student3.Name);
        var student10 = students.SingleOrDefault(s => s.Id == 10);

        if (student10 == null)
        {
            Console.WriteLine("Student not found");
        }
        else
        {
            Console.WriteLine(student10.Name);
        }
        var firstStudent = students.First();

        Console.WriteLine(firstStudent.Name);

        var firstStudent1 = students.FirstOrDefault(s => s.Grade < 60);
        Console.WriteLine("First student with Grade < 60:");
        Console.WriteLine(firstStudent?.Name ?? "Not Found");

        var highestGrade = students.Max(s => s.Grade);
        Console.WriteLine("Highest Grade: " + highestGrade);

        var lowestGrade = students.Min(s => s.Grade);
        Console.WriteLine("Lowest Grade: " + lowestGrade);

        var averageGrade = students.Average(s => s.Grade);
        Console.WriteLine("Average Grade: " + averageGrade);
        var skippedStudents = students.Skip(2);
        Console.WriteLine("Students after skipping first 2:");
        foreach (var s in skippedStudents)
        {
            Console.WriteLine(s.Name + " - " + s.Grade);
        }

        var firstThree = students.Take(3);
        Console.WriteLine("First 3 Students:");
        foreach (var s in firstThree)
        {
            Console.WriteLine(s.Name + " - " + s.Grade);
        }

        var lastStudent = students.Last();
        Console.WriteLine("Last Student:");
        Console.WriteLine(lastStudent.Name + " - " + lastStudent.Grade);

        var lastFailedStudent = students.LastOrDefault(s => s.Grade < 60);
        Console.WriteLine("Last student with Grade < 60:");
        Console.WriteLine(lastFailedStudent?.Name ?? "Not Found");
    }
}



