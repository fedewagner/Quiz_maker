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
            SetOfQuestions_Class questionClassSet1 = new SetOfQuestions_Class();
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
                UI_Methods.AskUserTheQuestionsAndAnswers(questionClassSet1);
                
                //TBD handle null cases

            }
            
            //TBD a logic to go into PLAYING MODE, for now I force it manually
            gameModus = Constants.PLAYING_MODE_STRING;

            if (gameModus == Constants.PLAYING_MODE_STRING)
            {
                //Things to be done for playing
                    
                //print first set
                questionClassSet1.PrintQuestionAndPossibleAnswers();
                    
                //TBD Read user answer
                
                //TBD Compare user's answer with the correct one
                
                //TBD provide result of the comparison
                
                //TBD add score to user's score variable
                
                //TBD go on with mode set's of questions
            }
        }
    }
}