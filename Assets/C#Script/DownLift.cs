using UnityEngine;

public class DownLift : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody2;
    bool _onOff = false;
    float back = 1;
    float timer = 0;
    Vector2 start;

    private void Start()
    {
        start = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            if (_onOff)
            {
                rigidbody2.velocity = Vector2.down * 5*back;
            }
        }
        else
        {
            transform.position = start;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                _onOff = true;
                back = -1;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            _onOff = true;
            back = 1;
            timer = 10f;
        }else if(collision.gameObject.CompareTag("stopper")||collision.gameObject.CompareTag("Untagged"))
        {
            _onOff = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            timer = 0.25f;
        }
    }
}
