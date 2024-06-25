using UnityEngine;

public class Door : MonoBehaviour
{
    bool _canOpen = false;
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
        //�v���C���[�Ƃ̋����𑪂�
        var distancePosition = _plyerTransform.position - transform.position;
        var distance = Mathf.Abs(distancePosition.x) + Mathf.Abs(distancePosition.y);
        //�����J���Ă���Ƃ��͓��������Č����Ȃ��Ȃ�
        if (_canOpen && GameMaster._gameMode == 1)
        {
            var distance2 = distance / 3;
            if (distance2 > 1)
            {
                distance2 = 1;
            }
            _spriteRenderer.color = new Color(255, 255, 200, distance2);
            _boxCollider.enabled = false;
        }
        //���������Ă���Ƃ��͏���Ēʂ��悤�ɂȂ�
        if (Input.GetKeyDown(KeyCode.R) && GameMaster._gameMode == 1 && GameMaster._haveKey > 0 && distance < 2)
        {
            GameMaster._haveKey -= 1;
            _canOpen = true;
        }
        //�������邽�߂ɕҏW���[�h���ɔj������
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
}

