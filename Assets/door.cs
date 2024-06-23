using UnityEngine;

public class Door : MonoBehaviour
{
    bool _canOpen = true;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] BoxCollider2D _boxCollider;
    GameObject _gameObject;
    Transform _plyerTransform;
    private void Start()
    {
        _gameObject = GameObject.Find("cube");
        _plyerTransform = _gameObject.GetComponent<Transform>();
        _spriteRenderer.color = new Color(255, 255, 255, 255);
        _boxCollider.enabled = true;
    }
    void Update()
    {
        var distance = _plyerTransform.position - transform.position;
        if (_canOpen && GameMaster._gameMode == 0)
        {
            var coller = Mathf.Abs(distance.x) + Mathf.Abs(distance.y);
            var coller2 = coller / 3;
            if (coller2 > 1)
            {
                coller2 = 1;
            }

            _spriteRenderer.color = new Color(255, 255, 255, coller2);
            _boxCollider.enabled = false;
        }
    }
}
