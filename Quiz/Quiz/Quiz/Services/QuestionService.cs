using Quiz.DataStore;
using Quiz.Entities;
using Quiz.Enum;
using System;
using System.Collections.Generic;
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

        public bool CheckAnwser(int questionId, List<Answer> answersOfUser)
        {
            var typeOfQuestion = _questionStore.GetTypeIdByQuestionId(questionId);

            List<Answer> trueAnswerList;
            bool haveContent = false;

            if (typeOfQuestion == (int) QuestionTypeEnum.Wrtting) 
            {
                haveContent = true;
                
                trueAnswerList = _questionStore.GetAnswers(questionId, haveContent);

                var trueAnswerNeedCount = int.Parse(trueAnswerList.First().OptionType[0].ToString()); // ex: 2InM

                if (trueAnswerNeedCount != answersOfUser.Count()) { return false; }

                foreach (var answer in answersOfUser) 
                { 
                    bool existed = false;
                    foreach (var trueAnswer in trueAnswerList)
                    {
                        if (String.Equals(answer.Content, trueAnswer.Content) && answer.Result == trueAnswer.Result)
                        {
                            existed = true;
                            break;
                        }
                    }
                    if (!existed) { return false; }
                }
            } else
            {
                trueAnswerList = _questionStore.GetAnswers(questionId, haveContent);

                if (trueAnswerList.Count() != answersOfUser.Count()) { return false; }

                foreach (var answer in answersOfUser)
                {
                    if (!trueAnswerList.Contains(answer))
                    {
                        return false;
                    }
                }
            }
            return true;

        }
    }

}
