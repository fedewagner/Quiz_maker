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
            Logic.SetOfQuestions question_1 = new Logic.SetOfQuestions();

            if (gameModus != null)
            {
                //Continue
            }
            
            if (gameModus == Constants.WRITING_MODE_STRING)
            {
                //Things to be done for writing the questions
                UI_Methods.WelcomeToWritingMode();
                    
                    
                //Manual population of the first set
                question_1.Question = "What color has the sky?";
                question_1.Answer_1 = "Blue";
                question_1.Answer_2 = "Green";
                question_1.Answer_3 = "Transparent";
                question_1.Answer_4 = "No color";
                question_1.CorrectAnswer = 1;

            }
            
            //goes into PLAYING MODE
            gameModus = Constants.PLAYING_MODE_STRING;

            if (gameModus == Constants.PLAYING_MODE_STRING)
            {
                //Things to be done for playing
                    
                //print first set
                UI_Methods.PrintQuestionAndPosibleAnswers(question_1);
                    
                //Read user answer
            }
            
            
            
            
        }
    }
}