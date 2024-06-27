using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] Vector2 _lineForWall = Vector2.right;
    [SerializeField] LayerMask _wallLayer = 0;
    Rigidbody2D _rb = default;
    Vector2 _moveDirection = Vector2.right;
    Vector2 _firstPosition;

    private void Start()
    {
        _firstPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (GameMaster._gameMode == 1)
        {
            MoveOnFloor();
        }
        else
        {
            transform.position = _firstPosition;
        }
    }

    void MoveOnFloor()
    {

        Vector2 start = this.transform.position;
        Debug.DrawLine(start, start + _lineForWall);
        RaycastHit2D hit = Physics2D.Linecast(start, start + _lineForWall, _wallLayer);
        Vector2 velo = Vector2.zero;    // velo は速度ベクトル

        if (hit.collider)
        {
            _moveSpeed = _moveSpeed * -1f;
            _lineForWall.x = _lineForWall.x * -1;
        }

        velo = _moveDirection.normalized * _moveSpeed;
        velo.y = _rb.velocity.y;
        _rb.velocity = velo;
    }
}
