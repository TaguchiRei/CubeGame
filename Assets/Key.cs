using UnityEngine;

public class Key : MonoBehaviour
{
    GameObject _gameObject = default;
    private Transform _player;
    [SerializeField] Transform _transform;
    [SerializeField] BoxCollider2D _boxCollider;
    [SerializeField] SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _gameObject = GameObject.Find("cube");
        _player = _gameObject.GetComponent<Transform>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            GameMaster._haveKey++;
            _boxCollider.enabled = false;
            _spriteRenderer.color = new Color(255,255,255,0);
        }
    }

    void ReStart()
    {
        _boxCollider.enabled=true;
        _spriteRenderer.color = new Color(255,255,255,255);
    }
}
