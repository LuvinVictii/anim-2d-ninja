using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public bool isFriendly = true;
    public bool isRightFacing = true;

    public void kunaiInit(bool isRightFacing, bool isFriendly)
    {
        this.isFriendly = isFriendly;
        this.isRightFacing = isRightFacing;
        if (isRightFacing)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * (isRightFacing ? 1 : -1));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Kunai hit: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player") && !isFriendly)
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Enemy") && isFriendly)
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
