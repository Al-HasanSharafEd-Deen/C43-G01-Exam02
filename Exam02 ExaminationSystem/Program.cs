using System.Diagnostics;

namespace Exam02_ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject01 = new Subject(10, "C#");
            subject01.CreateExam();
            Console.Clear();
            Console.Write("Do U Wanna Start The Exam (Y | N): ");

            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && char.ToUpper(input[0]) == 'Y')
            {
                Stopwatch SW = new Stopwatch();
                SW.Start();
                subject01.SubjectExam?.ViewExam();
                Console.Clear();
                subject01.SubjectExam?.ViewResults();
                Console.WriteLine($"Time Elapsed: {SW.Elapsed}");
            }
        }
    }
}
