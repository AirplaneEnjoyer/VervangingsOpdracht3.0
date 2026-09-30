using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void OnRetryClick()
    {
        SceneManager.LoadSceneAsync("VervangingsOpdracht3.0");
    }
    public void OnStopClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
