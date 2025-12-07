namespace Quiz_maker;

public class UI_Methods
{
    public static void WelcomeUser()
    {
        //give info to user
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to the Quiz Maker!");
        Console.WriteLine("You'll be able to answer 10 Questions!");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("First you'll be able to preload general questions, otherwise, you can create your own set of questions and answers in the writing mode");
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
    
    
    // TODO: Remove this unused method
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
    
    public static QuestionsAndAnswers AskUserTheQuestionsAndAnswers(QuestionsAndAnswers questionsAndAnswersSet)
    {
        Console.WriteLine("What is the Question you would like to use for this set:");
        string? questionInput = Console.ReadLine();

        for (int i = 1; i <= Constants.AMOUNT_OF_POSSIBLE_ANSWERS; i++)
        {
            Console.WriteLine($"What is the possible answer {i}?");
            string? answerInput = Console.ReadLine();
            questionsAndAnswersSet.PossibleAnswers.Add(answerInput);;
        }
        
        Console.WriteLine("Which possible answer is the correct? (please indicate an integer)");
        int correctAnswerInput = Convert.ToInt32(Console.ReadLine());

        questionsAndAnswersSet = PopulateTheQuestionsAndAnswers(questionInput, questionsAndAnswersSet.PossibleAnswers , correctAnswerInput, questionsAndAnswersSet);
        
        return questionsAndAnswersSet;

    }
    
    public static QuestionsAndAnswers PopulateTheQuestionsAndAnswers(string? questionInput,List<string?> possibleAnswers,int correctAnswerInput, QuestionsAndAnswers questionsAndAnswersSet) 
    {
        
        questionsAndAnswersSet.Question =  questionInput;
        
        questionsAndAnswersSet.PossibleAnswers = possibleAnswers;
        
        questionsAndAnswersSet.CorrectAnswer = correctAnswerInput; 
        
        return questionsAndAnswersSet;
        
    }
    
    public static void PrintQuestionAndPossibleAnswers(QuestionsAndAnswers questionsAndAnswersSet)
    {
        Console.WriteLine("The question is:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(questionsAndAnswersSet.Question);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("And the possible answer are:");
        Console.ForegroundColor = ConsoleColor.Blue;
        
        for (int j = 0; j < questionsAndAnswersSet.PossibleAnswers.Count; j++)
        {
            Console.WriteLine($"{j + 1}. {questionsAndAnswersSet.PossibleAnswers[j]}");
        }
        Console.ForegroundColor = ConsoleColor.Gray;

        
    }

    public static int ReadUserAnswerGuess(QuestionsAndAnswers questions)
    {
        int userAnswer;
        while (true)
        {
            Console.Write($"Enter your answer selection (from 1 to {Constants.AMOUNT_OF_POSSIBLE_ANSWERS}): ");
            string? input = Console.ReadLine(); // leer string? porque puede ser null

            // 1. validate number
            if (!int.TryParse(input, out userAnswer))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            // 2. validate that the selection is between 1 and the max value
            int max = Constants.AMOUNT_OF_POSSIBLE_ANSWERS;

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Well done, correct answer!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect answer!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }

    public static void PrintUsersScore(int userScore)
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Your score is {userScore} points!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void ShowAmountOfQuestionsAndAnswersSetStored(List<QuestionsAndAnswers> questionsAndAnswersList)
    {
        Console.WriteLine($"The amount of stored set is: {questionsAndAnswersList.Count}");
    }

    public static string CheckIfUserWantsToPlayAlready()
    {
        //Read Key Method
        string selection;
        string? currentMode = null;
        
        do
        {
            Console.WriteLine(
                $"Please press ´{Constants.KEY_FOR_PLAYING}´ for playing or ´{Constants.KEY_FOR_WRITING}´ adding more questions sets.");
            
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!(selection == Constants.KEY_FOR_PLAYING || selection == Constants.KEY_FOR_WRITING))
            {
                Console.WriteLine($"Please press ´{Constants.KEY_FOR_PLAYING}´ for playing or ´{Constants.KEY_FOR_WRITING}´ adding more questions sets.");
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
    
    public static bool ReadYesOrNo(string question)
    {
        //Read Key Method
        string selection;
        bool isAfirmativeAnswer = false;
        
        //TBD Improve the Yes and No in separate methods to be reused. Include "NoValid" as a string to be used
        
        do
        {
            Console.WriteLine(question);
            
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!(selection == Constants.KEY_FOR_YES || selection == Constants.KEY_FOR_NO))
            {
                Console.WriteLine(question);
            }
        } while (!(selection == Constants.KEY_FOR_YES || selection == Constants.KEY_FOR_NO) ); //repeat if the key is not valid
        
        return Constants.KEY_FOR_YES == selection;
    }

    public static void InformAboutSerialisedFiles(string changeStatus)
    {
        Console.WriteLine($"Your List with Q&A was {changeStatus}!");
    }

    public static void InformNumberOfQuestionsLeft(int questionsAsked)
    {
        Console.WriteLine($"You still have {Constants.TOTAL_QUESTIONS_ASKED - questionsAsked} questions left!");
    }
    
    public static string SelectGameDifficulty(string question)
    {
        //Read Key Method
        string selection;
        string difficulty = null;
        
        //TBD Improve the Yes and No in separate methods to be reused. Include "NoValid" as a string to be used
        
        do
        {
            Console.WriteLine(question);
            
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!(selection == Constants.KEY_FOR_EASY || selection == Constants.KEY_FOR_NORMAL || selection == Constants.KEY_FOR_HARD))
            {
                Console.WriteLine(question);
            }
        } while (!(selection == Constants.KEY_FOR_EASY || selection == Constants.KEY_FOR_NORMAL || selection == Constants.KEY_FOR_HARD)); //repeat if the key is not valid

        switch (selection)
        {
            case Constants.KEY_FOR_EASY:
                difficulty = Constants.DIFFICULTY_EASY;
                break;
            case Constants.KEY_FOR_NORMAL:
                difficulty = Constants.DIFFICULTY_NORMAL;
                break;
            case Constants.KEY_FOR_HARD:
                difficulty = Constants.DIFFICULTY_HARD;
                break;
        }
        
        return difficulty;
    }



}