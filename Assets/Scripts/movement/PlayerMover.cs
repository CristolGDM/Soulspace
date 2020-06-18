﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ORKFramework;

public class PlayerMover : CharacterMover {
    private Transform interactionController;
    private float interactionControllerDistance = 0.3f;

    // Update is called once per frame
    public override void Update() {

        /* Movement */
        if (ORK.InputKeys.Get(1).GetButton()) {
            StartCoroutine(MoveUp());
        } else if (ORK.InputKeys.Get(2).GetButton()) {
            StartCoroutine(MoveDown());
        } else if (ORK.InputKeys.Get(3).GetButton()) {
            StartCoroutine(MoveLeft());
        } else if (ORK.InputKeys.Get(4).GetButton()) {
            StartCoroutine(MoveRight());
        }

        /* Assign interaction controller if doesn't exist yet */
        if (interactionController == null) {
            foreach (Transform eachChild in transform) {
                if (eachChild.name.ToLower().IndexOf("interaction") > -1 && eachChild.name.ToLower().IndexOf("controller") > -1) {
                    interactionController = eachChild;
                    break;
                }
            }
        }

        /* Move interaction controller depending on player position */
        if (interactionController != null) {
            switch (gameObject.GetComponent<Animator>().GetInteger("Direction")) {
                case 0:
                    interactionController.localPosition = new Vector2(0, -interactionControllerDistance);
                    break;
                case 1:
                    interactionController.localPosition = new Vector2(-interactionControllerDistance, 0);
                    break;
                case 2:
                    interactionController.localPosition = new Vector2(0, interactionControllerDistance);
                    break;
                case 3:
                    interactionController.localPosition = new Vector2(interactionControllerDistance, 0);
                    break;
                default:
                    interactionController.localPosition = new Vector2(0, -interactionControllerDistance);
                    break;
            }
        }

        base.Update();
    }
}
