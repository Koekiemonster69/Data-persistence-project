using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreScreen : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> textFields;
    // Start is called before the first frame update
    void Start()
    {
        if (SaveManager.Instance != null)
        {
            for (int i = 0; i < textFields.Count; i++)
            {
                if (i < SaveManager.Instance.CurrentHighScores.Count)
                {
                    textFields[i].text = SaveManager.Instance.CurrentHighScores[i].Username + " : "
    + SaveManager.Instance.CurrentHighScores[i].Score;
                }
                else
                {
                    textFields[i].text = "Nobody : 0";
                }
            }
        }
        else
        {
            foreach (TextMeshProUGUI textField in textFields)
                textField.text = "";
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
