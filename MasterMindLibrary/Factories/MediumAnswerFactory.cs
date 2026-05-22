namespace MasterMindLibrary.Factories
{
    public class MediumAnswerFactory : IAnswerGenerator
    {
        public list<int> GenerateAnswer()
        {
            List<int> answer = new List<int>();

            for(int pieces = 0; pieces < 6; pieces++)
            {
                answer.Add(pieces);
            }
            Random rand = new Random();
            return answer.OrderBy(piece => rand.Next()).ToList();
        }
    }
}