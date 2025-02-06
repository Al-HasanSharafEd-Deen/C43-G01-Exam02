using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    public class Answer
    {
        #region Properites
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        #endregion

        #region Constructor
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Returns a string that represents the current answer.
        /// </summary>
        /// <returns>A formatted string with the answer details.</returns>
        public override string ToString()
        {
            return $"{AnswerId}.{AnswerText}";
        }
        #endregion
    }
}
