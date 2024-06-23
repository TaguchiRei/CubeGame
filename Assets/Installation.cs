using System;
using UnityEngine;

public class Installation : MonoBehaviour
{
    public GameObject[] table = new GameObject[5];
    [SerializeField] SpriteRenderer _spriteRenderer;
    public static int _type = 0;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMaster._gameMode == 0)
        {
            transform.position = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
            _spriteRenderer.color = new Color(255, 255, 255, 255);
            if (Input.GetButtonDown("Fire1"))
            {
                var make = Instantiate(table[_type]);
                make.transform.position = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
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
