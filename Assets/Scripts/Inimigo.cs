using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float movingSpeed = 2.5f;
    private float verticalBound = 3.5f;
    private float horizontalBound = 4.5f;
    private Vector2 direction;

    private void Start()
    {
        EscolherNovaDirecao();
    }

    private void Update()
    {
        transform.Translate(direction * movingSpeed * Time.deltaTime);

        var position = transform.position;

        if(position.x > horizontalBound || position.x < -horizontalBound)
        {
            movingSpeed += 0.2f;
            direction.x *= -1;
            position.x = Mathf.Clamp(position.x, -horizontalBound, horizontalBound);
        }
        if(position.y > verticalBound || position.y < -verticalBound)
        {
            movingSpeed += 0.2f;
            direction.y *= -1;
            position.y = Mathf.Clamp(position.y, -verticalBound, verticalBound);
        }

        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.LoseLife();
        }
    }

    void EscolherNovaDirecao()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
