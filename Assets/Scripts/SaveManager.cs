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
        public string username;
        public int score;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UsernameFilled()
    {
        Username = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void LoadHighscore()
    {

    }

    public void SaveHighscore()
    {
        string json = JsonUtility.ToJson(CurrentHighScore);

        File.WriteAllText();
    }
}
