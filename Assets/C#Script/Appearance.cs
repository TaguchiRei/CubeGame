using UnityEngine;

public class Appearance : MonoBehaviour
{
    void Update()
    {
        if (GameMaster._gameMode == 0 && Input.GetButtonDown("Fire1"))
        {
            if (GameMaster._mousePositionX == transform.position.x && GameMaster._mousePositionY == transform.position.y)
            {
                if (this.tag == "lockeddoor")
                {
                    GameMaster._key = true;
                }
                Destroy(gameObject);
            }

        }
        if (transform.position.x < 0.5f||transform.position.x>16.7f || transform.position.y < 0.2f||transform.position.y>8.7)
        {
            Destroy(gameObject);
        }
    }
}