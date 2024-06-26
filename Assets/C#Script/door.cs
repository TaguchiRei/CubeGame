using UnityEngine;

public class Door : MonoBehaviour
{
    bool _canOpen = false;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] BoxCollider2D _boxCollider;
    [SerializeField] Transform _transform;
    AudioSource _audioSource;
    GameObject _gameObject;
    Transform _plyerTransform;
    bool _switchBox =false;
    private void Start()
    {
        _gameObject = GameObject.Find("cube");
        _plyerTransform = _gameObject.GetComponent<Transform>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer.color = new Color(255, 255, 255, 255);
        _boxCollider.enabled = true;

    }
    void Update()
    {
        //プレイヤーとの距離を測る
        var distancePosition = _plyerTransform.position - transform.position;
        var distance = Mathf.Abs(distancePosition.x) + Mathf.Abs(distancePosition.y);
        //鍵が開いているときは透明化して見えなくなる
        if (_canOpen && GameMaster._gameMode == 1||_switchBox==true)
        {
            var distance2 = distance / 3;
            if (distance2 > 1)
            {
                distance2 = 1;
            }
            _spriteRenderer.color = new Color(255, 2, 200, distance2);
            _boxCollider.enabled = false;
        }
        else
        {
            _boxCollider.enabled = true;
            _spriteRenderer.color = new Color(255,255,255,255);
        }
        //鍵を持っているときは消費して通れるようになる
        if (Input.GetKeyDown(KeyCode.R) && GameMaster._gameMode == 1 && GameMaster._haveKey > 0 && distance < 2)
        {
            _audioSource.Play();
            GameMaster._haveKey -= 1;
            _canOpen = true;
        }
        //鍵をつけるために編集モード中に破棄する
        if (Input.GetKeyDown(KeyCode.R) && GameMaster._gameMode == 0)
        {
            Vector2 select = new Vector3(GameMaster._mousePositionX, GameMaster._mousePositionY, transform.position.z);
            Vector2 thisPosition = transform.position;
            if (select == thisPosition && GameMaster._keyLinkMode)
            {
                GameMaster._link = true;
                Destroy(gameObject);
            }
        }
        if (GameMaster._gameMode == 0)
        {
            ResetGame();
        }
    }
    void ResetGame()
    {
        _canOpen = false;
        _spriteRenderer.color = new Color(255, 255, 255, 255);
        _boxCollider.enabled = true;  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("switchBox"))
        {
            _switchBox = true;
            Debug.Log("Yes");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("switchBox"))
        {
            _switchBox = false;
        }
    }
}

