namespace DockerDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Started");

            Thread.Sleep(20000);

            Console.WriteLine("After wait");

            using var db = new AppDbContext();

            Console.WriteLine("Querying database");

            var students = db.Students.ToList();

            Console.WriteLine($"Students Found: {students.Count}");

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Id} - {student.Name} - {student.Program}");
            }
        }
    }
}
