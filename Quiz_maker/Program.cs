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
            
            //define the first SetOfQuestions
            SetOfQuestions questionSet1 = new SetOfQuestions();
            // UI_Methods.CreateASetOfQuestions() for more that one set with concat "_i" for different names?


            if (gameModus != null)
            {
                //Continue
            }
            
            if (gameModus == Constants.WRITING_MODE_STRING)
            {
                //Things to be done for writing the questions
                UI_Methods.WelcomeToWritingMode();


                //Object
                
                
                //populate method, where the questions & answers are asked to the user.
                
                UI_Methods.AskUserTheQuestionsAndAnswers(questionSet1);
                

            }
            
            //goes into PLAYING MODE
            gameModus = Constants.PLAYING_MODE_STRING;

            if (gameModus == Constants.PLAYING_MODE_STRING)
            {
                //Things to be done for playing
                    
                //print first set
                UI_Methods.PrintQuestionAndPosibleAnswers(questionSet1);
                    
                //Read user answer
                
                //Compare user's answer with the correct one
                
                //provide result of the comparisson
                
                //add score to user's score varible
                
                //go on with mode set's of quesitons
            }
            
            
            
            
        }
    }
}