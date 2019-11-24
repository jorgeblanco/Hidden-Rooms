using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
         Application.OpenURL(webplayerQuitURL);
#else
         Application.Quit();
#endif
    }
}
