using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = -1;
        }
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
