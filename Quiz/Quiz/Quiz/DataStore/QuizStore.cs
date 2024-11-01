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
        private List<Entities.Quiz> quizs = new List<Entities.Quiz>
        {
            new Entities.Quiz()
            {
                Id = 1,
                Title = "Test",
                Duration = 60,
                OwnerId = 1
            }
        };

        private List<QuizQuestion> quizQuestions = new List<QuizQuestion>()
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

        private List<QuizUser> quizUsers = [];

        public bool AddQuiz(Entities.Quiz quiz)
        {
            quizs.Add(quiz);
            return true;
        }

        public bool AddAnswerOfUser(int quizId, int userId, QuestionAnswer qAnswer, int score, bool isCorrect)
        {
            foreach (var answer in qAnswer.Answers)
            {
                quizUsers.Add(new QuizUser()
                {
                    QuizQuestionId = GetQuizQuestionId(quizId, qAnswer.QuestionId),
                    Score = score,
                    UserId = userId,
                    AnswerId = answer.Id,
                    Content =  answer.Content ?? "",
                    Result = isCorrect
                });
            }
            return true;
        }

        private int GetQuizQuestionId(int quizId, int questionId)
        {
            return quizQuestions.Find(qq => qq.QuizId == quizId && qq.QuestionId == questionId).Id;
        }

        public int GetScoreOfUser(int quizUser, int userId)
        {
            return quizUsers.Where(qu => qu.Id == quizUser && qu.UserId == userId)
                 .Join(quizQuestions, qu => qu.QuizQuestionId, qq => qq.Id, (qu, qq) => qu)   
                .Sum(qu => qu.Score);
        }

        public int GetScoreOfQuestion(int quizId, int questionId)
        {
            return quizQuestions.Find(qu => qu.QuizId == quizId && qu.QuestionId == questionId).Score;
        }

        internal bool AddQuestion(int quizId, QuizQuestion quizQuestion)
        {
            quizQuestion.QuizId = quizId;
            quizQuestions.Add(quizQuestion);
            return true;
        }

        internal List<QuizQuestion> GetQuizQuestionByQuizId(int quizId)
        {
            throw new NotImplementedException();
        }

        internal List<Entities.Quiz> GetQuizsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
