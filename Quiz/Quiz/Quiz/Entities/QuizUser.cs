using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    internal class QuizUser
    {
        public int Id { get; set; }
        public int QuizQuestionId {  get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public int Score { get; set; }
    }
}
