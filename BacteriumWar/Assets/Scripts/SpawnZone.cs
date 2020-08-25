using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private StoreManager storeManager;

    private void Start()
    {
        storeManager = GameObject.FindWithTag("StoreManager").GetComponent<StoreManager>();
    }

    private void OnMouseOver()
    {
        storeManager.canBuild = true;
    }

    private void OnMouseExit()
    {
        storeManager.canBuild = false;
    }
}
