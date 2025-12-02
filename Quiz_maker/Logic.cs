namespace Quiz_maker;

public class Logic

{
    public static bool CheckUsersAnswer(int userGuess, SetOfQuestionsClass setOfQuestions)
    {
        bool correctAnswer = false;

        if (setOfQuestions.CorrectAnswer == userGuess)
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

}