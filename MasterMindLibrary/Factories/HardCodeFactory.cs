namespace MasterMindLibrary.Factories
{
    public class HardCodeFactory : CodeFactory
    {
        public override IAnswerGenerator CreateGenerator()
        {
            return new HardAnswerGenerator();
        }
    }
}