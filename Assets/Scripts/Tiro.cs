using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxDistance = 9.0f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (Mathf.Abs(transform.position.x) > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.AddScore(10);
            Parallax.movingSpeed += 1.0f;
        }
    }
}
