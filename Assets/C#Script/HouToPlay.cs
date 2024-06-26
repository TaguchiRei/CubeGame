using UnityEngine;
using UnityEngine.SceneManagement;

public class HouToPlay : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            spriteRenderer.enabled = false;

        }
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("GameScene");
    }
}
