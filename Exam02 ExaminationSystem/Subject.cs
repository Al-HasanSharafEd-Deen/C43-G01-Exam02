using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    public class Subject
    {
        #region Properites
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? SubjectExam { get; set; } 
        #endregion

        #region Constructor
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Creates a shallow copy of the current subject.
        /// </summary>
        /// <returns>A shallow copy of the subject.</returns>
        public object clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Compares the current subject to another subject based on the subject ID.
        /// </summary>
        /// <param name="otherSubject">The subject to compare with.</param>
        /// <returns>An integer indicating the relative order.</returns>
        public int compareTo(Subject otherSubject)
        {
            return this.SubjectId.CompareTo(otherSubject.SubjectId);
        }

        /// <summary>
        /// Returns a string representation of the subject.
        /// </summary>
        /// <returns>A formatted string with subject details.</returns>
        public override string ToString()
        {
            return $"Subject Id is:{SubjectId}\nSubject Name is:{SubjectName}";
        }

        /// <summary>
        /// Creates an exam based on user input and assigns it to the subject.
        /// </summary>
        public void CreateExam()
        {
            #region Take Exam Detiles From User
            // Chose Exam Type:
            int examType;
            bool isParsed;
            do
            {
                Console.WriteLine("Welcome to Examination System");
                Console.Write("Chose Exam Type:\n--> 1 for Final\n--> 2 for Practical\nTap Ur Choice: ");
                isParsed = int.TryParse(Console.ReadLine(), out examType);

            } while (!isParsed || (examType != 1 && examType != 2));
            Console.WriteLine($"You selected exam type: {examType}");
            Console.Clear();

            // Enter Exam Duration:
            int duration;
            do
            {
                Console.Write("Enter Exam Duration In Minutes: ");
                isParsed = int.TryParse(Console.ReadLine(), out duration);

            } while (!isParsed || duration <= 0);
            Console.Clear();

            // Number Of Questions:
            int numOfQuestions;
            do
            {
                Console.Write("Enter Exam Questions Number: ");
                isParsed = int.TryParse(Console.ReadLine(), out numOfQuestions);

            } while (!isParsed || numOfQuestions <= 0);
            #endregion
            Console.Clear();

            // Create exam instance based on exam type.
            if (examType == 1)
            {
                SubjectExam = new FinalExam(DateTime.Now, numOfQuestions, duration);
            }
            else
            {
                Console.WriteLine("Attention: Practical Exam Has Only One Type Of Question (MSQ) But Final Will Be (MCQ and True,False)");
                SubjectExam = new PracticalExam(DateTime.Now, numOfQuestions, duration);
            }

            SubjectExam.AddQuestions();
        }
        #endregion
    }
}
