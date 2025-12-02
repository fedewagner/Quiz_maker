namespace Quiz_maker;

public class SetOfQuestionsClass
{
    
        public string? Question;
        public int CorrectAnswer; //from 1 to 4

        public Dictionary<int, string?> dictionaryOfAnswers = new Dictionary<int, string?>();
        
        public void PopulateTheQuestionsAndAnswers(string? questionInput,string? answer1Input,string? answer2Input,string? answer3Input,string? answer4Input,int correctAnswerInput) 
        {
                Question =  questionInput;
                dictionaryOfAnswers[1] = answer1Input;
                dictionaryOfAnswers[2] = answer2Input;
                dictionaryOfAnswers[3] = answer3Input;
                dictionaryOfAnswers[4] = answer4Input;
                CorrectAnswer = correctAnswerInput; 
        
        }
        
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