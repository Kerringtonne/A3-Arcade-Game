using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        Debug.Log("You Win!");
        // show win, load next level, etc
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // show lose screen, restart, etc
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            Win();
        }
    }

}
