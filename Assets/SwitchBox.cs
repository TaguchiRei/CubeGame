using UnityEngine;

public class SwitchBox : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public float X = 0;
    public float Y = 0;
    bool _lever = false;
    bool _keyDownWait = false;
    bool _canUse =false;
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        //circleCollider.offset = new Vector2(X, Y);

        if (GameMaster._gameMode == 1)
        {
            if (_lever)
            {
                circleCollider.enabled = true;
            }
            else
            {
                circleCollider.enabled = false;
            }
        }
        else if (GameMaster._gameMode == 0)
        {
            Vector2 select = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
            Vector2 thisPosition = transform.position;
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (select == thisPosition && _keyDownWait == false)
                {
                    _keyDownWait = true;
                }else if (_keyDownWait)
                {
                    X = GameMaster._mousePositionX;
                    Y = GameMaster._mousePositionY;
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
