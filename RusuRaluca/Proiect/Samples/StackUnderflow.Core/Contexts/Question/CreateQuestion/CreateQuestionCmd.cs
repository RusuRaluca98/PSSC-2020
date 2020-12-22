using System;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
	public class CreateQuestionCmd
	{
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Tags { get; set; }
        public CreateQuestionCommand() { }
        public CreateQuestionCommand(int questionId, string title, string tags)
        {
            QuestionId = questionId;
            Title = title;
            Tags = tags;
        }
    }
}
