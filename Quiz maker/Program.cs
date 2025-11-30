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
            
            //Object
            Logic.SetOfQuestions questionSet_1 = new Logic.SetOfQuestions();

            if (gameModus != null)
            {
                //Continue
            }
            
            if (gameModus == Constants.WRITING_MODE_STRING)
            {
                //Things to be done for writing the questions
                UI_Methods.WelcomeToWritingMode();
                    
                    
                //Manual population of the first set
                questionSet_1.Question = "What color has the sky?";
                questionSet_1.Answer_1 = "Blue";
                questionSet_1.Answer_2 = "Green";
                questionSet_1.Answer_3 = "Transparent";
                questionSet_1.Answer_4 = "No color";
                questionSet_1.CorrectAnswer = 1;

            }
            
            //goes into PLAYING MODE
            gameModus = Constants.PLAYING_MODE_STRING;

            if (gameModus == Constants.PLAYING_MODE_STRING)
            {
                //Things to be done for playing
                    
                //print first set
                UI_Methods.PrintQuestionAndPosibleAnswers(questionSet_1);
                    
                //Read user answer
            }
            
            
            
            
        }
    }
}