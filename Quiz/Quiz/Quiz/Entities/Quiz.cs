﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int OwnerId { get; set; }
    }
}
