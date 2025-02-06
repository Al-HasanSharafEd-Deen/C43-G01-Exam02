
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    internal class PracticalExam : Exam
    {
        #region Constructor
        public PracticalExam(DateTime timeOfExam, int numOfQuestions, int duration) : base(timeOfExam, numOfQuestions, duration) { }
        #endregion

        #region Methds

        /// <summary>
        /// Adds questions to the practical exam by prompting user input.
        /// </summary>
        public override void AddQuestions()
        {
            for (int i = 0; i < NumOfQuestions; i++)
            {
                Console.WriteLine($"Details For Question {i + 1}");

                // Question Header
                string? questionHeader;
                bool isParsed;
                do
                {
                    Console.Write("Enter Question Header: ");
                    questionHeader = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(questionHeader));

                // Question Body
                string? questionBody;
                do
                {
                    Console.Write("Enter Question Body: ");
                    questionBody = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(questionBody));

                // Question Mark
                double mark;
                do
                {
                    Console.Write("Enter Question Mark: ");
                    isParsed = double.TryParse(Console.ReadLine(), out mark);
                } while (!isParsed || mark <= 0);

                Question? question = new MCQ(questionHeader, questionBody, (int)mark);
                question.AddAnswers();    // Add answers to the question
                Questions[i] = question;  // Assign question to array
                Console.Clear();
            }
        }

        /// <summary>
        /// Displays the practical exam questions, collects user answers, and shows immediate feedback.
        /// </summary>
        public override void ViewExam()
        {
           // int totalMarks = 0;
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                foreach (var answer in question.AnswersList)
                {
                    Console.WriteLine(answer);
                }

                // take user answer
                int answerId;
                bool isParsed;
                do
                {
                    Console.Write("Enter Ur Answer: ");
                    isParsed = int.TryParse(Console.ReadLine(), out answerId);

                } while (!isParsed || !question.AnswersList.Any(a => a.AnswerId == answerId));

                Answer? userAnswer = Array.Find(question.AnswersList, a => a.AnswerId == answerId); // find answer
                question.UserAnswer = userAnswer;

                // Provide immediate feedback.
                /* if (userAnswer == question.CorrectAnswer) totalMarks += (int)question.Mark;*/
                if (userAnswer == question.CorrectAnswer)  Console.WriteLine("Correct Answer");
               else  Console.WriteLine("Wrong Answer");
            }
            Console.Clear();
        }

        /// <summary>
        /// Displays the results of the practical exam, including each question and the total mark.
        /// </summary>
        public override void ViewResults()
        {
            Console.Clear();
            Console.WriteLine("Practical Exam Results");
            int totalMark = 0;
            int totalMarkForQuestion = 0;

            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                Console.WriteLine($"Your Answer : {question.UserAnswer}");
                Console.WriteLine($"Correct Answer : {question.CorrectAnswer}");
                Console.WriteLine();
                if (question.UserAnswer == question.CorrectAnswer)
                {
                    totalMark += (int)question.Mark;
                }
                totalMarkForQuestion += (int)question.Mark;
            }
            Console.WriteLine($"Ur Mark is : {totalMark} From {totalMarkForQuestion}");
        }
        #endregion

    }
}
