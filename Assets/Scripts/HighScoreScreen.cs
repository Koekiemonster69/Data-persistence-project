using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScreen : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> textFields;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < textFields.Count; i++)
        {
            textFields[i].text = SaveManager.Instance.CurrentHighScores[i].Username + " : "
                + SaveManager.Instance.CurrentHighScores[i].Score;
        }
    }
}
