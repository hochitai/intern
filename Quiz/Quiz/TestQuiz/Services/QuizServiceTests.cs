using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz.DataStore;
using Quiz.Entities;
using Quiz.Models;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services.Tests
{
    [TestClass()]
    public class QuizServiceTests
    {
        private QuizStore quizStore;
        private QuizService quizService;
        private QuestionStore questionStore;
        private QuestionService questionService;

        [TestInitialize]
        public void TestInitialize()
        {
            questionStore = new QuestionStore();
            questionService = new QuestionService(questionStore);
            quizStore = new QuizStore();
            quizService = new QuizService(quizStore, questionService);
        }

        [TestMethod()]
        public void SubmitQuizTest()
        {
            // Arrange
            int quizId = 1;
            int userId = 1;

            List<QuestionAnswer> answerList = new List<QuestionAnswer>()
            {
                new QuestionAnswer()
                {
                    QuestionId = 1,
                    Answers = new List<Entities.Answer>()
                    {
                        new Answer()
                        {
                            Id = 1,
                        }
                    }
                },
                new QuestionAnswer()
                {
                    QuestionId = 2,
                    Answers = new List<Entities.Answer>()
                    {
                        new Answer()
                        {
                            Id = 5,
                        }
                    }
                },
            };


            // Action

            var result = quizService.SubmitQuiz(quizId, userId, answerList);

            // Assert
            Assert.IsTrue(result);
            

        }
    }
}