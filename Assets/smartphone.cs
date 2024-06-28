using UnityEngine;

public class smartphone : MonoBehaviour
{
    bool move = false;
    void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                transform.position = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
                move = true;
            }
            if (Input.GetButtonUp("Fire1"))
            {
                move = false;
            }
            
            if (move)
            {
                if (transform.position.x + 0.5f < GameMaster._mousePositionX)
                {

                }
                else if (transform.position.x - 0.5f > GameMaster._mousePositionX)
                {

                }


            }
        }
    }
}
