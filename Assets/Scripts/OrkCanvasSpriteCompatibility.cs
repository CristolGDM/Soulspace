using UnityEngine;

public class OrkCanvasSpriteCompatibility : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Canvas canvas;
        Canvas[] parentCanvases = gameObject.GetComponentsInParent<Canvas>();
        if (parentCanvases == null) return;
        if (parentCanvases.Length == 0) return;
        canvas = parentCanvases[0];
        if (canvas == null) return;
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera) return;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        if (canvas.worldCamera != null) return;

        Camera camera = Camera.main;

        canvas.worldCamera = camera;
    }
}
