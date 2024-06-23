using System;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if (GameMaster._gameMode == 0 && Input.GetButtonDown("Fire1"))
        {
            var WorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            var x = Math.Floor(WorldPoint.x) + 0.5;
            var y = Math.Floor(WorldPoint.y) + 0.5;
            if (x ==transform.position.x &&y == transform.position.y)
            {
                Destroy(gameObject);
            }
        }
    }
}
