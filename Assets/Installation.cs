using System;
using UnityEngine;

public class Installation : MonoBehaviour
{
    private Camera _camera;
    public GameObject[] table = new GameObject[5];
    [SerializeField] SpriteRenderer _spriteRenderer;
    int _type = 0;
    void Start()
    {
        _camera = Camera.main;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster._gameMode == 0)
        {
            var WorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            var x = Math.Floor(WorldPoint.x) + 0.5;
            var y = Math.Floor(WorldPoint.y) + 0.5;
            float X = (float)x;
            float Y = (float)y;
            transform.position = new Vector2(X, Y);
            _spriteRenderer.color = new Color(255, 255, 255, 255);
            if (Input.GetButtonDown("Fire1"))
            {
                var newx = Math.Floor(transform.position.x) + 0.5;
                var newy = Math.Floor(transform.position.y) + 0.5;
                var make = Instantiate(table[_type]);
                float floatx = (float)newx;
                float floaty = (float)newy;
                make.transform.position = new Vector2(floatx, floaty);
            }
            if (Input.GetButtonDown("Fire2"))
            {
                _type++;
                if (_type == table.Length)
                {
                    _type = 0;
                }
            }
        }
        else
        {
            _spriteRenderer.color = new Color(255, 255, 255, 0);
        }
    }
}
