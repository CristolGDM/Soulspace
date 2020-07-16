using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ORKFramework;

public class SpawnPlayerDirection : MonoBehaviour {

    private enum Direction { left, right, up, down};
    [SerializeField]
    private Direction direction = Direction.down;

    [SerializeField]
    private bool unique = false;

    // Start is called before the first frame update
    void Start() {
        GameObject player = ORK.Game.ActiveGroup.Leader.GameObject;
        if(!unique && Vector2.Distance(player.transform.position, gameObject.transform.position) >= 1) return;
        Animator animator = player.GetComponent<Animator>();
        if (animator == null) return;

        switch (direction) {
            case Direction.down:
                animator.SetInteger("Direction", 0);
                break;
            case Direction.left:
                animator.SetInteger("Direction", 1);
                break;
            case Direction.up:
                animator.SetInteger("Direction", 2);
                break;
            case Direction.right:
                animator.SetInteger("Direction", 3);
                break;
            default:
                break;
        }
    }
}
