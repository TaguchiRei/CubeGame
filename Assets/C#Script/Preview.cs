using UnityEngine;

public class Preview : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[5];
    public Sprite[] sprite2 = new Sprite[5];
    [SerializeField] SpriteRenderer spriteRenderer;
    void Update()
    {
        if (GameMaster._gameMode == 0)
        {
            if(Installation.tableNumber == 0)
            {
                spriteRenderer.sprite = sprite[Installation._type];
            }
            else
            {
                spriteRenderer.sprite = sprite2[Installation._type];
            }
            spriteRenderer.color = new Color(255, 255, 255, 255);
        }
        else
        {
            spriteRenderer.color = new Color(255, 255, 255,0);
        }
    }
}
