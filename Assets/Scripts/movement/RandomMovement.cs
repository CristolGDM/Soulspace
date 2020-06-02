using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : CharacterMover {

    private float startMoving;
    private float moveInterval;

    // Use this for initialization
    public override void Start() {
        base.Start();
        startMoving = Random.Range(0.5f, 1.5f);
        moveInterval = Random.Range(3.0f, 5.0f);
        InvokeRepeating("MoveRandomDirection", startMoving, moveInterval);
    }

    public void OnDisable() {
        CancelInvoke("MoveRandomDirection");
    }

    public void OnEnable() {
        InvokeRepeating("MoveRandomDirection", startMoving, moveInterval);
    }

    void MoveRandomDirection() {
        int whichDirection = Random.Range(0, 5);

        if(whichDirection < 1) {
            StartCoroutine(MoveUp());
        } else if(whichDirection < 2) {
            StartCoroutine(MoveDown());
        } else if (whichDirection < 3) {
            StartCoroutine(MoveLeft());
        } else if (whichDirection < 4) {
            StartCoroutine(MoveRight());
        } else {
            StopMoving();
        }
    }
}
