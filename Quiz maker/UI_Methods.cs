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
}