using Quiz.DataStore;
using Quiz.Entities;
using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class QuizService
    {
        private readonly QuizStore quizStore;
        private readonly QuestionService questionService;

        public QuizService(QuizStore quizStore, QuestionService questionService)
        {
            this.quizStore = quizStore;
            this.questionService = questionService;
        }

        public bool AddQuiz(Entities.Quiz quiz)
        {
            return quizStore.AddQuiz(quiz);
        }

        public bool AddQuestion(int quizId, List<QuizQuestion> quizQuestions)
        {
            foreach (var question in quizQuestions)
            {
                var result = quizStore.AddQuestion(quizId, question);
                if (!result) return false;
            }
            return true;
        }

        public List<Entities.Quiz> GetQuizsByUserId(int userId)
        {
            return quizStore.GetQuizsByUserId(userId);
        }

        public List<QuizQuestion> GetQuizQuestionsByQuizId(int quizId) 
        {
            return quizStore.GetQuizQuestionByQuizId(quizId);
        }

        public bool SubmitQuiz(int quizId, int userId, List<QuestionAnswer> questionAnswers)
        {
            int score;
            bool isCorrect;
            foreach (QuestionAnswer qAnswer in questionAnswers) {
                score = quizStore.GetScoreOfQuestion(quizId, qAnswer.QuestionId);
                isCorrect = questionService.CheckAnwser(qAnswer.QuestionId, qAnswer.Answers);
                quizStore.AddAnswerOfUser(
                    quizId,
                    userId,
                    qAnswer,
                    score,
                    isCorrect
                );
            }
            return true;
        }
        
        public int GetScoreOfUser(int quizId, int userId)
        {
            return quizStore.GetScoreOfUser(quizId, userId);
        }

    }
}
