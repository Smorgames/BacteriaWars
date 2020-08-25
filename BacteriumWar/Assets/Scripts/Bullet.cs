using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    [HideInInspector]
    public Transform directionPoint;
    [HideInInspector]
    public Transform startPosition;

    private Rigidbody2D rigidBody;

    public GameObject explodePrefab;

    public int damage;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.Translate((directionPoint.position - startPosition.position) * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bacterium")
        {
            collision.gameObject.GetComponent<Cell>().TakeDamage(damage);
            GameObject explode = (GameObject)Instantiate(explodePrefab, transform.position, Quaternion.identity);
            Destroy(explode, 1f);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "HorizontalBorder" || collision.gameObject.tag == "VerticalBorder")
        {
            GameObject explode = (GameObject)Instantiate(explodePrefab, transform.position, Quaternion.identity);
            Destroy(explode, 1f);
            Destroy(gameObject);
        }

    }
}
