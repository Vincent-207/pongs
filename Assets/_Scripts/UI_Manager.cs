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

    public void loadSceneIndex(int sceneIndex)
    {
        if(sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Scene index incorrect, aborting transisiton!");
            return;
        }

        SceneManager.LoadScene(sceneIndex);
    }

    public void loadPreviousGame()
    {
        SceneManager.LoadScene(GameInfo.gameSceneIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
