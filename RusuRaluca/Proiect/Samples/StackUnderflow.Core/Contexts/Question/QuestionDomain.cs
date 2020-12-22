using System;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
	public static class QuestionDomain
	{
		public static Port<CreateQuestionResult.ICreateQuestionResult> CreateQuestion(int questionId, string title, string tags)
			=> NewPort<CreateQuestionCommand, CreateQuestionResult.ICreateQuestionResult>(new CreateQuestionCommand(questionId, title, tags));
	}

}
