using Access.Primitives.IO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
	class CreateQuestionAdapter : Adapter<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult>
	{
        public override Task PostConditions(CreateQuestionCmd cmd, CreateQuestionResult.ICreateQuestionResult result, object state)
        {
            return Task.CompletedTask;
        }

        public override async Task<CreateQuestionResult.ICreateQuestionResult> Work(CreateQuestionCmd cmd, object state, object dependencies)
        {
            var idQuestion = new CreateQuestionCmd()
            {
                QuestionId = cmd.QuestionId
            };
            var title = new CreateQuestionCmd()
            {
                Title = cmd.Title
            };
            var tags = new CreateQuestionCmd()
            {
                Tags = cmd.Tags
            };

            var questionWriteContext = (QuestionWriteContext)state;
            if (!questionWriteContext.Questions.Any(p => p.Title.Equals(cmd.Title)))
                return new CreateQuestionResult.QuestionNotPublished($"Question with title {cmd.Title} already exist!");

            var question = questionWriteContext.Questions.First(p => p.Title.Equals(p.Title));

            return new CreateQuestionResult.QuestionPublished(Guid.Parse(idQuestion.ToString()), title.ToString(), tags.ToString());
        }
    }
}
