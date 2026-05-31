using System.Collections.Generic;

namespace MasterMindLibrary.Factories
{
    public interface IAnswerGenerator
    {
        List<int> GenerateAnswer();
    }
}