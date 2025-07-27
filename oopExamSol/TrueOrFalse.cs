using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopExamSol
{
    internal class TrueOrFalse : Question
    {
        //public int AnsID { get; set; }
       
        public TrueOrFalse(string _HeaderOfTheQuestion, string _BodyOfTheQuestion, int _Mark,int _AnsID, Answer[] _Answers) : base(_HeaderOfTheQuestion, _BodyOfTheQuestion, _Mark, _AnsID, _Answers)
        {
          
        }

        public override void Dispaly()
        {
            Console.WriteLine($"True | False Question       Mark is {Mark}");
            Console.WriteLine(BodyOfTheQuestion);
            Console.WriteLine($"1-True \n2-False");
        }

        #region toString
        public override string ToString()
        {
            string AnswerTextToDisplay;
          
            if (UserAnswerId == 1) AnswerTextToDisplay = "True";
            else AnswerTextToDisplay = "False";


            return $"Question : {BodyOfTheQuestion} \nRight Answer => {Answers[0].AnswerText} \nYour Answer => {AnswerTextToDisplay}\n";
        }
        #endregion

    }
}
