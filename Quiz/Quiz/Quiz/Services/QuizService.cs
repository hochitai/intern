using Quiz.DataStore;
using Quiz.Models;
using System;
using System.Collections.Generic;
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

        public void SubmitQuiz(int quizId, List<QuestionAnswer> questionAnswers)
        {
            foreach (QuestionAnswer qAnswer in questionAnswers) {
                quizStore.AddAnswerOfUser(quizId, qAnswer,
                    qAnswer.Score,
                    questionService.CheckAnwser(qAnswer.QuestionId, qAnswer.Answers));
            }
        }
        
        public int GetScore(int quizId, int userId)
        {
            return quizStore.GetScore(quizId, userId);
        }

    }
}
