using UnityEngine;

public class UpLift : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2;
    float speed = 0;
    Vector2 start;

    private void Start()
    {
        start = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            if (speed == 0)
            {
                rigidbody2.velocity = new Vector2(0, 0);
            }
            else if (speed == 1)
            {
                rigidbody2.velocity = new Vector2(0, 5);
            }
            else
            {
                rigidbody2.velocity = new Vector2(0, -10);
            }
        }
        else
        {
            transform.position = start;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (collision.gameObject.CompareTag("Untagged"))
            {
                speed = 0;
            }
            else
            {
                speed = 1;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            speed = -1;
        }
    }
}
