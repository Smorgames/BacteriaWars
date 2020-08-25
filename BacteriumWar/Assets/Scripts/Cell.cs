using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private GameMaster gameMaster;

    private Rigidbody2D rigidBody;

    private float speed;
    private float timer;
    private float divisionTimer;

    public GameObject bacteriumPrefab;
    public Transform[] spawnPoint;

    public Transform directionPoint;

    private Animator animator;

    public CellStats cellStats;

    private int maxHp;
    private int currentHP;

    [HideInInspector]
    public bool isResisting;

    public string bacteriumType;

    public GameObject[] spawnBacteriumPrefab;

    //public GameObject healthBar;
    //private HealthBar healthBarComponent;
    //public GameObject healthBarGameObject;

    private float divisionTime;

    private void Start()
    {
        gameMaster = GameMaster.instance;
        gameMaster.AddBacteriumAmount();

        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();

        timer = 3f;
        divisionTimer = 0f;

        speed = cellStats.speed;

        maxHp = cellStats.maxHP;
        currentHP = maxHp;

        isResisting = false;

        //healthBarComponent = healthBar.GetComponent<HealthBar>();
        //healthBarComponent.SetMaxHP(maxHp);

        divisionTime = Random.Range((float)cellStats.divisionSpeed, (float)cellStats.divisionSpeed + 3);
    }

    private void Update()
    {
        divisionTimer += Time.deltaTime;

        if (divisionTimer >= divisionTime)
        {
            if (bacteriumType == "Dividing")
            {
                animator.SetBool("Division", true);
                divisionTimer = 0f;
                isResisting = true;
            }

            if (bacteriumType == "Attacking")
            {
                animator.SetTrigger("Attack");
                divisionTimer = 0f;
                isResisting = true;
            }
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        rigidBody.velocity = (directionPoint.position - transform.position) * speed * Time.deltaTime;

        if (timer >= 3f)
        {
            Quaternion randomAngle = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(0f, 360f));
            transform.rotation = randomAngle;
            timer = 0f;
        }
    }

    private void OnMouseDown()
    {
        if (isResisting == false)
        {
            TakeDamage(1);
            //healthBarComponent.ChangeCurrentHP(currentHP);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HorizontalBorder")
        {
            //healthBarGameObject.transform.SetParent(null);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -(transform.rotation.eulerAngles.z + 180f));
            //healthBarGameObject.transform.SetParent(transform, true);
        }
        if (collision.gameObject.tag == "VerticalBorder")
        {
            //healthBarGameObject.transform.SetParent(null);
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -transform.rotation.eulerAngles.z);
            //healthBarGameObject.transform.SetParent(transform, true);
        }
    }

    public void BacteriumDeath()
    {
        speed = 0;
        GetComponent<CircleCollider2D>().enabled = false;
        animator.SetTrigger("Death");
    }

    //public void DestroyBacterium()
    //{
    //    gameMaster.SubtractBacteriumAmount();
    //    Destroy(gameObject);
    //}

    IEnumerator DestroyBacterium()
    {
        yield return new WaitForSeconds(0.01f);
        gameMaster.SubtractBacteriumAmount();
        AudioManager.instance.Play("BacteriaDeath");
        Destroy(gameObject);
    }

    public void Division()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(bacteriumPrefab, spawnPoint[i].position, Quaternion.Euler(0f, 0f, 0f));
        }

        StartCoroutine(DestroyBacterium());
    }

    public void Attack()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(spawnBacteriumPrefab[Random.Range(0, spawnBacteriumPrefab.Length)], spawnPoint[i].position, Quaternion.Euler(0f, 0f, 0f));
        }

        isResisting = false;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            BacteriumDeath();
        }
    }
}
