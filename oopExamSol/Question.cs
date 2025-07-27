using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopExamSol
{
    internal abstract class Question
    {
        #region property
        public string  HeaderOfTheQuestion { get; set; }
        public string BodyOfTheQuestion { get; set; }
        public int Mark { get; set; }
        public int RightAnsId { get; set; }
        public int UserAnswerId {  get; set; }

       public Answer[] Answers { get; set; }
        #endregion

        #region constructor
        public Question(string _HeaderOfTheQuestion, string _BodyOfTheQuestion, int _Mark, int _RightAnsId , Answer[] _Answers)
        {
            HeaderOfTheQuestion = _HeaderOfTheQuestion;
            BodyOfTheQuestion = _BodyOfTheQuestion;
            Mark = _Mark;
            RightAnsId = _RightAnsId;
            Answers = _Answers;
        }
        #endregion

        #region Display
        public abstract void Dispaly();
        #endregion

        #region UserAnswer
        public void SetUserAnswerId(int id)
        {
            UserAnswerId = id;
        }

        #endregion


    }
}
