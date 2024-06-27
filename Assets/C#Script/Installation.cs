using UnityEngine;

public class Installation : MonoBehaviour
{
    public GameObject[] _table = new GameObject[5];
    public Sprite _LinkCursor;
    public  Sprite _Cursor;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _put;
    [SerializeField] AudioClip _change;
    public static int _type = 0;
    public static int tableNumber = 0;

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
            if (!GameMaster._keyLinkMode)
            {
                //�X�^�[�g�n�_�Ɠ����Ȃ�u���b�N�������Ȃ�
                if (GameMaster._mousePositionX == 0.5f && GameMaster._mousePositionY == 0.5)
                {

                }
                else
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if(tableNumber == 0)
                        {
                            var make = Instantiate(_table[_type]);
                            make.transform.position = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
                            SE();
                        }
                    }
                    if (Input.GetButtonDown("Fire2"))
                    {
                        _type++;
                        if (_type == _table.Length)
                        {
                            _type = 0;
                        }
                        SE(2);
                    }
                }
            }
            else
            {

            }
          
        }
        else
        {
            _spriteRenderer.color = new Color(255, 255, 255, 0);
        }
        if (!GameMaster._keyLinkMode)
        {
            _spriteRenderer.sprite = _Cursor;
        }
        else
        {
            _spriteRenderer.sprite = _LinkCursor;
        }
    }
    void SE(float clip =1)
    {
        if(clip == 1)
        {
            _audioSource.PlayOneShot(_put);
        }else if(clip == 2)
        {
            _audioSource.PlayOneShot(_change);
        }
    }
}