using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    public class TrueFalse : Question
    {

        #region Constructor
        public TrueFalse(string questionHeader, string questionBody, double mark) : base(questionHeader, questionBody, mark, 2) { }
        #endregion

        #region Methods

        /// <summary>
        /// Adds the fixed answers (True and False) to the question and prompts the user to select the correct one.
        /// </summary>
        public override void AddAnswers()
        {
            AnswersList = new Answer[2];
            AnswersList[0] = new Answer(1, "True");
            AnswersList[1] = new Answer(2, "False");

            int correctAnswer;
            bool isParsed;
            do
            {
                Console.Write("Enter Correct Answers\n--> 1 for True\n--> 2 for False: ");
                isParsed = int.TryParse(Console.ReadLine(), out correctAnswer);

            } while (!isParsed || (correctAnswer != 1 && correctAnswer != 2));

            // Assign the correct answer based on user input
            CorrectAnswer = Array.Find(AnswersList, a => a.AnswerId == correctAnswer) ?? new Answer(0, "Unknown");
        } 
        #endregion
    }
}
