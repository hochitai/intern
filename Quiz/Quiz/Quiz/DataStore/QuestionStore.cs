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
            new Question()
            {
                Id = 1,
                Title = "A",
                Content = "html",
                TypeId = 1,
            },
            new Question()
            {
                Id = 2,
                Title = "B",
                Content = "html",
                TypeId = 1,
            },
            new Question()
            {
                Id = 3,
                Title = "C",
                Content = "html",
                TypeId = 2,
            },
            new Question()
            {
                Id = 4,
                Title = "D",
                Content = "html",
                TypeId = 3,
            },
            new Question()
            {
                Id = 5,
                Title = "E",
                Content = "html",
                TypeId = 4,
            },
            new Question()
            {
                Id = 6,
                Title = "F",
                Content = "html",
                TypeId = 4,
            },
        };

        private List<Answer> anwsers = new List<Answer>()
        {
            new Answer()
            {
                Id= 1,
                Content= "Yes Option",
                QuestionId= 1,
                Result = 1
            },
            new Answer()
            {
                Id= 2,
                Content= "No Option",
                QuestionId= 1,
            },
            new Answer()
            {
                Id= 3,
                Content= "A Option",
                QuestionId= 2,
            },
            new Answer()
            {
                Id= 4,
                Content= "B Option",
                QuestionId= 2,
            },
            new Answer()
            {
                Id= 5,
                Content= "C Option",
                QuestionId= 2,
                Result = 1
            },
            new Answer()
            {
                Id= 6,
                Content= "D Option",
                QuestionId= 2,
            },
            new Answer()
            {
                Id= 7,
                Content= "A Option",
                QuestionId= 3,
                Result = 1
            },
            new Answer()
            {
                Id= 8,
                Content= "B Option",
                QuestionId= 3,
            },
            new Answer()
            {
                Id= 9,
                Content= "C Option",
                QuestionId= 3,
                Result = 1
            },
            new Answer()
            {
                Id= 10,
                Content= "D Option",
                QuestionId= 3,
            },
             new Answer()
            {
                Id= 11,
                Content= "A Option",
                QuestionId= 4,
                Result = 1
            },
            new Answer()
            {
                Id= 12,
                Content= "B Option",
                QuestionId= 4,
                Result = 2
            },
            new Answer()
            {
                Id= 13,
                Content= "C Option",
                QuestionId= 4,
            },
            new Answer()
            {
                Id= 14,
                Content= "D Option",
                QuestionId= 4,
            },
            new Answer()
            {
                Id= 15,
                Content= "Inherite",
                QuestionId= 5,
                Result = 1,
                OptionType = "1InM"
            },
            new Answer()
            {
                Id= 16,
                Content= "Kế thừa",
                QuestionId= 5,
                Result = 1,
                OptionType = "1InM"
            },
            new Answer()
            {
                Id= 17,
                Content= "Inherite",
                QuestionId= 6,
                Result = 1,
                OptionType = "2InM"
            },
            new Answer()
            {
                Id= 18,
                Content= "Kế thừa",
                QuestionId= 6,
                Result = 1,
                OptionType = "2InM"
            },
            new Answer()
            {
                Id= 19,
                Content= "Override",
                QuestionId= 6,
                Result = 2,
                OptionType = "2InM"
            },
            new Answer()
            {
                Id= 20,
                Content= "Ghi đè",
                QuestionId= 6,
                Result = 2,
                OptionType = "2InM"
            },
        };


        public List<Answer> GetAnswers(int questionId, bool haveContent)
        {
            return (from answer in this.anwsers
                    where answer.QuestionId == questionId && answer.Result > 0
                    select new Answer()
                    {
                        Id = answer.Id,
                        Result = answer.Result,
                        OptionType = answer.OptionType,
                        Content = haveContent ? answer.Content : "",
                    }).ToList();
        }

        public int GetTypeIdByQuestionId(int questionId)
        {
            return (from question in this.questions
                    where question.Id == questionId
                    select question.TypeId).First();
        }

        public bool AddQuestion(Question question)
        {
            questions.Add(question);
            return true;
        }

        public bool AddAnswers(List<Answer> nAnswers)
        {
            foreach (Answer answer in nAnswers)
            {
                this.anwsers.Add(answer);
            }
            return true;
        }
    }
}
