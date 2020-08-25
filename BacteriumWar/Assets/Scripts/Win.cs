using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.instance.Play("Win");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
