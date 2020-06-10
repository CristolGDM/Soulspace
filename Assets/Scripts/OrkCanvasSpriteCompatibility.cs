using UnityEngine;

public class OrkCanvasSpriteCompatibility : MonoBehaviour {
    public GameObject sprite = null;

    // Update is called once per frame
    void Update() {
        Canvas[] parentCanvases = gameObject.GetComponentsInParent<Canvas>();

        if (parentCanvases == null || parentCanvases.Length == 0) {
            sprite.GetComponent<SpriteRenderer>().size = new Vector2(0, 0);
            return;
        }
        SetCanvasMode(parentCanvases[0]);
        SetSpriteSize();
    }

    void SetSpriteSize() {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        RectTransform parent = gameObject.GetComponentInParent<RectTransform>();
        renderer.size = new Vector2(parent.rect.width / 80, parent.rect.height / 80);
    }

    void SetCanvasMode(Canvas canvas) {
        if (canvas == null) return;
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera) return;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        if (canvas.worldCamera != null) return;

        Camera camera = Camera.main;

        canvas.worldCamera = camera;
        canvas.sortingLayerName = "UI";
    }
}
