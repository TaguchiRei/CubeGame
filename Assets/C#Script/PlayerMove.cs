using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigifbody2d;
    [SerializeField] Transform _transform;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip1;
    [SerializeField] AudioClip _audioClip2;
    [SerializeField] GameObject _goolEfect;
    GameObject _upperText;
    GameObject _buttonText;
    Text _upText;
    Text _buttonText1;
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] float _moveSpeed = 5;
    /// <summary>
    /// ジャンプ力
    /// </summary>
    [SerializeField] float _jumpP = 1;
    /// <summary>
    /// 壁の向き判定
    /// </summary>
    float _wall = 0;
    /// <summary>
    /// キャラクターのタイプ
    /// </summary>
    bool _canJump = false;
    bool _end = false;
    float _endTime = 2;
    public enum Type
    {
        nomal,
        gun,
    }
    private void Start()
    {
        _upperText = GameObject.Find("左上テキスト");
        _buttonText = GameObject.Find("ボタンテキスト");
        _upText = _upperText.GetComponent<Text>();
        _buttonText1 = _buttonText.GetComponent<Text>();
    }

    void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            _spriteRenderer.color = new Color(255, 255, 255, 255);
            //左右に動くためのプログラム
            float Yspeed = _rigifbody2d.velocity.y;
            float move = Input.GetAxisRaw("Horizontal");
            if (move != _wall * -1 && GameMaster._Rotate == 0 && !_end)
            {
                _rigifbody2d.velocity = new Vector2(_moveSpeed * move, Yspeed);
            }
            else
            {
                _rigifbody2d.velocity = new Vector2(0, Yspeed);
            }
            if (move == 0)
            {
                _wall = 0;
            }

            if (move < 0)
            {
                if (!GameMaster._correction)
                {
                    _transform.transform.localScale = new Vector3(-2, 2, 1);
                }
                else
                {
                    _transform.transform.localScale = new Vector3(2, 2, 1);
                }
            }
            else if (move > 0)
            {
                if (!GameMaster._correction)
                {
                    _transform.transform.localScale = new Vector3(2, 2, 1);
                }
                else
                {
                    _transform.transform.localScale = new Vector3(-2, 2, 1);
                }
            }
            //スペースキーを押したときの動作
            if (Input.GetButtonDown("Jump") && _canJump)
            {
                var jump = _jumpP * 13;
                _rigifbody2d.velocity = Vector2.up * jump;
                _canJump = false;
            }
        }
        else
        {
            _transform.position = new Vector2(0.5f, 0.5f);
            _rigifbody2d.velocity = Vector2.zero;
            _spriteRenderer.color = new Color(255, 255, 255, 0);
        }
        if (_end)
        {
            _endTime -= Time.deltaTime;
            if (_endTime <= 0)
            {
                _end = false;
                _upText.text = "Makeng...";
                _buttonText1.text = "Play!";
                _endTime = 2;
                GameMaster._gameMode = 0;
            }
        }
        if (!GameMaster._correction)
        {
            var X = transform.localScale.x;
            _rigifbody2d.gravityScale = 6;
            _transform.localScale = new Vector3(X, 2, 1);
            _moveSpeed = 5;
            _jumpP = 1;
        }
        else
        {
            var X = _transform.localScale.x;
            _rigifbody2d.gravityScale = -6;
            _transform.localScale = new Vector3(X, -2, 1);
            _moveSpeed = -5;
            _jumpP = -1;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Mathf.Abs(collision.contacts[0].normal.x) > 0.8f)
        {
            _wall = Mathf.Sign(collision.contacts[0].normal.x);
        }
        else
        {
            _canJump = true;
        }
        if (collision.gameObject.CompareTag("enemy")&& !_end)
        {
            _audioSource.PlayOneShot(_audioClip2);
            _end = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gool") && !_end)
        {
            GameMaster._cameraXY = transform.position;
            GameMaster._cameraMove = true;
            _audioSource.time = 0.7f;
            _audioSource.PlayOneShot(_audioClip1);
            _end = true;
            Instantiate(_goolEfect, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _wall = 0;
    }



}
