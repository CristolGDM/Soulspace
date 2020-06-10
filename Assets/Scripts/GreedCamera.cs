using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class GreedCamera : MonoBehaviour {
    private Canvas canvas;
    // Start is called before the first frame update
    void Start() {
        canvas = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update() {
        if (canvas == null) return;
        if (canvas.worldCamera != null) return;

        Camera camera = Camera.main;

        Debug.Log(camera);

        canvas.worldCamera = camera;
    }
}
