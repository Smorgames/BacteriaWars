using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class TowerData
{
    public string towerName; 
    public GameObject towerPrefab;
    public GameObject towerPrefabPreview;
    public int towerCost;
}

public class Store : MonoBehaviour
{
    public TowerData[] towers;
    public TextMeshProUGUI[] costs;

    public GameObject storeManager;
    private StoreManager storeManagerComponent;

    public Button[] towerButton;
    public bool[] isButtonActive;

    private void Start()
    {
        storeManagerComponent = storeManager.GetComponent<StoreManager>();

        for (int i = 0; i < costs.Length; i++)
        {
            costs[i].text = towers[i].towerCost.ToString() + " $";
        }

        for (int i = 0; i < towerButton.Length; i++)
        {
            if (isButtonActive[i] == true)
                towerButton[i].interactable = true;
            else
                towerButton[i].interactable = false;
        }
    }

    public void SelectGoodBacterium()
    {
        storeManagerComponent.Select(towers[0].towerPrefab, towers[0].towerPrefabPreview, towers[0].towerCost);
    }

    public void SelecetBloodCell1()
    {
        storeManagerComponent.Select(towers[1].towerPrefab, towers[1].towerPrefabPreview, towers[1].towerCost);
    }

    public void SelectShootingCell()
    {
        storeManagerComponent.Select(towers[2].towerPrefab, towers[2].towerPrefabPreview, towers[2].towerCost);
    }

    public void SelecetBloodCell2()
    {
        storeManagerComponent.Select(towers[3].towerPrefab, towers[3].towerPrefabPreview, towers[3].towerCost);
    }

    public void SelecetBloodCell3()
    {
        storeManagerComponent.Select(towers[4].towerPrefab, towers[4].towerPrefabPreview, towers[4].towerCost);
    }
}
