﻿using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    internal class Controller
    {
        private Dao dao;
        private Random rnd;
        private ScoreModel scr;
        private QuestionAnswerModel[] AllQuestionAnswer;
        private QuestionAnswerModel[] AllQuestionAnswerRandom;
        private int NumberOfQuestions;
        private int ModelCounter;

        public Controller() {
            dao = new();
            rnd = new();
            scr = new();
            AllQuestionAnswer = dao.AllQuestionAnswers();
            AllQuestionAnswerRandom = RandomModelArray(AllQuestionAnswer);
            NumberOfQuestions = AllQuestionAnswer.Length;
            ModelCounter = 0;
        }
        public int RightScore() => scr.Right;
        public int WrongScore() => scr.Wrong;
        public void RightScore(int Right) => scr.Right = +Right;
        public void WrongScore(int Wrong) => scr.Wrong = +Wrong;
        public int GetNumberOfQuestions() => NumberOfQuestions;
        public void SetNumberOfQuesitons(int Number) => NumberOfQuestions = Number > NumberOfQuestions ? NumberOfQuestions : Number;
        public QuestionAnswerModel RandomQuestionAnswer()
        {
            QuestionAnswerModel ToBeReturned;
            if (ModelCounter != NumberOfQuestions)
            {
                ToBeReturned = AllQuestionAnswerRandom[ModelCounter];
                ModelCounter++;
                return ToBeReturned;
            }
            else
            {
                return null;
            }
        }
        public QuestionAnswerModel[] RandomModelArray(QuestionAnswerModel[] ModelArray)
        {
            return ModelArray.OrderBy(x => rnd.Next()).ToArray();
        }
        public void TestAnswer(AnswerModel CurrentQuestionAnswer)
        {
            if (CurrentQuestionAnswer.Answer == CurrentQuestionAnswer.RandomQuestionAnswer.Answer)
            {
                RightScore(1);
            }
            else
            {
                WrongScore(1);
            }
        }
        public int NewQuestionAnswer(string newQuestion, string newAnswer)
        {
            try
            {
                QuestionAnswerModel newQuestionAnswerModel = new(newQuestion, newAnswer);
                if (dao.InsertNewQuestionAnswer(newQuestionAnswerModel) != 0) { return 1; }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}
