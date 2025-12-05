namespace Quiz_maker;

public class Logic

{
    public static bool CheckUsersAnswer(int userGuess, QuestionsAndAnswers questions)
    {
        bool correctAnswer = false;

        if (questions.CorrectAnswer == userGuess)
        {
            correctAnswer = true;
        }
        else
        {
            correctAnswer = false;
        }

        return correctAnswer;
    }

    public static int AddWinningScoreForUser(bool correctAnswer, int userScore)
    {
        if (correctAnswer)
        {
            userScore += Constants.WINNING_DELTA;
        }
        return userScore;
    }

    public static int PickOneRandomSet(List<QuestionsAndAnswers> questionsAndAnswersSet)
    {
        Random random = new Random();
        
        //random generation
        int randomKey = random.Next(0, questionsAndAnswersSet.Count ); //+1 is to include also the max value as an option in the random function
        
        return randomKey;
    }

}