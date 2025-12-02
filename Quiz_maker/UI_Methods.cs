namespace Quiz_maker;

public class UI_Methods
{
    public static void WelcomeUser()
    {
        //give info to user
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to the Quiz Maker!");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("First you'll need to make sure the questions are stored into the App, and then you'll be able to answer them.");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Everytime you get a right answer, you'll get {Constants.WINNING_DELTA} points!!!");
        Console.ForegroundColor = ConsoleColor.Gray;
        }

    public static void ExplainUserTheModi()
    {
        //explain key for playing
        //list amount of questions available
        Console.WriteLine($"If you want to go to WRITE mode (Press {Constants.KEY_FOR_WRITING})!");
        Console.WriteLine($"Otherwise, to play (Press {Constants.KEY_FOR_PLAYING})!");
    }
    
    public static string? CheckUserKeyInputForGameModus()
    {
        string selection;
        string? currentMode = null;
        
        do
        {
            //read key method
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!(selection == Constants.KEY_FOR_PLAYING || selection == Constants.KEY_FOR_WRITING))
            {
                Console.WriteLine($"Please press ´{Constants.KEY_FOR_PLAYING}´ or ´{Constants.KEY_FOR_WRITING}´ ");
            }
        } while (!(selection == Constants.KEY_FOR_PLAYING || selection == Constants.KEY_FOR_WRITING) ); //repeat if the key is not valid

        switch (selection)
        {
            case Constants.KEY_FOR_WRITING:
                currentMode = "WRITE";
                break;
            case Constants.KEY_FOR_PLAYING:
                currentMode = "PLAY";
                break;
        }
        
        return currentMode;
    }
    
    public static void WelcomeToWritingMode()
    {
        Console.WriteLine("Welcome to the Writing Mode!");
        //give info about how to enter the questions
        //give info about how to select the correct answer
        //how to finish the writing mode (select a key for adding one more or another key to close the writing mode => playing mode)
        
    }
    
    
    public static void AskUserTheQuestionsAndAnswers(SetOfQuestions oneSetOfQuestions)
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
        
        oneSetOfQuestions.Question =  questionInput;
        oneSetOfQuestions.dictionaryOfAnswers[1] = answer1Input;
        oneSetOfQuestions.dictionaryOfAnswers[2] = answer2Input;
        oneSetOfQuestions.dictionaryOfAnswers[3] = answer3Input;
        oneSetOfQuestions.dictionaryOfAnswers[4] = answer4Input;
        oneSetOfQuestions.CorrectAnswer = correctAnswerInput; 
        
    }
    
    
    
    public static void PrintQuestionAndPosibleAnswers(SetOfQuestions oneSetOfQuestions)
    {
        Console.WriteLine("The question is:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(oneSetOfQuestions.Question);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("And the possible answer are:");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1. "  + oneSetOfQuestions.dictionaryOfAnswers[1]);
        Console.WriteLine("2. "  + oneSetOfQuestions.dictionaryOfAnswers[2]);
        Console.WriteLine("3. "  + oneSetOfQuestions.dictionaryOfAnswers[3]);
        Console.WriteLine("4. "  + oneSetOfQuestions.dictionaryOfAnswers[4]);    
    }

   
    
    
    
}