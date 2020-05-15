using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : CharacterMover {

    // Update is called once per frame
    public override void Update() {

        //if(inputManager.InteractKeySingle(this)) {
        //    Vector3 currentDirection = mover.GetCurrentDirection();
        //    RaycastHit2D raycast = Physics2D.Raycast(gameObject.transform.position + currentDirection, currentDirection, 0.1f);
        //    if (raycast.collider) {
        //        if (raycast.collider.GetComponent<OnInteract>()) {
        //            raycast.collider.gameObject.SendMessage("StartInteraction");
        //        }
        //    }
        if (Input.GetKey("w") || Input.GetKey("up")) {
            StartCoroutine(MoveUp());
        } else if (Input.GetKey("s") || Input.GetKey("down")) {
            StartCoroutine(MoveDown());
        } else if (Input.GetKey("a") || Input.GetKey("left")) {
            StartCoroutine(MoveLeft());
        } else if (Input.GetKey("d") || Input.GetKey("right")) {
            StartCoroutine(MoveRight());
        }

        base.Update();
    }
}
