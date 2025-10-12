using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float startTime;
    public TextMeshProUGUI timerText;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float totalTime = Time.time - startTime;
        PlayerPrefs.SetFloat("FinishTime", totalTime);
        timerText.text = totalTime.ToString("F1");
    }
}
