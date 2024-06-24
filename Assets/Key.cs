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
        if (GameMaster._gameMode == 0)
        {
            ResetGame();
            Vector2 select = new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY);
            Vector2 thisPosition = transform.position;
            if (Input.GetKeyDown(KeyCode.R) && select == thisPosition &&GameMaster.key)
            {
                if (!_linkMode)
                {
                    if (select == thisPosition)
                    {
                        GameMaster._linkMode = true;
                        _linkMode = true;
                        GameMaster.key = false;
                    }
                }
            }
            //鍵付きドア生成
            if (GameMaster._link &&_linkMode)
            {
                lockedDoor = Instantiate(_lockDoor, new Vector2(GameMaster._mousePositionX, GameMaster._mousePositionY), Quaternion.identity) as GameObject;
                GameMaster._link = false;
                GameMaster._linkMode = false;
                _linkMode |= false;
                _linking = true;
            }
        }
        else
        {
            //鍵付きドア開閉
            if (_haveKey)
            {
                open = lockedDoor.GetComponent<LockDoor>();
                open.Open(true);
                _linking = false;
                _haveKey = false;
            }
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
