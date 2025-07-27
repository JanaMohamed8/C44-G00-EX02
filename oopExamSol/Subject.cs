using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopExamSol
{
    internal class Subject
    {
        #region property
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int ExamOfTheSubject { get; set; }
        #endregion
        #region constructor
        public Subject(int _SubjectId ,string _SubjectName, int _ExamOfTheSubject)
        {
            SubjectId = _SubjectId;
            SubjectName = _SubjectName;
            ExamOfTheSubject = _ExamOfTheSubject;
        }
        #endregion

        #region MyRegion
        //public Exam CreateTheExam()
        // {
        //    if (ExamOfTheSubject == 1)
        //    {
        //        return new Practical();
        //    }
        //    else
        //    {
        //        return new Final();
        //    }
        //}
        #endregion


    }
}
