using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    private void Awake()
    {
        instance = this;
    }

    public int loseAmount;
    public TextMeshProUGUI bacteriumAmountText;

    private int bacteriumAmount = 0;

    public GameObject store;
    public TextMeshProUGUI moneyText;
    public GameObject startButton;
    public GameObject spawnZones;

    public bool isGameActive = false;

    public GameObject gameOver;
    public GameObject win;
    public GameObject level;

    private void Start()
    {
        Time.timeScale = 1f;
        bacteriumAmountText.enabled = false;
    }

    public void AddBacteriumAmount()
    {
        bacteriumAmount += 1;

        if (bacteriumAmount == 1)
            bacteriumAmountText.text = bacteriumAmount.ToString() + " cell";
        else
            bacteriumAmountText.text = bacteriumAmount.ToString() + " cells";

        if (bacteriumAmount >= loseAmount)
        {
            isGameActive = false;
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }

    public void SubtractBacteriumAmount()
    {
        bacteriumAmount -= 1;

        if (bacteriumAmount == 1)
            bacteriumAmountText.text = bacteriumAmount.ToString() + " cell";
        else
            bacteriumAmountText.text = bacteriumAmount.ToString() + " cells";

        if (bacteriumAmount <= 0f && isGameActive)
        {
            isGameActive = false;
            Time.timeScale = 0f;
            win.SetActive(true);
        }
    }

    public void StartGame()
    {
        bacteriumAmountText.enabled = true;
        moneyText.enabled = false;
        store.SetActive(false);
        spawnZones.SetActive(false);
        isGameActive = true;
        startButton.SetActive(false);
        level.SetActive(true);
    }
}
