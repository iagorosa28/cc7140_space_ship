using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public float movingSpeed = 5.0f;
    public float verticalBound = 3.5f;

    private Rigidbody2D playerRb2d;
    void Start()
    {
        playerRb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direction = 0.0f;
        if (Input.GetKey(moveUp))
        {
            direction = 1.0f;
        }
        else if (Input.GetKey(moveDown))
        {
            direction = -1.0f;
        }

        var velocity = playerRb2d.linearVelocity;
        velocity.y = direction * movingSpeed;
        playerRb2d.linearVelocity = velocity;

        var position = transform.position;
        position.y = Mathf.Clamp(position.y, -verticalBound, verticalBound);
        transform.position = position;
    }
}
