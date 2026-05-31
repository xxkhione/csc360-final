namespace MasterMindLibrary.Factories
{
    public abstract class CodeFactory
    {
        public abstract IAnswerGenerator CreateGenerator();
    }
}