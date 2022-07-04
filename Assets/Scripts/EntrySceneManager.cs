using UnityEngine.SceneManagement;
using UnityEngine;

public class EntrySceneManager : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
