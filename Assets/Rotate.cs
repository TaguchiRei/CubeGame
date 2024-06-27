using UnityEngine;

public class Rotate : MonoBehaviour
{
    bool _canUse = false;
    void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            if (Input.GetKeyDown(KeyCode.R) && _canUse &&_canUse&&GameMaster._Rotate ==0)
            {
                GameMaster._Rotate = 180;
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
