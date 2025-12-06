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
    
    
    public static void SerializeTheList(List<QuestionsAndAnswers> list)
    {
        
    XmlSerializer writer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));

    var path = @"/Users/fedewagner/Documents/Rakete Mentoring/Practice/Quiz maker/ObjectList.xml";

    using (FileStream file = File.Create(path))
    {
        writer.Serialize(file, list);
    }
    
    }

    public static List<QuestionsAndAnswers>? DeserializeTheList(string difficulty)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
        string path = null;

        switch (difficulty)
        {
            case Constants.DIFFICULTY_EASY:
                path = @"/Users/fedewagner/Documents/Rakete Mentoring/Practice/Quiz maker/ObjectList_easy.xml";
                break;
            case Constants.DIFFICULTY_NORMAL:
                path = @"/Users/fedewagner/Documents/Rakete Mentoring/Practice/Quiz maker/ObjectList_normal.xml";
                break;
            case Constants.DIFFICULTY_HARD:
                path = @"/Users/fedewagner/Documents/Rakete Mentoring/Practice/Quiz maker/ObjectList_hard.xml";
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