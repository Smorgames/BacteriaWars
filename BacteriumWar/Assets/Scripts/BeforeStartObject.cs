using UnityEngine;

public class BeforeStartObject : MonoBehaviour
{
    public GameObject buildEffect;
    public GameObject spawningPrefab;

    private GameMaster gameMaster;

    private GameObject sellObject;

    public int towerCost;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sellObject = GameObject.FindWithTag("SellObject");
        GameObject effect = (GameObject)Instantiate(buildEffect, transform.position, Quaternion.identity);
        gameMaster = GameMaster.instance;
        Destroy(effect, 5f);
    }

    private void Update()
    {
        if (gameMaster.isGameActive)
            SpawnObject();
    }

    public void SpawnObject()
    {
        Instantiate(spawningPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
