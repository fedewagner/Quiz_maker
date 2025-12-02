namespace Quiz_maker;

public class SetOfQuestions
{
    
        public string Question;
        public string Answer_1;
        public string Answer_2;
        public string Answer_3;
        public string Answer_4;
        public int CorrectAnswer; //from 1 to 4

        public Dictionary<int, string> dictionaryOfAnswers = new Dictionary<int, string>();

        public void PopulateAnswer(
                string string_1,
                string string_2,
                string string_3,
                string string_4,
                int correct_answer)
        {
                
                dictionaryOfAnswers[1] = string_1;
                dictionaryOfAnswers[2] = string_2;
                dictionaryOfAnswers[3] = string_3;
                dictionaryOfAnswers[4] = string_4;
                
                CorrectAnswer = correct_answer;
                
        }

        
}