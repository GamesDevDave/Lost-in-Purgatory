using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool pausePressed = false;
    public GameObject quitWarning;

    void Start()
    {
        
    }

    public void OnPlayPress()
    {
        SceneManager.LoadScene("Level 1 - Playtest Level", LoadSceneMode.Single);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnOptionsPress() => SceneManager.LoadScene("", LoadSceneMode.Additive);
    public void OnControlsPress() => SceneManager.LoadScene("", LoadSceneMode.Additive);
    public void OnMainMeniuPress() => SceneManager.LoadScene("", LoadSceneMode.Single);
    public void OnQuitPressTwo() => Application.Quit();
    public void OnQuitPressOne()
    {
        quitWarning.SetActive(true);
    }

    public void QuitWarningBack()
    {
        quitWarning.SetActive(false);
    }

    public void OnUnloadScene(int sceneNumber)
    {
        SceneManager.UnloadSceneAsync(sceneNumber);
    }
}
