using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ORKFramework;

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
        if (ORK.InputKeys.Get(1).GetButton()) {
            StartCoroutine(MoveUp());
        } else if (ORK.InputKeys.Get(2).GetButton()) {
            StartCoroutine(MoveDown());
        } else if (ORK.InputKeys.Get(3).GetButton()) {
            StartCoroutine(MoveLeft());
        } else if (ORK.InputKeys.Get(4).GetButton()) {
            StartCoroutine(MoveRight());
        }

        base.Update();
    }
}
