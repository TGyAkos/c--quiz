using System;


namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Dao dao = new();
            Model[] a = dao.AllQuestionAnswers();
            Console.WriteLine(a);
            Console.WriteLine("Hello World!");
        }
    }
}
