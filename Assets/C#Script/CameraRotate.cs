using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] Camera Camera;
    [SerializeField] Transform Transform;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] float _rotateTime = 2;
    [SerializeField] Rigidbody2D _rigidbody2d;
    float time = 0;
    float rotate = 0;
    float moveX =0;
    float moveY =0;
    bool rotation = false;

    void Update()
    {
        if (GameMaster._gameMode == 0)
        {
            GameMaster._cameraMove = false;
            Camera.main.orthographicSize = 6f;
            transform.position = new Vector3(10f, 4.3f, -10f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            GameMaster._Rotate = 0;
        }
        else
        {
            Camera.main.orthographicSize = 5f;
            transform.position = new Vector3(8.5f, 4.3f, -10);
        }
        if (GameMaster._Rotate > 0)
        {
            if (!rotation)
            {
                rotation = true;
                rotate = GameMaster._Rotate;
                AudioSource.Play();
                time = _rotateTime;
            }
            transform.Rotate(0f, 0f, rotate * Time.deltaTime / _rotateTime, 0f);
            time -= Time.deltaTime;
        }
        if (time <= 0 && rotation)
        {
            if (GameMaster._correction)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                GameMaster._correction = false;
            }else
            {
                GameMaster._correction = true;
                transform.rotation = new Quaternion(0,0,180,0);
            }
            rotation = false;
            GameMaster._Rotate = 0;
            AudioSource.Stop();
        }
        if (GameMaster._cameraMove)
        {
            moveX = GameMaster._cameraXY.x;
            moveY = GameMaster._cameraXY.y;
            transform.position = new Vector3(moveX, moveY,-10);
            Camera.orthographicSize = 3;
        }
    }
}
