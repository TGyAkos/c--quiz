using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    class Model
    {
        public string ?Question { get; }
        public string ?Answer { get; }

        public Model(string newQuestion, string newAnswer)
        {
            Question = newQuestion;
            Answer = newAnswer;
        }

        public override string ToString() {
            return string.Format("Model: {0} {1} ", Question, Answer);
        }
    }
}
