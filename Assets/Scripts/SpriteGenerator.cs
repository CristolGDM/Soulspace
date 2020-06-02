using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteGenerator : MonoBehaviour {
    public Texture2D spriteSheet;

    private string modelSpritesheetName = "basic";
    private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start(){
        sprites = Resources.LoadAll<Sprite>("spritesheets/" + spriteSheet.name);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void LateUpdate() {
        string currentSpriteName = spriteRenderer.sprite.name;
        string newSpritename = currentSpriteName.Replace(modelSpritesheetName, spriteSheet.name);
        foreach (var sprite in sprites) {
            if (sprite.name == newSpritename) {
                spriteRenderer.sprite = sprite;
                break;
            }
        }
    }
}
