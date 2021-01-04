using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using System;
using System.Collections.Generic;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
	public class QuestionWriteContext
	{
        public ICollection<CreateQuestionCmd> Questions { get; }
        public QuestionWriteContext(ICollection<CreateQuestionCmd> questions)
        {
            Questions = questions ?? new List<CreateQuestionCmd>(0);
        }

    }
}
