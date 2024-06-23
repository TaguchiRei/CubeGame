using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool _canOpen = false;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] BoxCollider2D _boxCollider;
    [SerializeField] Transform _transform;
    Camera _camera;
    GameObject _gameObject;
    Transform _plyerTransform;
    float wait = 0;
    private void Start()
    {
        _gameObject = GameObject.Find("cube");
        _plyerTransform = _gameObject.GetComponent<Transform>();
        _spriteRenderer.color = new Color(255, 255, 255, 255);
        _boxCollider.enabled = true;
        _camera = Camera.main;
        
    }
    void Update()
    {
        var distancePosition = _plyerTransform.position - transform.position;
        var distance = Mathf.Abs(distancePosition.x) + Mathf.Abs(distancePosition.y);
        if (_canOpen && GameMaster._gameMode == 0)
        {
            var distance2 = distance / 3;
            if (distance2 > 1)
            {
                distance2 = 1;
            }
            _spriteRenderer.color = new Color(255, 255, 255, distance2);
            _boxCollider.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.R) && GameMaster._gameMode == 0 &&GameMaster._haveKey>0 &&distance<2)
        {
            GameMaster._haveKey -= 1;
            _canOpen = true;

        }
    }
}
