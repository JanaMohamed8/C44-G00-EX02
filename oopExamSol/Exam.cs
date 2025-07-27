using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopExamSol
{
    internal abstract class Exam
    {
        #region property
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        #endregion

        #region constructor
        //protected Exam(int _TimeOfExam , int _NumberOfQuestions)
        //{
        //    TimeOfExam = _TimeOfExam ;
        //    NumberOfQuestions = _NumberOfQuestions;     
        //}
        #endregion



    }
}
