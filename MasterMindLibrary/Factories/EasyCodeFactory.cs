namespace MasterMindLibrary.Factories
{
    public class EasyCodeFactory : CodeFactory
    {
        public override IAnswerGenerator CreateGenerator()
        {
            return new EasyAnswerFactory();
        }
    }
}