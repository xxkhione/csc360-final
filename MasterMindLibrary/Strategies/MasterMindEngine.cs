using System.Collections.Generic;

namespace MasterMindLibrary.Strategies
{
    public class MasterMindEngine
    {
        private readonly IGuessEvaluationStrategy _guessEvaluationStrategy;

        public MasterMindEngine(IGuessEvaluationStrategy guessEvaluationStrategy)
        {
            _guessEvaluationStrategy = guessEvaluationStrategy;
        }

        public string EvaluateAttempt(List<int> answer, Attempt attempt)
        {
            return _guessEvaluationStrategy.EvaluateGuess(answer, attempt);
        }
    }
}