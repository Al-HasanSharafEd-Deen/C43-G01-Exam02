using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam02_ExaminationSystem
{
    public abstract class Exam
    {
        #region Properites
        public DateTime TimeOfExam { get; set; } // Represents the specific date and time when the exam is scheduled to start.
        public int NumOfQuestions { get; set; }
        public int Duration { get; set; } // Represents the duration of the exam in minutes.
        public Question[] Questions { get; set; }
        #endregion

        #region Constructor
        //constructor
        protected Exam(DateTime timeOfExam, int numOfQuestions, int duration)
        {
            TimeOfExam = timeOfExam;
            NumOfQuestions = numOfQuestions;
            Duration = duration;
            Questions = new Question[numOfQuestions];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds questions to the exam.
        /// </summary>
        public abstract void AddQuestions();

        /// <summary>
        /// Displays the exam details.
        /// </summary>
        public abstract void ViewExam();

        /// <summary>
        /// Displays the exam results.
        /// </summary>
        public abstract void ViewResults(); 
        #endregion
    }
}
