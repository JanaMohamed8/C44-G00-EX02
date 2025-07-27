using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopExamSol
{
    internal class MCQ : Question
    {
       
        #region constructor
        public MCQ(string _HeaderOfTheQuestion, string _BodyOfTheQuestion, int _Mark, int _RightAnsId, Answer[] _Answers) : base(_HeaderOfTheQuestion, _BodyOfTheQuestion, _Mark ,_RightAnsId, _Answers)
        {
          
        }
        #endregion
        #region Display
        public override void Dispaly()
        {
            Console.WriteLine($"{HeaderOfTheQuestion}       Mark is {Mark}");
            Console.WriteLine(BodyOfTheQuestion);
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}-{Answers[i].AnswerText}");
            }

        }
        #endregion

        #region tostring
        public override string ToString()
        {
            string AnswerTextToDisplay;
            if (UserAnswerId == 1) AnswerTextToDisplay = Answers[0].AnswerText;
            else if (UserAnswerId == 2) AnswerTextToDisplay = Answers[1].AnswerText;
            else AnswerTextToDisplay = Answers[2].AnswerText;
            return $"Question : {BodyOfTheQuestion} \nRight Answer => {Answers[RightAnsId].AnswerText} \nYour Answer => {AnswerTextToDisplay}\n"; ;
        }
        #endregion

    }
}
