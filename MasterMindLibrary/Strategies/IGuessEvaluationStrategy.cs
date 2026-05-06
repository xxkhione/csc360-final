using System.Collections.Generic;

namespace MasterMindLibrary.Strategies
{
    public interface IGuessEvaluationStrategy
    {
        string EvaluateGuess(List<int> answer, Attempt attempt);
    }
}