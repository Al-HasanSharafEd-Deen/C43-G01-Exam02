using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    public class MCQ : Question
    {
        #region Constructor
        public MCQ(string header, string body, int mark) : base(header, body, mark, 0) { }
        #endregion

        #region Methods

        /// <summary>
        /// Prompts the user to add answer choices and select the correct answer.
        /// </summary>
        public override void AddAnswers()
        {
            // Take Number Of Choices
            int numberOfChoices;
            bool isParsed;
            do
            {
                Console.Write("Enter The Number Of Choices: ");
                isParsed = int.TryParse(Console.ReadLine(), out numberOfChoices);
            } while (!isParsed || numberOfChoices <= 0);

            // Initialize the AnswersList array with the specified number of choices
            AnswersList = new Answer[numberOfChoices]; 
            for (int i = 0; i < numberOfChoices; i++)
            {
                string? choice;
                do
                {
                    Console.Write($"Enter Choice Number[{i + 1}]: ");
                    choice = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(choice));
                AnswersList[i] = new Answer(i + 1, choice);  // Create answer object
            }

            // Take the correct answer
            int correctAnswerId;
            do
            {
                Console.Write("Enter the Correct Answer: ");
                isParsed = int.TryParse(Console.ReadLine(), out correctAnswerId);

            } while (!isParsed || !AnswersList.Any(a => a.AnswerId == correctAnswerId));
            CorrectAnswer = AnswersList.First(a => a.AnswerId == correctAnswerId);  // Set the correct answer.
        } 
        #endregion
    }
}
