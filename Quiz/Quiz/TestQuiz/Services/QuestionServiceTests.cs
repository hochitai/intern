using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz.Entities;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Quiz.Services.Tests
{
    [TestClass()]
    public class QuestionServiceTests
    {
        // Check answer of question type is choice
        [TestMethod()]
        public void CheckAnwserChoiceTest()
        {
            // Example answer:
            // Question: "What is the highest single score you can receive on a short answer response question?"
            // 4 (true)
            // 3
            // 2
            // 1

            // Arrange
            var question = new Question()
            {
                Id = 1,
                TypeId = 1,
                Content = "What is the highest single score you can receive on a short answer response question?"
            };

            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    QuestionId = 1,
                    Content = "4"
                }
            };
            // Answer 1
            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    QuestionId = 1,
                    Content = "4"
                }
            };

            // Answer 2
            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Id = 2,
                    QuestionId = 1,
                    Content = "3"
                }
            };

            // action
            var result1 = QuestionService.CheckAnwser(question, answers, answerOfUsers1);
            var result2 = QuestionService.CheckAnwser(question, answers, answerOfUsers2);

            // assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);

        }

        // Check answer of question type is multi choice
        [TestMethod()]
        public void CheckAnwserMultiChoiceTest()
        {
            // Example answer:
            // Question: "Which of the following are potential benefits\r\nof Artificial Intelligence (AI)?"
            // A. Automation of repetitive tasks (True)
            // B. Improved decision-making (True)
            // C. Enhanced data security
            // D. Increased human creativity
            // E. Reduction of employment opportunities

            // Arrange
            var question = new Question()
            {
                Id = 2,
                TypeId = 2,
                Content = "Which of the following are potential benefits\r\nof Artificial Intelligence (AI)?"
            };

        var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    QuestionId = 2,
                    Content = "Automation of repetitive tasks",
                    Result = 1
                },
                new Answer()
                {
                    Id= 2,
                    QuestionId= 2,
                    Content = "Improved decision-making",
                    Result = 1
                }
            };

            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 2,
                    QuestionId= 2,
                    Content = "Improved decision-making",
                    Result = 1
                },
                new Answer()
                {
                    Id = 1,
                    QuestionId = 2,
                    Content = "Automation of repetitive tasks",
                    Result = 1
                },
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 2,
                    QuestionId= 2,
                    Content = "Improved decision-making",
                    Result = 1
                },
                new Answer()
                {
                    Id = 3,
                    QuestionId = 2,
                    Content = "Enhanced data security",
                    Result = 1
                },
            };

            // Action
            var result1 = QuestionService.CheckAnwser(question, answers, answerOfUsers1);
            var result2 = QuestionService.CheckAnwser(question, answers, answerOfUsers2);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        // Check answer of question type is multi choice with order
        [TestMethod()]
        public void CheckAnwserMultiChoiceWithOrderTest()
        {
            // Example answer:
            // Question: "Which of the following are potential benefits\r\nof Artificial Intelligence (AI)?"
            // A. Automation of repetitive tasks (True) - 1
            // B. Improved decision-making (True) - 2
            // C. Enhanced data security
            // D. Increased human creativity
            // E. Reduction of employment opportunities

            // Arrange
            var question = new Question()
            {
                Id = 3,
                TypeId = 3,
                Content = "Which of the following are potential benefits\r\nof Artificial Intelligence (AI)?"
            };

            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    QuestionId = 2,
                    Content = "Automation of repetitive tasks",
                    Result = 1
                },
                new Answer()
                {
                    Id= 2,
                    QuestionId= 2,
                    Content = "Improved decision-making",
                    Result = 2
                }
            };

            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 2,
                    QuestionId= 2,
                    Content = "Improved decision-making",
                    Result = 2
                },
                new Answer()
                {
                    Id = 1,
                    QuestionId = 2,
                    Content = "Automation of repetitive tasks",
                    Result = 1
                },
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 2,
                    QuestionId= 2,
                    Content = "Improved decision-making",
                    Result = 2
                },
                new Answer()
                {
                    Id = 3,
                    QuestionId = 2,
                    Content = "Enhanced data security",
                    Result = 3
                },
            };

            // Action
            var result1 = QuestionService.CheckAnwser(question, answers, answerOfUsers1);
            var result2 = QuestionService.CheckAnwser(question, answers, answerOfUsers2);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        // Check answer of question type is writing
        [TestMethod()]
        public void CheckAnwserWrittingTest()
        {
            // Question: "The whole country was ______ with forests and swamps. The ______  part of it was very misty and cold."
            // Correct Answer:
            // surrounded 1
            // covered 1
            // greater 2
            // northern 2

            // Arrange
            var question = new Question()
            {
                Id = 4,
                TypeId = 4,
                Content = "The whole country was ______ with forests and swamps. The ______  part of it was very misty and cold."
            };

            var answers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    QuestionId = 4,
                    Content = "surrounded",
                    Result = 1,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Id = 2,
                    QuestionId = 4,
                    Content = "covered",
                    Result = 1,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Id = 3,
                    QuestionId = 4,
                    Content = "greater",
                    Result = 2,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Id = 4,
                    QuestionId = 4,
                    Content = "northern",
                    Result = 2,
                    OptionType = "2InM"
                },
            };

            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    QuestionId = 4,
                    Content = "surrounded",
                    Result = 1,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    QuestionId = 4,
                    Content = "greater",
                    Result = 2,
                    OptionType = "2InM"
                },
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    QuestionId = 4,
                    Content = "surrounded",
                    Result = 2,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    QuestionId = 4,
                    Content = "greater",
                    Result = 1,
                    OptionType = "2InM"
                },
            };

            var answerOfUsers3 = new List<Answer>()
            {
                new Answer()
                {
                    QuestionId = 4,
                    Content = "greater",
                    Result = 2,
                    OptionType = "2InM"
                }
            };

            // Action
            var result1 = QuestionService.CheckAnwser(question, answers, answerOfUsers1);
            var result2 = QuestionService.CheckAnwser(question, answers, answerOfUsers2);
            var result3 = QuestionService.CheckAnwser(question, answers, answerOfUsers3);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

    }
}