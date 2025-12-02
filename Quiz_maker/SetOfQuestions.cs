namespace Quiz_maker;

public class SetOfQuestions
{
    
        public string? Question;
        public int CorrectAnswer; //from 1 to 4

        public Dictionary<int, string?> dictionaryOfAnswers = new Dictionary<int, string?>();

        public void PopulateAnswer(
                string string_1,
                string string_2,
                string string_3,
                string string_4,
                int correct_answer)
        {
                
                dictionaryOfAnswers[1] = string_1;
                dictionaryOfAnswers[2] = string_2;
                dictionaryOfAnswers[3] = string_3;
                dictionaryOfAnswers[4] = string_4;
                
                CorrectAnswer = correct_answer;
                
        }
        
        public void AskUserTheQuestionsAndAnswers()
        {
                Console.WriteLine("What is the Question you would like to use for this set:");
                string? questionInput = Console.ReadLine();
                Console.WriteLine("What is the possible answer 1?");
                string? answer1Input = Console.ReadLine();
                Console.WriteLine("What is the possible answer 2?");
                string? answer2Input = Console.ReadLine();
                Console.WriteLine("What is the possible answer 3?");
                string? answer3Input = Console.ReadLine();
                Console.WriteLine("What is the possible answer 4?");
                string? answer4Input = Console.ReadLine();
                Console.WriteLine("Which possible answer is the correct? (please indicate an integer)");
                int correctAnswerInput = Convert.ToInt32(Console.ReadLine());
        
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