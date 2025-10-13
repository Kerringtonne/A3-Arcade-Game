using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalTimeText;

    void Start()
    {
        float time = PlayerPrefs.GetFloat("FinishTime", 0f);
        finalTimeText.text = "Time: " + time.ToString("F2") + "s";
    }

    void Update()
    {
        
    }
}
