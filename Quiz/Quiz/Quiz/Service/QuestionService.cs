using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Service
{
    public class QuestionService
    {
        public bool CheckAnwser(Question question, List<Answer> answers, List<Answer> answerOfUsers)
        {
            if (question == null || answers == null || answers.Count() == 0 || answerOfUsers == null || answerOfUsers.Count() == 0 ) {  return false; }

            if (answers.Count() != answerOfUsers.Count()) { return false; }

            // temple for type
            // type id = 1 is choice
            // type id = 2 is multi choice
            // type id = 3 is multi choice with order
            // type id = 4 is writing
            if (question.TypeId == 1 )
            {
               if (question.Id != answerOfUsers[0].QuestionId || question.Id != answers[0].QuestionId) { return false; }
               return answerOfUsers[0].Id == answers[0].Id;
            }


            return false;
        }
    }
}
