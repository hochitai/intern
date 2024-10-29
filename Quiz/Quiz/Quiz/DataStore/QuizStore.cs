using Quiz.Entities;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DataStore
{
    public class QuizStore
    {
        List<Entities.Quiz> quizs  = new List<Entities.Quiz>
        {
            new Entities.Quiz()
            {
                Id = 1,
                Title = "Test",
                Duration = 60,
                OwnerId = 1
            }
        };

        List<QuizQuestion> quizQuestions = new List<QuizQuestion>()
        {
            new QuizQuestion()
            {
                Id= 1,
                QuizId= 1,
                QuestionId= 1,
                Score = 40
            },
            new QuizQuestion()
            {
                Id= 2,
                QuizId= 1,
                QuestionId= 2,
                Score = 60
            },
        };

        List<QuizUser> quizUsers = [];

        public void AddAnswerOfUser(int quizId, QuestionAnswer qAnswer, int score, bool isCorrect)
        {
           
        }

        public int GetScore(int quizId, int userId)
        {
            return quizUsers.Where(qu => qu.Id == quizId && qu.UserId == userId).Sum(qu => qu.Score);
        }
    }
}
