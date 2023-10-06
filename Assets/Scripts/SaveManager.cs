using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SaveManager : MonoBehaviour
{
    static public SaveManager Instance;

    [SerializeField] TextMeshProUGUI inputField;

    public string Username;

    public List<HighScore> CurrentHighScores;

    private void Awake()
    {
        LoadHighscore();

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartPressed()
    {
        Username = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.js";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            CurrentHighScores = data.HighScores;
            Debug.Log("Highscores found: " + CurrentHighScores.Count);
        }
        

    }

    public void SaveHighscore(int score)
    {
        // Try to add the new Highscore to the list
        CurrentHighScores.Add(new HighScore(Username, score));
        CurrentHighScores.Sort();

        SaveData data = new SaveData();
        data.HighScores = CurrentHighScores;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.js", json);
    }

    [System.Serializable]
    public class HighScore : IComparable
    {
        public string Username;
        public int Score;

        public HighScore(string username, int score)
        {
            Username = username;
            Score = score;
        }

        public int CompareTo(object obj)
        {
            return (obj as HighScore).Score - Score;
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public List<HighScore> HighScores;
    }
}
