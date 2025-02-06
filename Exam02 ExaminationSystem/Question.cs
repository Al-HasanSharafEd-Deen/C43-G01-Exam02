using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    public abstract class Question
    {
        #region Attributes
        // Attributes Hidden BCS I will Use Automatic Properties so it will be Backing Fields.
        #endregion

        #region Properties 
        // I will Use Automatic Properties
        public string? QuestionHeader { get; set; }
        public string? QuestionBody { get; set; }
        public double Mark { get; set; }
        public Answer[] AnswersList { get; set; } // hold possible answer choices
        public Answer CorrectAnswer { get; set; }
        public Answer UserAnswer { get; set; }
        #endregion

        #region Constructor
        // Constructor
        protected Question(string questionHeader, string questionBody, double mark, int answerCount)
        {
            QuestionHeader = questionHeader;
            QuestionBody   = questionBody;
            Mark = mark;
            AnswersList = new Answer[answerCount];
            // Initialize with default value:
            CorrectAnswer = new Answer(0, string.Empty); 
            UserAnswer    = new Answer(0, string.Empty);
        }
        #endregion

        #region Methods 
        /// <summary>
        /// Adds answers for the question.
        /// </summary>
        public abstract void AddAnswers();

        /// <summary>
        /// Returns a string representation of the question.
        /// </summary>
        /// <returns>A formatted string with question details.</returns>
        public override string ToString()
        {
            return $"{QuestionHeader}.{QuestionBody}                              {Mark} Marks";
        }
        #endregion
    }
}
