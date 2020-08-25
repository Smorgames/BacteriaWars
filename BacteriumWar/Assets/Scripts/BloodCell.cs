using UnityEngine;

public class BloodCell : MonoBehaviour
{
    public GameObject deathEffect;
    public float rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bacterium")
        {
            collision.GetComponent<Cell>().BacteriumDeath();
            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }
    }
}
