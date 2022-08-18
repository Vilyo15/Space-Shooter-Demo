using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "HighScoreManager", menuName = "ScriptableObjects/HighScoreScriptableObject", order = 1)]
public class HighScoreScriptableObject : ScriptableObject
{
     private string filePath;

    [SerializeField]
    private string fileName = "highScores";

    [SerializeField]
    private int highScoresCount = 5;

    [SerializeField]
    private int[] highScores;

    private string FilePath
    {
        get
        {
            if (string.IsNullOrEmpty(filePath))
                filePath = Path.Combine(Application.persistentDataPath, fileName);
            return filePath;
        }
    }

    public int HighScoresCount
    {
        get { return highScoresCount; }
    }

    public float this[int i]
    {
        get { return highScores[i]; }
    }

    public void SubmitHighScore(int highScore = 10000)
    {
        if (highScores == null)
            highScores = new int[HighScoresCount];

        int newHighScoreIndex = -1;
        for (int i = 0; i < highScores.Length; i++)
        {
            if (highScore >= highScores[i])
            {
                newHighScoreIndex = i;
                break;
            }
        }
        if (newHighScoreIndex >= 0)
        {
            for (int i = highScores.Length - 1; i > newHighScoreIndex; i--)
            {
                Debug.Log(highScores[i]);
                Debug.Log(highScores[i - 1]);
                highScores[i] = highScores[i - 1];
            }
            highScores[newHighScoreIndex] = highScore;
        }
    }

    public void Save()
    {
        File.WriteAllText(FilePath, JsonUtility.ToJson(this));
    }

    public void Load()
    {
        string path = Path.Combine(Application.persistentDataPath, "highScores");
            
        if (File.Exists(FilePath))
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(FilePath), this);
        }
        if (highScores.Length < highScoresCount)
            highScores = new int[highScoresCount];
    }
}

