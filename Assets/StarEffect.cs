using UnityEngine;

public class StarEffect : MonoBehaviour
{
    Transform _transform;
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.localScale = new Vector3(25, 25, 25);
    }
    private void FixedUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.5f, transform.localScale.y - 0.5f, 10);
        if(transform.localScale.x < 1)
        {
            Destroy(gameObject);
        }
    }
}
