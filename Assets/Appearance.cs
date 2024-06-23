using UnityEngine;

public class Appearance : MonoBehaviour
{
    Door door;
    void Start()
    {
        door = this.GetComponent<Door>();
    }
    void Update()
    {
        if (GameMaster._gameMode == 0 && Input.GetButtonDown("Fire1"))
        {
            if (GameMaster._mousePositionX == transform.position.x && GameMaster._mousePositionY == transform.position.y)
            {
                Destroy(gameObject);
            }

        }
    }
}