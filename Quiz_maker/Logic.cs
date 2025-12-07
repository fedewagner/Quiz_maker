using System.Xml.Serialization;

namespace Quiz_maker;

public class Logic

{
    public static bool CheckUsersAnswer(int userGuess, QuestionsAndAnswers questions)
    {
        bool correctAnswer = false;

        if (questions.CorrectAnswer == userGuess)
        {
            correctAnswer = true;
        }
        else
        {
            correctAnswer = false;
        }

        return correctAnswer;
    }

    public static int AddWinningScoreForUser(bool correctAnswer, int userScore)
    {
        if (correctAnswer)
        {
            userScore += Constants.WINNING_DELTA;
        }
        return userScore;
    }


    static HashSet<int> usedIndexes = new HashSet<int>();

    public static int PickOneRandomSet(List<QuestionsAndAnswers> list)
    {
        Random random = new Random();
        
        int index;
        do
        {
            index = random.Next(0, list.Count);
        }
        while (usedIndexes.Contains(index));

        usedIndexes.Add(index);

        return index;
        
    }
    
    //Property declaration for Serialise and Deserialise
    private static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
    
    
    public static void SerializeTheList(List<QuestionsAndAnswers> list)
    {
        

    var path = Constants.PATH_FOR_SAVING;

    using (FileStream file = File.Create(path))
    {
        serializer.Serialize(file, list);
    }
    
    }

    public static List<QuestionsAndAnswers>? DeserializeTheList(string difficulty)
    {
        string path = null;

        switch (difficulty)
        {
            case Constants.DIFFICULTY_EASY:
                path = Constants.PATH_EASY; ;
                break;
            case Constants.DIFFICULTY_NORMAL:
                path = Constants.PATH_NORMAL;
                break;
            case Constants.DIFFICULTY_HARD:
                path = Constants.PATH_HARD;
                break;

        }
        

        List<QuestionsAndAnswers> deserializedList = null;

        if (path != null)
            using (FileStream file = File.OpenRead(path))
            {
                deserializedList = serializer.Deserialize(file) as List<QuestionsAndAnswers>;
            }

        return deserializedList;
    }
    
    
    
}