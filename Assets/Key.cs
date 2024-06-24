using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] BoxCollider2D _boxCollider;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] GameObject _lockDoor;
    private bool _linkMode = false;
    bool _haveKey = false;
    bool _linking = false;
    GameObject lockedDoor;
    LockDoor open;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector2 select = new Vector3(GameMaster._mousePositionX, GameMaster._mousePositionY, transform.position.z);
            Vector2 thisPosition = transform.position;
            if (!_linkMode)
            {
                if (select == thisPosition)
                {
                    GameMaster._linkMode = true;
                    _linkMode = true;
                }
            }
        }
        //鍵付きドア生成
        if (GameMaster._link)
        {
            lockedDoor = Instantiate(_lockDoor, new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY), Quaternion.identity) as GameObject;
            GameMaster._link = false;
            _linking = true;
            Debug.Log("変換");
        }
        //鍵付きドア開閉
        if (_linking)
        {
            open = lockedDoor.GetComponent<LockDoor>();
            if (_haveKey)
            {
                if (lockedDoor != null)
                {
                    open.Open(true);
                }
                else
                {
                    Debug.Log("lockedDoorがnullになっています");
                }
            }
        }
        if (GameMaster._gameMode == 0)
        {
            ResetGame();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (_linking)
            {
                _haveKey = true;
            }
            else
            {
                GameMaster._haveKey++;
            }
            _boxCollider.enabled = false;
            _spriteRenderer.color = new Color(255, 255, 255, 0);
        }
    }

    void ResetGame()
    {
        _boxCollider.enabled = true;
        _spriteRenderer.color = new Color(255, 255, 255, 255);
    }
}
