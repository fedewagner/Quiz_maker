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
            
            List<QuestionsAndAnswers> listOfQuestionsAndAnswersSet = new List<QuestionsAndAnswers>();
            
            //ask for deserialization
            bool wantToReadTheList = UI_Methods.ReadYesOrNo($"Do you want to read the List of Questions and answers? (Y/N)");
            
            string? gameModus;
            bool newListCreatedByUser = false;
            
            if (wantToReadTheList)
            {
                //Deserialize
                listOfQuestionsAndAnswersSet =  Logic.DeserializeTheList();
                UI_Methods.InformAboutSerialisedFiles("read");
                gameModus = Constants.PLAYING_MODE_STRING;
            }
            else
            {
                gameModus = Constants.WRITING_MODE_STRING;
            }
            
            while (gameModus == Constants.WRITING_MODE_STRING)
            {
                //Object definition
                newListCreatedByUser = true;
                
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

            } ;


            if (newListCreatedByUser)
            {
                //ask for serialization
                bool wantToStoreTheList = UI_Methods.ReadYesOrNo($"Do you want to store the List of Questions and answers? (Y/N)");

                if (wantToStoreTheList)
                {
                    //Serialize
                    Logic.SerializeTheList(listOfQuestionsAndAnswersSet);
                    UI_Methods.InformAboutSerialisedFiles("saved");;
                }
            }
            
            
            //Add score to user's score variable and other variables
            int userScore = 0;
            int questionsAsked = 0;
            
            while (gameModus == Constants.PLAYING_MODE_STRING & questionsAsked < Constants.TOTAL_QUESTIONS_ASKED)  //Things to be done for playing
            {
                //Implement a method to pick one random set of questions and answers
                int randomKey = 0;
                questionsAsked += 1;
                
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

                UI_Methods.InformNumberOfQuestionsLeft(questionsAsked);
                UI_Methods.PrintUsersScore(userScore);

            };
            
            
            
            
        }
    }
}