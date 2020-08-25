using UnityEngine;

public class Helper : MonoBehaviour
{
    private void Awake()
    {
        //PlayerPrefs.SetInt("IsHelperActive", 0);

        if (PlayerPrefs.GetInt("IsHelperActive") == 0)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    public void DeactivateHelper()
    {
        PlayerPrefs.SetInt("IsHelperActive", 1);
        gameObject.SetActive(false);
    }

    public void SkipHelper()
    {
        gameObject.SetActive(false);
    }
}
