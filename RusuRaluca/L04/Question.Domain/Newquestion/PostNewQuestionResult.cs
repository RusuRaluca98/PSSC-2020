using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using System.Linq;

namespace Question.Domain.PostNewQuestionWorkflow
{
    [AsChoice]
    public static partial class PostNewQuestionResult
    {
        public interface IPostNewQuestionResult { }                
        public class QuestionPosted : IPostNewQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Category { get; private set; }
            public string Body { get; private set; }
            public string Tags { get; private set; }
            public string Topic { get; private set; }
            public QuestionPosted(Guid questionId, string title, string category, string body, string tags, string topic)              
            {
                QuestionId = questionId;
                Title = title;
                Category = category;
                Body = body;
                Tags = tags;
                Topic = topic;
            }
        }
        public class QuestionNotPosted : IPostNewQuestionResult                                       
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        public class QuestionValidationFailed : IPostNewQuestionResult          
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
