using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public float movingSpeed = 5.0f;
    public float verticalBound = 3.5f;
    public float horizontalBound = 4.5f;

    public GameObject tiroPrefab;
    public Transform firePoint;

    private Rigidbody2D playerRb2d;
    void Start()
    {
        playerRb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float verticalDirection = 0.0f;
        float horizontalDirection = 0.0f;

        if (Input.GetKey(moveUp))
        {
            verticalDirection = 1.0f;
        }
        else if (Input.GetKey(moveDown))
        {
            verticalDirection = -1.0f;
        }else if (Input.GetKey(moveRight))
        {
            horizontalDirection = 1.0f;
        }else if (Input.GetKey(moveLeft))
        {
            horizontalDirection = -1.0f;
        }

        var vVelocity = playerRb2d.linearVelocity;
        vVelocity.y = verticalDirection * movingSpeed;
        playerRb2d.linearVelocity = vVelocity;

        var hVelocity = playerRb2d.linearVelocity;
        hVelocity.x = horizontalDirection * movingSpeed;
        playerRb2d.linearVelocity = hVelocity;

        var vPosition = transform.position;
        vPosition.y = Mathf.Clamp(vPosition.y, -verticalBound, verticalBound);
        transform.position = vPosition;

        var hPosition = transform.position;
        hPosition.x = Mathf.Clamp(hPosition.x, -horizontalBound, horizontalBound);
        transform.position = hPosition;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            firePoint = transform.Find("FirePoint");
            Instantiate(tiroPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
