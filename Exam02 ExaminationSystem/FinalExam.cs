using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    public class FinalExam : Exam
    {
        #region Constructor
        public FinalExam(DateTime timeOfExam, int numOfQuestions, int duration) : base(timeOfExam, numOfQuestions, duration) { }
        #endregion

        #region Methos

        /// <summary>
        /// Adds questions to the final exam by prompting user input.
        /// </summary>
        public override void AddQuestions()
        {
            for (int i = 0; i < NumOfQuestions; i++)
            {
                Console.WriteLine($"Details For Question {i + 1}");

                // Question type
                int questionType;
                bool isParsed;
                do
                {
                    Console.Write("Chose Question Type\n--> 1 for (True|False)\n--> 2 for (MCQ)\nTap Ur Choice: ");
                    isParsed = int.TryParse(Console.ReadLine(), out questionType);

                } while (!isParsed || (questionType != 1 && questionType != 2));

                // Question Header
                string? questionHeader;
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

                // Create appropriate question type based on input.
                Question question;
                if (questionType == 1)
                {
                    question = new TrueFalse(questionHeader, questionBody, mark);
                }
                else
                {
                    question = new MCQ(questionHeader, questionBody, (int)mark);
                }

                question.AddAnswers();   //add answer choices
                Questions[i] = question; // Assign question to array.
                Console.Clear();        
            }
        }

        /// <summary>
        /// Displays the final exam questions, collects user answers, and calculates marks.
        /// </summary>
        public override void ViewExam()
        {
            int totalMarks = 0;
            // Display question details
            foreach (var question in Questions)
            {
                Console.WriteLine(question);
                foreach (var answer in question.AnswersList)
                {
                    // Display each answer
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

                Answer? userAnswer = Array.Find(question.AnswersList, a => a.AnswerId == answerId); // Get the matching answer
                question.UserAnswer = userAnswer;
                if (userAnswer == question.CorrectAnswer) totalMarks += (int)question.Mark;

            }
            Console.Clear();
        }

        /// <summary>
        /// Displays the results of the final exam, including each question and the total mark.
        /// </summary>
        public override void ViewResults()
        {
            Console.Clear();
            Console.WriteLine("Final Exam Results");
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
            Console.WriteLine($"Total Mark is : {totalMark} Out Of {totalMarkForQuestion}");
        } 
        #endregion
    }
}
