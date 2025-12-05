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
    
    public static void AskUserTheQuestionsAndAnswers(QuestionsAndAnswers questions)
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

        questions.PopulateTheQuestionsAndAnswers(questionInput, answer1Input, answer2Input, answer3Input, answer4Input, correctAnswerInput);

    }

    public static int ReadUserAnswerGuess(QuestionsAndAnswers questions)
    {
        int userAnswer;
        while (true)
        {
            Console.Write($"Enter your answer selection (from 1 to {questions.dictionaryOfAnswers.Count}): ");
            string? input = Console.ReadLine(); // leer string? porque puede ser null

            // 1. validate number
            if (!int.TryParse(input, out userAnswer))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            // 2. validate that the selection is between 1 and the max value
            int max = questions.dictionaryOfAnswers.Count;

            if (userAnswer < 1 || userAnswer > max)
            {
                Console.WriteLine($"Please choose a number between 1 and {max}");
                continue;
            }
            // 3. if all valid then go out
            break;
        }

        Console.WriteLine($"You selected option {userAnswer}");

        return userAnswer;

    }

    public static void InformUserAboutAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            Console.WriteLine("Well done, correct answer!");
        }
        else
        {
            Console.WriteLine("Incorrect answer!");
        }
    }

    public static void PrintUsersScore(int userScore)
    {
        Console.WriteLine($"Your score is currently {userScore} points!");
    }
    
}