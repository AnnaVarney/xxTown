using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    bool ifFindPlayer = false;
    Transform target = null;
    public float speed = 1.0f;
    public Animator animator;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (ifFindPlayer) {
            transform.localPosition = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            if (target.position.x - transform.position.x < 0) {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            //Debug.Log("find player!");
            ifFindPlayer = true;
            target = collision.gameObject.transform;
            animator.SetBool("chase", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            //Debug.Log("lose the player");
            ifFindPlayer = false;
            target = null;
            animator.SetBool("chase", false);
        }
    }
    
    void born() {
        animator.Play("tree_born");
    }
}
