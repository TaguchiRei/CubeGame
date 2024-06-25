using UnityEngine;

public class SwitchBox : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public float X = 0;
    public float Y = 0;
    bool _lever = false;
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
            Vector2 select = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
            Vector2 thisPosition = transform.position;
            if (Input.GetKeyDown(KeyCode.R) && select == thisPosition && GameMaster.key)
            {

            }

        }


    }
}
