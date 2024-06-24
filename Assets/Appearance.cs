using UnityEngine;

public class Appearance : MonoBehaviour
{
    void Update()
    {
        if (GameMaster._gameMode == 0 && Input.GetButtonDown("Fire1"))
        {
            if (GameMaster._mousePositionX == transform.position.x && GameMaster._mousePositionY == transform.position.y)
            {
                Destroy(gameObject);
            }

        }
        if(transform.position.x<0.5f || transform.position.y < 0.5f)
        {
            Destroy (gameObject);
        }
    }
}