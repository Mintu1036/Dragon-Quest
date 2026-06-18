using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCompletedMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("_MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}