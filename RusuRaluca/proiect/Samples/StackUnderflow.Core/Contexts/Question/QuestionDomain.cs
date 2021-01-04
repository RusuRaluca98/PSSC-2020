using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion;
using System;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
	public static class QuestionDomain
	{
		public static Port<CreateQuestionResult.ICreateQuestionResult> CreateQuestion(int questionId, string title, string tags)
            => NewPort<CreateQuestionCmd, CreateQuestionResult.ICreateQuestionResult>(new CreateQuestionCmd(questionId, title, tags));

        private static Port<T2> NewPort<T1, T2>(T1 createQuestionCmd)
        {
            throw new NotImplementedException();
        }
    }

}
