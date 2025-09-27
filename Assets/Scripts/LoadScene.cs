using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName = "Scene";

    public void LoadSceneName()
    {
        SceneManager.LoadScene(sceneName);
    }
}
