using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string[] levels;

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevel(int i)
    {
        SceneManager.LoadScene(levels[i]);
    }
}
