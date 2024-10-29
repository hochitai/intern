using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int QuestionId { get; set; }
        public int Result { get; set; }
        public string OptionType { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Answer other)
            {
                return this.Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
