using UnityEngine;

public class Gool : MonoBehaviour
{
    private void Start()
    {
        GameMaster._cameraXY = transform.position;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Installation._type == 7 && Installation.tableNumber == 0)
        {
            Destroy(gameObject);
        }
    }
}
