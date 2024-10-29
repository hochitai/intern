using Quiz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuestionAnswer
    {
        public int QuestionId { get; set; }
        public List<Answer> Answers { get; set; }
        public bool Result { get; set; }
        public int Score { get; set; }

    }
}
