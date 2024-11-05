using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz.DataStore;
using Quiz.Entities;
using Quiz.Enum;
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
        private QuestionStore questionStore;
        private QuestionService questionService;

        [TestInitialize]
        public void TestInitialize()
        {
            questionStore = new QuestionStore();
            questionService = new QuestionService(questionStore);
        }

        // Check answer of question type is choice
        [TestMethod()]
        public void CheckAnwserChoiceTest()
        {
            // Arrange
            // question id of question type is choice in store
            var questionId = 1;
            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                }
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Id = 2,
                }
            };

            // action
            var result1 = questionService.CheckAnwser(questionId, answerOfUsers1);
            var result2 = questionService.CheckAnwser(questionId, answerOfUsers2);

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
            // question id of question type is multi choice in store
            var questionId = 3;
            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 7,
                    Result = 1
                },
                new Answer()
                {
                    Id = 9,
                    Result = 1
                },
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 7,
                    Result = 1
                },
                new Answer()
                {
                    Id = 8,
                    Result = 1
                },
            };

            // Action
            var result1 = questionService.CheckAnwser(questionId, answerOfUsers1);
            var result2 = questionService.CheckAnwser(questionId, answerOfUsers2);

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
            // question id of question type is multi choice with order in store
            var questionId = 4;
            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 12,
                    Result = 2
                },
                new Answer()
                {
                    Id = 11,
                    Result = 1
                },
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Id= 12,
                    Result = 2
                },
                new Answer()
                {
                    Id = 13,
                    Result = 1
                },
            };

            // Action
            var result1 = questionService.CheckAnwser(questionId, answerOfUsers1);
            var result2 = questionService.CheckAnwser(questionId, answerOfUsers2);

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
            // question id of question type is writting in store
            var questionId = 6;

            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Content = "Inherite",
                    Result = 1,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Content = "Override",
                    Result = 2,
                    OptionType = "2InM"
                },
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Content = "Inherite",
                    Result = 2,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Content = "Override",
                    Result = 1,
                    OptionType = "2InM"
                },
            };

            var answerOfUsers3 = new List<Answer>()
            {
                new Answer()
                {
                    Content = "Override",
                    Result = 2,
                    OptionType = "2InM"
                }
            };

            // Action
            var result1 = questionService.CheckAnwser(questionId, answerOfUsers1);
            var result2 = questionService.CheckAnwser(questionId, answerOfUsers2);
            var result3 = questionService.CheckAnwser(questionId, answerOfUsers3);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod()]
        public void CheckChoiceAnswerTest()
        {
            // Arrange
            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                }
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Id = 2,
                }
            };

            var trueAnswers = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                }
            };

            // Action
            var result1 = questionService.CheckChoiceAnswer(answerOfUsers1, trueAnswers);
            var result2 = questionService.CheckChoiceAnswer(answerOfUsers2, trueAnswers);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod()]
        public void CheckChoiceAnswer2Test()
        {
            // Arrange
            var answerOfUsers1 = new List<Answer>()
            {
                new Answer()
                {
                    Content = "Inherite",
                    Result = 1,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Content = "Override",
                    Result = 2,
                    OptionType = "2InM"
                },
            };

            var answerOfUsers2 = new List<Answer>()
            {
                new Answer()
                {
                    Content = "Inherite",
                    Result = 2,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Content = "Override",
                    Result = 1,
                    OptionType = "2InM"
                },
            };

            var trueAnswers = new List<Answer>()
            {
                new Answer()
                {
                    Content = "Inherite",
                    Result = 1,
                    OptionType = "2InM"
                },
                new Answer()
                {
                    Content = "Override",
                    Result = 2,
                    OptionType = "2InM"
                },
            };

            // Action
            var result1 = questionService.CheckWritingAnswer(answerOfUsers1, trueAnswers);
            var result2 = questionService.CheckWritingAnswer(answerOfUsers2, trueAnswers);

            // Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
    }
}