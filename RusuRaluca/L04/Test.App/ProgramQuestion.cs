using Question.Domain.PostNewQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using static Question.Domain.PostNewQuestionWorkflow.PostNewQuestionResult;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            var cmd = new NewQuestioncmd("Databinding Not working inside dynamic fature module", "I have been recently working on the Dynamic Feature Module, inside that Databinding is not working at all and giving runtime error that cannot find class.", "android,android-databinding");
            var result = PostNewQuestion(cmd);
            result.Match(
                    ProcessQuestionPosted,
                    ProcessQuestionNotPosted,
                    ProcessInvalidQuestion
                );

            Console.ReadLine();
        }
        private static IPostNewQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }
        private static IPostNewQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotCreatedResult)
        {
            Console.WriteLine($"Question not posted: {questionNotCreatedResult.Reason}");
            return questionNotCreatedResult;
        }
        private static IPostNewQuestionResult ProcessQuestionPosted(QuestionPosted question)
        {
            var user = new UserLogin("user1", "user@gmail.com");
            Console.WriteLine($"Question {question.QuestionId}");
            Console.WriteLine($"Confirmation about posting question {user.EmailAdress}");
            return question;
        }
        public static IPostNewQuestionResult PostNewQuestion(PostNewQuestionCmd postNewQuestionCommand)
        {
            if (string.IsNullOrWhiteSpace(postNewQuestionCommand.Title))
            {
                return new QuestionNotPosted("Please insert a title!");
            }
            if (string.IsNullOrWhiteSpace(postNewQuestionCommand.Body))
            {
                var errors = new List<string>() { "Invalid description of question!" };
                return new QuestionValidationFailed(errors);
            }

            var questionId = Guid.NewGuid();
            var result = new QuestionPosted(questionId, postNewQuestionCommand.Title, postNewQuestionCommand.Tags, postNewQuestionCommand.Body);

            return result;
        }
    }
}

