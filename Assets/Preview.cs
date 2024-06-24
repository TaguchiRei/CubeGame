using UnityEngine;

public class Preview : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[5];
    [SerializeField] SpriteRenderer spriteRenderer;
    void Update()
    {
        if (GameMaster._gameMode == 0)
        {
            spriteRenderer.sprite = sprite[Installation._type];
            spriteRenderer.color = new Color(255, 255, 255, 255);
        }
        else
        {
            spriteRenderer.color = new Color(255, 255, 255,0);
        }
    }
}
