using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using System.Linq;


namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    [AsChoice]
	public static partial class CreateQuestionResult
	{
        public interface ICreateQuestionResult { }

        public class QuestionCreated : ICreateQuestionResult
        {
            public int QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Description { get; private set; }
            public string Tags { get; private set; }

            public QuestionCreated(int QuestionId, string Title, string Description, string Tags)
            {
                this.QuestionId = QuestionId;
                this.Title = Title;
                this.Description = Description;
                this.Tags = Tags;
            }
        }

        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string Message { get; }
            public QuestionNotCreated(string message)
            {
                Message = message;
            }
        }

        internal class QuestionPublished : ICreateQuestionResult
        {
            private Guid guid;
            private string v1;
            private string v2;

            public QuestionPublished(Guid guid, string v1, string v2)
            {
                this.guid = guid;
                this.v1 = v1;
                this.v2 = v2;
            }
        }

        internal class QuestionNotPublished : ICreateQuestionResult
        {
            private string v;

            public QuestionNotPublished(string v)
            {
                this.v = v;
            }
        }
    }
}
