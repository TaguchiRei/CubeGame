using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigifbody2d;
    [SerializeField] Transform _transform;
    [SerializeField] SpriteRenderer _spriteRenderer;
    /// <summary>
    /// �ړ����x
    /// </summary>
    [SerializeField] float _moveSpeed = 5;
    /// <summary>
    /// �W�����v��
    /// </summary>
    [SerializeField] float _jumpP = 1;
    /// <summary>
    /// �ǂ̌�������
    /// </summary>
    float _wall = 0;
    /// <summary>
    /// �L�����N�^�[�̃^�C�v
    /// </summary>
    bool canJump = false;
    public enum Type
    {
        nomal,
        gun,
    }

    void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            _spriteRenderer.color = new Color(255, 255, 255, 255);
            //���E�ɓ������߂̃v���O����
            float Yspeed = _rigifbody2d.velocity.y;
            float move = Input.GetAxisRaw("Horizontal");
            if (move != _wall * -1)
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
                _transform.transform.localScale = new Vector3(-2, 2, 1);
            }
            else if (move > 0)
            {
                _transform.transform.localScale = new Vector3(2, 2, 1);
            }
            //�X�y�[�X�L�[���������Ƃ��̓���
            if (Input.GetButtonDown("Jump") && canJump)
            {
                var jump = _jumpP * 13;
                _rigifbody2d.velocity = Vector2.up * jump;
                canJump = false;
            }
        }
        else
        {
            _transform.position = new Vector2(0.5f, 0.5f);
            _rigifbody2d.velocity = Vector2.zero;
            _spriteRenderer.color = new Color(255, 255, 255, 0);
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
            canJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _wall = 0;
    }

}
