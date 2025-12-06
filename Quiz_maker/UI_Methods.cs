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

        questionsAndAnswersSet = PopulateTheQuestionsAndAnswers(questionInput, answer1Input, answer2Input, answer3Input, answer4Input, correctAnswerInput, questionsAndAnswersSet);
        
        return questionsAndAnswersSet;

    }
    
    public static QuestionsAndAnswers PopulateTheQuestionsAndAnswers(string? questionInput,string? answer1Input,string? answer2Input,string? answer3Input,string? answer4Input,int correctAnswerInput, QuestionsAndAnswers questionsAndAnswersSet) 
    {
        questionsAndAnswersSet.Question =  questionInput;
        questionsAndAnswersSet.PosibleAnswer_1 = answer1Input;
        questionsAndAnswersSet.PosibleAnswer_2 = answer2Input;
        questionsAndAnswersSet.PosibleAnswer_3 = answer3Input;
        questionsAndAnswersSet.PosibleAnswer_4 = answer4Input;
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
        Console.WriteLine("1. "  + questionsAndAnswersSet.PosibleAnswer_1);
        Console.WriteLine("2. "  + questionsAndAnswersSet.PosibleAnswer_2);
        Console.WriteLine("3. "  + questionsAndAnswersSet.PosibleAnswer_3);
        Console.WriteLine("4. "  + questionsAndAnswersSet.PosibleAnswer_4);    
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

    public static string CheckIfWantsToEndTheGame()
    {
        //Read Key Method
        string selection;
        string? wantToEndTheGame = null;
        
        //TBD Improve the Yes and No in separate methods to be reused. Include "NoValid" as a string to be used
        
        do
        {
            Console.WriteLine($"Do you want to end the game? ({Constants.KEY_FOR_YES}/{Constants.KEY_FOR_NO})");
            
            selection = Console.ReadKey(true).KeyChar.ToString().ToLower();

            if (!(selection == Constants.KEY_FOR_YES || selection == Constants.KEY_FOR_NO))
            {
                Console.WriteLine($"Do you want to end the game? ({Constants.KEY_FOR_YES}/{Constants.KEY_FOR_NO})");
            }
        } while (!(selection == Constants.KEY_FOR_YES || selection == Constants.KEY_FOR_NO) ); //repeat if the key is not valid

        switch (selection)
        {
            case Constants.KEY_FOR_YES:
                wantToEndTheGame = "yes";
                break;
            case Constants.KEY_FOR_NO:
                wantToEndTheGame = "no";
                break;
        }
        
        return wantToEndTheGame;

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

        switch (selection)
        {
            case Constants.KEY_FOR_YES:
                isAfirmativeAnswer = true;
                break;
            case Constants.KEY_FOR_NO:
                isAfirmativeAnswer = false;
                break;
        }
        
        return isAfirmativeAnswer;
    }

    public static void InformAboutStoredFile()
    {
        Console.WriteLine("Your List with Q&A was saved!");
    }
    
    public static void InformAboutReadFile()
    {
        Console.WriteLine("Your List with Q&A was read!");
    }

    public static void InformNumberOfQuestionsLeft(int questionsAsked)
    {
        Console.WriteLine($"You still have {Constants.TOTAL_QUESTIONS_ASKED - questionsAsked} questions left!");
    }



}