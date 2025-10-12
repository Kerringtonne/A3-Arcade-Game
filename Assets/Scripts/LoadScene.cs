using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName = "Scene";
    public float delayTime;

    public void GoToScene()
    {
        StartCoroutine(DelaySceneLoad());
    }

    // Delays loading scene so sound effect can play
    public IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneName()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
