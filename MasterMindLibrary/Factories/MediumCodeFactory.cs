namespace MasterMindLibrary.Factories
{
    public class MediumCodeFactory : CodeFactory
    {
        public override IAnswerGenerator CreateGenerator()
        {
            return new MediumAnswerGenerator();
        }
    }
}