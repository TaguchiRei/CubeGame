using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public static bool _canOpen = false;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] BoxCollider2D _boxCollider;
    [SerializeField] Transform _transform;
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
        var distancePosition = _plyerTransform.position - transform.position;
        var distance = Mathf.Abs(distancePosition.x) + Mathf.Abs(distancePosition.y);
        if (_canOpen && GameMaster._gameMode == 1)
        {
            var distance2 = distance / 3;
            if (distance2 > 1)
            {
                distance2 = 1;
            }
            _spriteRenderer.color = new Color(255, 255, 255, distance2);
            _boxCollider.enabled = false;
        }
        if (GameMaster._gameMode == 0)
        {
            ResetGame();
        }
    }
    public void Open(bool open)
    {
        _canOpen = open;
    }
    void ResetGame()
    {
        _canOpen =false;
        _spriteRenderer.color = new Color(255, 255, 255, 255);
    }
    
}
