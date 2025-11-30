namespace Quiz_maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI_Methods.WelcomeUser();
            
            UI_Methods.ExplainUserTheModi();
            
            string? gameModus = UI_Methods.CheckUserKeyInputForGameModus();

            switch (gameModus)
            {
                case Constants.WRITING_MODE_STRING:
                {    
                    //Things to be done for writing the questions
                    UI_Methods.WelcomeToWritingMode();
                    break;
                }
                
                case Constants.PLAYING_MODE_STRING:
                {    
                    //Things to be done for playing
                    break;
                }
            }
            
        }
    }
}