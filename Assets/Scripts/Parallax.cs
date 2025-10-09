using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float lenght;
    public static float movingSpeed = 1f;
    public float parallaxEffect;
    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
        if (transform.position.x < -lenght+1)
        {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }

    }
}
