using UnityEngine;

public class Gool : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Installation._type == 7 && Installation.tableNumber == 0)
        {
            Destroy(gameObject);
        }
    }
}
