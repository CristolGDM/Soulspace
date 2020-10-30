using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterMover : MonoBehaviour {

    private Vector3 pos;
    private float speed = 4.0f;
    private Vector3 originalPosition;
    private Animator animator;
    private float positionOffsetHelper = 10000.5F;

    // Use this for initialization
    public virtual void Start () {
        pos = transform.position;
        originalPosition = transform.position;
        animator = gameObject.GetComponent<Animator>();
    }

    public virtual void Update() {
        if (!animator.GetBool("Moving")) {
            if ((transform.position.x - 0.5f) % 1 == 0 && (transform.position.y - 0.5f) % 1 == 0) {
                transform.position = pos;
            }
            else {
                switch (Globals.lastDirection) {
                    case Globals.direction.Down:
                        pos = new Vector3(pos.x, Mathf.Floor(pos.y + positionOffsetHelper) - positionOffsetHelper, pos.z);
                        break;
                    case Globals.direction.Up:
                        pos = new Vector3(pos.x, Mathf.Ceil(pos.y + positionOffsetHelper) - positionOffsetHelper, pos.z);
                        break;
                    case Globals.direction.Left:
                        pos = new Vector3(Mathf.Floor(pos.x + positionOffsetHelper) - positionOffsetHelper, pos.y, pos.z);
                        break;
                    case Globals.direction.Right:
                        pos = new Vector3(Mathf.Ceil(pos.x + positionOffsetHelper) - positionOffsetHelper, pos.y, pos.z);
                        break;
                    default:
                        break;
                }
                //float newX = Mathf.Round(transform.position.x + 9999.5f) - 9999.5f;
                //float newY = Mathf.Round(transform.position.y + 9999.5f) - 9999.5f;

                //float diffX = newX - transform.position.x;
                //float diffY = newY - transform.position.y;
                //int direction = 0;

                //if (Mathf.Abs(diffX) > Mathf.Abs(diffY)) {
                //    if (diffX > 0) {
                //        direction = 3;
                //    }
                //    else {
                //        direction = 1;
                //    }
                //}
                //else {
                //    if(diffY > 0) {
                //        direction = 2;
                //    }
                //}
                //animator.SetInteger("Direction", direction);
                //animator.SetBool("Moving", true);
                //pos = new Vector3(newX, newY, transform.position.z);

                animator.SetInteger("Direction", (int)Globals.lastDirection);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        if (transform.position == pos) animator.SetBool("Moving", false);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        pos = originalPosition;
    }
    /////////////////////////////////
    
    private bool IsMoving() {
        return transform.position != pos && animator.GetBool("Moving");
    }

    private void MoveInDirection(Vector3 direction){
		RaycastHit2D raycast = Physics2D.Raycast(transform.position + direction, direction, 0.1f);
		if(raycast.collider && raycast.collider.tag != "Traversable") {
            animator.SetBool("Moving", false);
		}
		else {
            originalPosition = pos;
			animator.SetBool("Moving", true);
			pos += direction;
		}
    }

    public IEnumerator MoveUp() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", (int)Globals.direction.Up);
            MoveInDirection(Vector3.up);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }
    public IEnumerator MoveDown() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", (int)Globals.direction.Down);
            MoveInDirection(Vector3.down);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }
    public IEnumerator MoveLeft() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", (int)Globals.direction.Left);
            MoveInDirection(Vector3.left);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }
    public IEnumerator MoveRight() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", (int)Globals.direction.Right);
            MoveInDirection(Vector3.right);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }

    public void StopMoving() {
            animator.SetBool("Moving", false);
            pos = transform.position;
    }

    public Vector3 GetCurrentDirection() {
        switch (animator.GetInteger("Direction")){
            case 1: return Vector3.left;
            case 2: return Vector3.up;
            case 3: return Vector3.right;

            default: return Vector3.down;
        }
    }
}
