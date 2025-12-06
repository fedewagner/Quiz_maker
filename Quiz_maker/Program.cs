using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;


namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI_Methods.WelcomeUser();
            
            UI_Methods.ExplainUserTheModi();
            
            string? gameModus = UI_Methods.CheckUserKeyInputForGameModus();
            
            List<QuestionsAndAnswers> listOfQuestionsAndAnswersSet = new List<QuestionsAndAnswers>();

            if (gameModus != null)
            {
                //Continue
                //TBD implement a control if wrong keys are pressed or remove this if control (if not needed)
            }

            do
            {
                //Object definition
                //define the first SetOfQuestions
                QuestionsAndAnswers questionAndAnswersSet_i = new QuestionsAndAnswers();

                //TBD handle null cases


                //Things to be done for writing the questions
                if (listOfQuestionsAndAnswersSet.Count == 0)
                {
                    UI_Methods.WelcomeToWritingMode();
                }
                
                //Populate Set, where the questions & answers are asked to the user.
                questionAndAnswersSet_i = UI_Methods.AskUserTheQuestionsAndAnswers(questionAndAnswersSet_i);

                //List for storing sets
                listOfQuestionsAndAnswersSet.Add(questionAndAnswersSet_i);
                

                //Show how many QuestionsAndAnswersSet are stored
                UI_Methods.ShowAmountOfQuestionsAndAnswersSetStored(listOfQuestionsAndAnswersSet);

                //If any then ask and append the sets to the list until a key is asked to leave the "WRITING MODE" - decide when to ask
                gameModus = UI_Methods.CheckIfUserWantsToPlayAlready();
                
                //TBD once exit writing mode, then implement Serialize Method to save the info in a file

                //TBD once serialised is implemented, write a method to read and load file at the beginning of the program 
                
                

            } while (gameModus == Constants.WRITING_MODE_STRING);
            
            //Serialize

            Logic.SerializeTheList(listOfQuestionsAndAnswersSet);
            
            //Add score to user's score variable
            int userScore = 0;
            
            do  //Things to be done for playing
            {
               

                //Implement a method to pick one random set of questions and answers
                int randomKey = 0;
                randomKey = Logic.PickOneRandomSet(listOfQuestionsAndAnswersSet);

                //print set
                UI_Methods.PrintQuestionAndPossibleAnswers(listOfQuestionsAndAnswersSet[randomKey]);

                //Read user answer
                int answerGuess = UI_Methods.ReadUserAnswerGuess(listOfQuestionsAndAnswersSet[randomKey]);

                //Compare user's answer with the correct one
                bool correctAnswer = Logic.CheckUsersAnswer(answerGuess, listOfQuestionsAndAnswersSet[randomKey]);
                
                
                
                

                //Provide result of the comparison
                UI_Methods.InformUserAboutAnswer(correctAnswer);
                
                userScore = Logic.AddWinningScoreForUser(correctAnswer, userScore);
                UI_Methods.PrintUsersScore(userScore);

                //ask to end the game EndGame
                string wantToEndTheGame = UI_Methods.CheckIfWantsToEndTheGame();

                if (wantToEndTheGame == "yesEndTheGame")
                {
                    break;
                }

            } while (gameModus == Constants.PLAYING_MODE_STRING);
        }
    }
}