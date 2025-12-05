namespace Quiz_maker;

public class QuestionsAndAnswers
{
    
        public string? Question;
        public int CorrectAnswer; //from 1 to 4

        public Dictionary<int, string?> dictionaryOfAnswers = new Dictionary<int, string?>();
        
       
        
        public void PrintQuestionAndPossibleAnswers()
        {
                Console.WriteLine("The question is:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Question);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("And the possible answer are:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. "  + dictionaryOfAnswers[1]);
                Console.WriteLine("2. "  + dictionaryOfAnswers[2]);
                Console.WriteLine("3. "  + dictionaryOfAnswers[3]);
                Console.WriteLine("4. "  + dictionaryOfAnswers[4]);    
        }



        
}