using System.Collections.Generic;

namespace MasterMindLibrary.Strategies
{
    public class StandardGuessEvaluationStrategy : IGuessEvaluationStrategy
    {
        public string EvaluateGuess(List<int> answer, Attempt attempt)
        {
            int correctPosition = 0;
            int correctColor = 0;

            for (int i = 0; i < answer.Count; i++)
            {
                if (attempt.AttemptList[i] == answer[i])
                {
                    correctPosition++;
                }
                else if (answer.Contains(attempt.AttemptList[i]))
                {
                    correctColor++;
                }
            }
            attempt.CorrectAnswerCount = correctPosition;
            
            return $"{correctPosition} correct position(s), {correctColor} correct color(s)";
        }
    }
}