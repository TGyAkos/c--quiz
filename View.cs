using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Quiz
{
    internal class View
    {
        private Controller cont;
        private AnswerController anscont;

        public View() { cont = new(); anscont = new(); }

        public void DrawUi()
        {
            while (true)
            {
                string[] options = { "Play", "Add More Questions", "Exit" };
                WriteAllOptions(options);
                WriteLine("Enter the desired number");
                switch (NoNullInput())
                {
                    case "1":
                        DrawScoreAllQuestionAnswer();
                        break;
                    case "2":
                        AddNewQuestionAnswer();
                        break;
                    case "3":
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }

            }
        }
        public void AddNewQuestionAnswer()
        {
            WriteLine("Question: ");
            string newQuestion = NoNullInput();
            WriteLine("Answer: ");
            string newAnswer = NoNullInput();
            if (cont.NewQuestionAnswer(newQuestion, newAnswer) == 0)
            {
                WriteLine("Succesfully added new question");
            }
            else
            {
                WriteLine("Failed to add new question");
            }
        }
        public void DrawScoreAllQuestionAnswer()
        {
            WriteSetNumberOfQuestions();

            for (int i = 0; i < cont.GetNumberOfQuestions(); i++)
            {
                cont.TestAnswer(WriteGetQuestionAnswer());
            }

            WriteLine(string.Format("Your score: {0} / {1}", cont.RightScore(), cont.GetNumberOfQuestions()));
        }
        public void WriteSetNumberOfQuestions()
        {
            WriteLine("Number of questions");
            cont.SetNumberOfQuesitons(int.Parse(NoNullInput()));
        }
        public AnswerModel WriteGetQuestionAnswer()
        {
            anscont.NewAnswerModelInstance();
            AnswerModel answerModel = anscont.GetAnswerModel();

            WriteLine(string.Format("Question: {0}", answerModel.RandomQuestionAnswer.Question));
            
            anscont.SetAnswerModelAnswer(NoNullInput());
            return answerModel;
        }
        public string NoNullInput()
        {
            string input = ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                WriteLine("Please enter: ");
                input = ReadLine();
            }
            return input;
        }
        public void WriteAllOptions(string[] allOptions)
        {
            for (int i = 0; i < allOptions.Length; i++)
            {
                WriteLine(string.Format("{0}. - {1}", i + 1, allOptions[i]));
            }
        }
    }
}
