using Quiz.Entities;
using Quiz.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.DataStore
{
    public class QuestionStore
    {

        private List<Question> questions = new List<Question>()
        {

        };

        private List<Answer> anwsers = new List<Answer>()
        {

        };


        public List<Answer> GetAnswers(int questionId, bool haveContent)
        {
            throw new NotImplementedException();
        }

        public int GetTypeIdByQuestionId(int questionId)
        {
            throw new NotImplementedException();
        }
    }


}
