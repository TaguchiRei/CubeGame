using UnityEngine;

public class SwitchBox : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public float X = 0;
    public float Y = 0;
    bool _keyDownWait = false;
    bool _canUse =false;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
    }

    void Update()
    {
        circleCollider.offset = new Vector2(X, Y);
        Vector2 select = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
        Vector2 thisPosition = transform.position;
        if (GameMaster._gameMode == 1)
        {
            if (Input.GetKeyDown(KeyCode.R) && _canUse)
            {
                if(circleCollider.enabled == true)
                {
                    circleCollider.enabled =false;
                }
                else
                {
                    circleCollider.enabled = true;
                }
            }
        }
        else if (GameMaster._gameMode == 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (select == thisPosition && _keyDownWait == false)
                {
                    _keyDownWait = true;
                }else if (_keyDownWait)
                {
                    X = (GameMaster._mousePositionX-transform.position.x)*0.55f;
                    Y = (GameMaster._mousePositionY-transform.position.y)*0.55f;
                    _keyDownWait = false;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            _canUse = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            _canUse = false;
        }
    }
}
