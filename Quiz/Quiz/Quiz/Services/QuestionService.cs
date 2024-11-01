using Quiz.DataStore;
using Quiz.Entities;
using Quiz.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services
{
    public class QuestionService
    {

        private readonly QuestionStore _questionStore;

        public QuestionService(QuestionStore questionStore)
        {
            _questionStore = questionStore;
        }
        public List<Question> GetQuestionsByLevelId(int levelId)
        {
            return _questionStore.GetQuestionsByLevelId(levelId);
        }

        public List<Question> GetQuestionsByTagId(int tagId)
        {
            return _questionStore.GetQuestionsByTagId(tagId);
        }

        public List<Answer> GetAnswersByQuestionId(int questionId) 
        {
            return _questionStore.GetAnswers(questionId, true);
        }

        public bool AddQuestion(Question question)
        {
            return _questionStore.AddQuestion(question);
        }

        public bool AddAnswers(int questionId, List<Answer> answers)
        {
            foreach (Answer answer in answers)
            {
                var result = _questionStore.AddAnswers(questionId, answer);
                if (!result) return false;
            }
            return true;
        }

        public bool CheckAnwser(int questionId, List<Answer> answersOfUser)
        {
            var typeOfQuestion = _questionStore.GetTypeIdByQuestionId(questionId);
            var trueAnswerList = _questionStore.GetAnswers(questionId, HaveContent(typeOfQuestion));

            if (typeOfQuestion == (int)QuestionTypeEnum.Wrtting)
            {
                return CheckWritingAnswer(answersOfUser, trueAnswerList);
            }

            return CheckChoiceAnswer(answersOfUser, trueAnswerList);

        }

        private bool HaveContent(int typeOfQuestion)
        {
            return typeOfQuestion == (int) QuestionTypeEnum.Wrtting;
        }

        public bool CheckChoiceAnswer(List<Answer> answersOfUser, List<Answer> trueAnswerList)
        {
            return trueAnswerList.Count() == answersOfUser.Count() && answersOfUser.All(answer => trueAnswerList.Contains(answer));
        }

        public bool CheckWritingAnswer(List<Answer> answersOfUser, List<Answer> trueAnswerList)
        {
            int trueAnswerNeedCount = GetTrueAnswerNeedCount(trueAnswerList); // ex: 2InM

            return trueAnswerNeedCount == answersOfUser.Count() && answersOfUser.All(answer =>
                trueAnswerList.Any(trueAnswer =>
                    string.Equals(answer.Content, trueAnswer.Content, StringComparison.OrdinalIgnoreCase)
                    && answer.Result == trueAnswer.Result
                )
            );
        }
        private int GetTrueAnswerNeedCount(List<Answer> trueAnswerList)
        {
            return int.Parse(trueAnswerList.First().OptionType[0].ToString());
        }

    }

}
