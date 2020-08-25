using UnityEngine;
using TMPro;
using System.Collections;

public class StoreManager : MonoBehaviour
{
    private bool isSelected = false;

    private GameObject towerPrefabData;
    private GameObject towerPrefabPreviewData;
    private int towerCostData;

    public Camera mainCamera;

    public GameObject store;

    [HideInInspector]
    public bool canBuild = false;

    public int startMoney;
    [HideInInspector]
    public int currenMoney;

    public TextMeshProUGUI moneyAmountText;

    public GameObject startButton;

    private void Start()
    {
        currenMoney = startMoney;
        moneyAmountText.text = currenMoney.ToString() + " $";
    }

    private void Update()
    {
        if (isSelected && Input.GetMouseButtonDown(0) && canBuild && towerCostData <= currenMoney)
        {
            Instantiate(towerPrefabData, mainCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f), Quaternion.identity);
            AudioManager.instance.Play("BuildTower");
            ChangeMoneyAmount(-towerCostData);
        }

        //if (isSelected && Input.GetMouseButtonDown(0) && towerCostData > currenMoney)
        //    AudioManager.instance.Play("CanNotBuildTower");

        if (isSelected)
            towerPrefabPreviewData.transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);

        if (Input.GetKeyDown(KeyCode.Escape) && isSelected == true)
            Deselect();
    }

    public void Select(GameObject towerPrefab, GameObject towerPrefabPreview, int towerCost)
    {
        isSelected = true;
        store.SetActive(false);
        towerPrefabPreviewData = towerPrefabPreview;
        towerPrefabData = towerPrefab;
        towerCostData = towerCost;
        towerPrefabPreviewData.SetActive(true);
        startButton.SetActive(false);
    }

    private void Deselect()
    {
        towerPrefabPreviewData.SetActive(false);
        store.SetActive(true);
        isSelected = false;
        towerPrefabPreviewData = null;
        towerPrefabData = null;
        startButton.SetActive(true);
    }

    public void ChangeMoneyAmount(int subMoney)
    {
        currenMoney += subMoney;
        moneyAmountText.text = currenMoney.ToString() + " $";
    }
}
