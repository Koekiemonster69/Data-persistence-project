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

    public HighScore CurrentHighScore;

    [System.Serializable]
    public class HighScore
    {
        public string Username;
        public int Score;

        public HighScore(string username, int score)
        {
            Username = username;
            Score = score;
        }
    }

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

            CurrentHighScore = JsonUtility.FromJson<HighScore>(json);
        }

    }

    public void SaveHighscore(int score)
    {
        CurrentHighScore = new HighScore(Username, score);

        string json = JsonUtility.ToJson(CurrentHighScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.js", json);
    }
}
