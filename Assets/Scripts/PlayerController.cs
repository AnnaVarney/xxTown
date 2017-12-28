using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    public float moveSpeed = 0.5f;

    private float horizontalInput = 0;
    private float verticalInput = 0;

    private bool ifInput = false;
    private float lastTime;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        ifInput = false;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            animator.SetBool("flank_run", true);
            animator.SetBool("idle", false);
            //transform.GetComponent<SpriteRenderer>().flipX = true;
            Debug.Log("?");
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            animator.SetBool("flank_run", false);
            animator.SetBool("idle", true);
            //transform.GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            ifInput = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            animator.SetBool("flank_run", true);
            animator.SetBool("idle", false);
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            animator.SetBool("flank_run", false);
            animator.SetBool("idle", true);
            ifInput = true;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("back_run", true);
            animator.SetBool("idle", false);
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.up);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            animator.SetBool("back_run", false);
            animator.SetBool("idle", true);
            ifInput = true;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            animator.SetBool("front_run", true);
            animator.SetBool("idle", false);
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.down);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            animator.SetBool("front_run", false);
            animator.SetBool("idle", true);
            ifInput = true;
        }

        if (!ifInput) {
            if (Time.time - lastTime > 8) {
                Debug.Log(Time.time - lastTime);
                animator.SetTrigger("akimbo");
                ifInput = true;
                lastTime = Time.time;
            }
        }
        else {
            lastTime = Time.time;
        }
    }
}
