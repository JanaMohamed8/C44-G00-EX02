using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace oopExamSol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region examTypeCode
            Console.WriteLine("Please Enter the type of the exam (1 for practical | 2 for final)");
            bool IsParsed;
            int ExamType;
            do
            {
                IsParsed = int.TryParse(Console.ReadLine(), out ExamType);
                if (ExamType != 1 && ExamType != 2)
                {
                    IsParsed = false;
                    Console.WriteLine("Please Enter the type of the exam (1 for practical | 2 for final)");
                }
            } while (!IsParsed);
            Subject subject = new Subject(1, "OOP", ExamType);
            #endregion
            #region DataOfExam
            Console.WriteLine("Please Enter the time of the exam (30 min to 180)");
            int ExamTime;
            do
            {
                IsParsed = int.TryParse(Console.ReadLine(), out ExamTime);
                if (ExamTime < 30 || ExamTime > 180)
                {
                    IsParsed = false;
                    Console.WriteLine("Please Enter the time of the exam (30 min to 180)");
                }
            } while (!IsParsed);
           
            int Qnumber;
            do
            { 
                Console.WriteLine("Please Enter the Number of questions");
                IsParsed = int.TryParse(Console.ReadLine(), out Qnumber);
                if (ExamType < 1 )
                {
                    IsParsed = false;
                    Console.WriteLine("Please Enter the Number of questions");
                }
            } while (!IsParsed);
            Console.Clear();
             List<Question> listOfQustions = new List<Question>();


            #endregion
            #region Take questions
            for (int i = 0; i < Qnumber; i++)
            {
                #region type of the Question
                  string QHeader;
                  int QType;
                 if(subject.ExamOfTheSubject == 2) //final
                {
                    Console.WriteLine("Please Enter the type of the Question (1 for MCQ || 2 for true or false)");
                    
                    do
                    {
                        IsParsed = int.TryParse(Console.ReadLine(), out QType);
                        if (QType != 1 && QType != 2)
                        {
                            IsParsed = false;
                            Console.WriteLine("Please Enter the type of the Question (1 for MCQ || 2 for true or false)");
                        }
                    } while (!IsParsed);
                   
                    if (QType == 1)
                    {
                        QHeader = "MCQ Question";
                    }
                    else
                    {
                        QHeader = "True Or False Question";
                    }

                }
                else //MCQ
                {
                    QType = 1;
                    QHeader = "MCQ Question";
                }
                Console.Clear();

                #endregion
                #region take data of question
                Console.WriteLine(QHeader);
                 string QBody;
                    do
                    {
                        Console.WriteLine("Please Enter Question Body");
                        QBody = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(QBody));
                int QMark;
                do
                {
                    Console.WriteLine("Please Enter Question Mark");
                    IsParsed = int.TryParse(Console.ReadLine(),out QMark);
                } while (!IsParsed);


                if(QType == 1) //MCQ -> take choises
                {
                    #region take choises for mcq
                    Console.WriteLine("Choises of the Question");
                    Answer[] choises = new Answer[3];
                    for (int j = 0; j < 3; j++)
                    {
                        string choice;
                        do
                        {
                            Console.WriteLine($"Please Enter choise Number {j + 1}");
                            choice = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(choice));
                        choises[j] = new Answer();
                        choises[j].AnswerId = j; // [0] -> 0,inherit index=id
                        choises[j].AnswerText = choice;
                    }
                    int RightAnsId;
                    do
                    {
                        Console.WriteLine("Please Enter Right Answer Id");
                       IsParsed = int.TryParse(Console.ReadLine(), out RightAnsId);
                        if (RightAnsId != 1 && RightAnsId != 2 && RightAnsId != 3)
                        {
                            IsParsed = false;
                        }

                    } while (!IsParsed);
                    #endregion
                    listOfQustions.Add(new MCQ(QHeader, QBody,QMark , RightAnsId-1, choises));
                }
                else
                {
               
                    int RightAnsId;
                 
                    do
                    {
                        Console.WriteLine("Please Enter Right Answer Id (1 for true | 2 for false)");
                        IsParsed = int.TryParse(Console.ReadLine(), out RightAnsId);
                        if(RightAnsId != 1 && RightAnsId != 2)
                        {
                            IsParsed = false;
                        }
                    } while (!IsParsed);
                    Answer[] TrueOrFalseAnswer = new Answer[1]; //[0] -> 1,True
                    TrueOrFalseAnswer[0] = new Answer();
                    if (RightAnsId == 1)
                    {
                        TrueOrFalseAnswer[0].AnswerId = 1;
                        TrueOrFalseAnswer[0].AnswerText = "True";
                    }
                    else
                    {

                        TrueOrFalseAnswer[0].AnswerId = 2;
                        TrueOrFalseAnswer[0].AnswerText = "False";
                    }
                  
                    listOfQustions.Add(new TrueOrFalse(QHeader, QBody, QMark,RightAnsId, TrueOrFalseAnswer));
                }


                #endregion
                Console.Clear();

            }
            #endregion
            #region Enter the test
            Console.WriteLine($"Do You want to start the exam (Y|N)");
            char startTheExam;
            do
            {
                IsParsed = char.TryParse(Console.ReadLine(),out startTheExam);
                if(Char.ToLower(startTheExam) != 'y' && Char.ToLower(startTheExam) == 'n')
                {
                    IsParsed = false;
                    Console.WriteLine($"please Enter (Y|N)");
                }
            } while (!IsParsed);
            Console.Clear( );
            if(Char.ToLower(startTheExam) == 'y')
            {
                int UserAnsId;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                foreach (var question in listOfQustions)
                {
                    question.Dispaly();
                    do
                    {
                        Console.WriteLine("Please Enter the Answer Id");
                        IsParsed = int.TryParse(Console.ReadLine(), out UserAnsId);
                        if(question.HeaderOfTheQuestion == "True Or False Question")
                        {
                            if(UserAnsId !=1 && UserAnsId != 2)
                            { 
                                IsParsed = false;
                                Console.WriteLine($"Please Enter 1 or 2");
                            }
                        }else if(question.HeaderOfTheQuestion == "MCQ Question")
                        {
                            if (UserAnsId != 1 && UserAnsId != 2 && UserAnsId != 3)
                            {
                              IsParsed = false;
                              Console.WriteLine($"Please Enter 1 or 2 or 3");
                            }
                               
                        }
                    }while (!IsParsed);
                    question.SetUserAnswerId(UserAnsId); //true false 1|2
                                                         

                    

                }
                Console.Clear( );
                int sum = 0;
                int rightAnsSum = 0;
                foreach (var question in listOfQustions)
                {
               
                    sum += question.Mark;
                  
                    if (question.HeaderOfTheQuestion == "True Or False Question")
                    {
                        if (question.UserAnswerId == question.RightAnsId) rightAnsSum += question.Mark;
                    }
                    else if (question.HeaderOfTheQuestion == "MCQ Question")
                    {
                        if (question.UserAnswerId-1 == question.RightAnsId ) rightAnsSum += question.Mark;
                    }
                    Console.WriteLine(question);
                }
                stopwatch.Stop();
                Console.WriteLine($"\nTime taken: {stopwatch.Elapsed.Minutes} minutes, {stopwatch.Elapsed.Seconds} seconds");
               
                Console.WriteLine($"Your Grade is {rightAnsSum} From {sum} \nThank You");
            } 
            else
            {
                 Console.WriteLine("The Exam Ended");
            }

            #endregion
        }
    }
}
