using UnityEngine;
using System;

public class Paint : MonoBehaviour
{
    public Sprite[] _sprite = new Sprite[9];
    public Sprite[] _sprite2 = new Sprite[9];
    [SerializeField] SpriteRenderer _spriteRenderer;
    int tableNumber;
    int type;
    Camera _camera;
    private void Start()
    {
        tableNumber = (int)transform.position.x - 18;
        type = (int)8.5f - (int)transform.position.y;
        _camera = Camera.main;
    }
    void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            _spriteRenderer.enabled = false;
        }
        else
        {
            _spriteRenderer.enabled = true;
            var WorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
            float x =(float) Math.Round(WorldPoint.x);
            Vector2 select = new Vector2(x, GameMaster._mousePositionY);
            Vector2 thisPosition = new Vector2(transform.position.x, transform.position.y);
            if (Input.GetButtonDown("Fire1") && select == thisPosition)
            {
                Installation._type = type;
                Installation.tableNumber = tableNumber;
            }
        }
        if (tableNumber == 0)
        {
            _spriteRenderer.sprite = _sprite[type];
        }
        else
        {
            _spriteRenderer.sprite = _sprite2[type];
        }
    }
}
