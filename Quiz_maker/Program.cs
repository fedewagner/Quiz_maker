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
            QuestionsAndAnswers questionAndAnswersSet_i = new QuestionsAndAnswers();
            
            List<QuestionsAndAnswers> listOfQuestionsAndAnswersSet = new List<QuestionsAndAnswers>();

            if (gameModus != null)
            {
                //Continue
                //TBD implement a control if wrong keys are pressed or remove this if control (if not needed)
            }

            do
            {
                
                //TBD  UI_Methods.CreateASetOfQuestions() for more that one set with concat "_i" for different names?
                
                //TBD once exit writing mode, then implement Serialize Method to save the info in a file

                //TBD once serialised is implemented, write a method to read and load file at the beginning of the program 

                //TBD handle null cases


                //Things to be done for writing the questions
                if (listOfQuestionsAndAnswersSet.Count == 0)
                {
                    UI_Methods.WelcomeToWritingMode();
                }
                
                //populate method, where the questions & answers are asked to the user.
                UI_Methods.AskUserTheQuestionsAndAnswers(questionAndAnswersSet_i);

                //IN_PROGRESS develop a way of storing sets
                listOfQuestionsAndAnswersSet.Add(questionAndAnswersSet_i);
                

                //TBD tell how many QuestionsAndAnswersSet are stored
                UI_Methods.ShowAmountOfQuestionsAndAnswersSetStored(listOfQuestionsAndAnswersSet);

                //TBD if any then ask and append the sets to the list until a key is asked to leave the "WRITING MODE" - decide when to ask
                gameModus = UI_Methods.CheckIfUserWantsToPlayAlready();

            } while (gameModus == Constants.WRITING_MODE_STRING);
            
            //TBD a logic to go into PLAYING MODE, for now I force it manually
            gameModus = Constants.PLAYING_MODE_STRING;

            if (gameModus == Constants.PLAYING_MODE_STRING)
            {
                //Things to be done for playing
                
                //TBD Implement a method to pick one random set of questions and answers
                int randomKey = Logic.PickOneRandomSet(listOfQuestionsAndAnswersSet);

                //print first set
                UI_Methods.PrintQuestionAndPossibleAnswers(listOfQuestionsAndAnswersSet[randomKey]);
                
                //Read user answer
                int answerGuess = UI_Methods.ReadUserAnswerGuess(listOfQuestionsAndAnswersSet[randomKey]);

                //Compare user's answer with the correct one
                bool correctAnswer = Logic.CheckUsersAnswer(answerGuess, listOfQuestionsAndAnswersSet[randomKey]);
                
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