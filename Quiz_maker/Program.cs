using System.Reflection.Metadata.Ecma335;

namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI_Methods.WelcomeUser();
            
            UI_Methods.ExplainUserTheModi();
            
            string? gameModus = UI_Methods.CheckUserKeyInputForGameModus();
            
            //Object definition
            //define the first SetOfQuestions
            QuestionsAndAnswers questionAndAnswersSet1 = new QuestionsAndAnswers();
            //TBD  UI_Methods.CreateASetOfQuestions() for more that one set with concat "_i" for different names?


            if (gameModus != null)
            {
                //Continue
            }
            
            if (gameModus == Constants.WRITING_MODE_STRING)
            {
                //Things to be done for writing the questions
                UI_Methods.WelcomeToWritingMode();
                
                //populate method, where the questions & answers are asked to the user.
                UI_Methods.AskUserTheQuestionsAndAnswers(questionAndAnswersSet1);
                
                //TBD handle null cases

            }
            
            //TBD a logic to go into PLAYING MODE, for now I force it manually
            gameModus = Constants.PLAYING_MODE_STRING;

            if (gameModus == Constants.PLAYING_MODE_STRING)
            {
                //Things to be done for playing
                    
                //print first set
                questionAndAnswersSet1.PrintQuestionAndPossibleAnswers();
                
                //Read user answer
                int answerGuess = UI_Methods.ReadUserAnswerGuess(questionAndAnswersSet1);

                //Compare user's answer with the correct one
                bool correctAnswer = Logic.CheckUsersAnswer(answerGuess, questionAndAnswersSet1);
                
                //Provide result of the comparison
                UI_Methods.InformUserAboutAnswer(correctAnswer);

                //Add score to user's score variable
                int userScore = 0;
                userScore = Logic.AddWinningScoreForUser(correctAnswer, userScore);
                UI_Methods.PrintUsersScore(userScore);

                //TBD go on with mode set's of questions
            }
        }
    }
}