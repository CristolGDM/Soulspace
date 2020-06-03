using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ORKFramework;

[RequireComponent(typeof(Animator))]
public class TurnToPlayer : MonoBehaviour { 

    void Update() {
        ORKFramework.Combatant player = ORK.Game.ActiveGroup.Leader;
        Vector2 direction = player.GameObject.transform.position - transform.position;
        direction = player.GameObject.transform.InverseTransformDirection(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Animator animator = gameObject.GetComponent<Animator>();

        if(angle <= -135 || angle > 135) {
            animator.SetInteger("Direction", 1);
        }
        else if(angle <= -45) {
            animator.SetInteger("Direction", 0);
        }
        else if(angle <= 45) {
            animator.SetInteger("Direction", 3);
        }
        else if (angle <= 135) {
            animator.SetInteger("Direction", 2);
        }
    }
}
