using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            _spriteRenderer.enabled = false;
        }else
        {
            _spriteRenderer.enabled = true;
        }
    }
}
