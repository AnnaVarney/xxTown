using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;
    public float moveSpeed = 0.5f;

    private float horizontalInput = 0;
    private float verticalInput = 0;

    private int faceDirection = 0; // 0 front 1 back  2 left 3 right 

    private bool ifInput = false;
    private float lastTime;

    private float deltaDir = 0;
    private int xsign = 1;
    private int ysign = 1;
	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.K)) {
            anim.SetTrigger("stand_front");
        }

        if (horizontalInput > 0) {
            xsign = 1;
        } else if (horizontalInput < 0) {
            xsign = -1;
        } else
            xsign = 0;

        if (verticalInput > 0) {
            ysign = 1;
        }
        else if (verticalInput< 0) {
            ysign = -1;
        }
        else
            ysign = 0;

        if(xsign == 0 && ysign == 0) {
            anim.SetBool("ifMove", false);
        }
        else {
            anim.SetBool("ifMove", true);
        }

        deltaDir = Mathf.Abs(horizontalInput) - Mathf.Abs(verticalInput);
        /*if (faceDirection == 2 && horizontalInput > 0) {
            transform.localScale = new Vector3(1, 1, 1); Debug.Log("turn!");
        }
        else if (faceDirection == 3 && horizontalInput < 0) {
            transform.localScale = new Vector3(-1, 1, 1); Debug.Log("turn~");
        }*/
        if (deltaDir > 0) {
            if(horizontalInput > 0) {
                faceDirection = 3;
            }
            else {
                faceDirection = 2;
            }
        }else if(deltaDir < 0) {
            if(verticalInput > 0) {
                faceDirection = 1;
            }
            else {
                faceDirection = 0;
            }
        }

        if (faceDirection == 2 ) {
            transform.localScale = new Vector3(-1, 1, 1); Debug.Log("turn!");
        }
        else if (faceDirection == 3) {
            transform.localScale = new Vector3(1, 1, 1); Debug.Log("turn~");
        }
        anim.SetInteger("facedirection", faceDirection);

        transform.Translate(moveSpeed * Time.deltaTime * xsign, moveSpeed * Time.deltaTime * ysign, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);


        /*
        ifInput = false;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            anim.SetBool("flank_run", true);
            anim.SetBool("idle", false);
            transform.localScale = new Vector3(-1, 1, 1);
            
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) {
            anim.SetBool("flank_run", false);
            anim.SetBool("idle", true);
            transform.localScale = new Vector3(1, 1, 1);
            ifInput = true;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("flank_run", true);
            anim.SetBool("idle", false);
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            anim.SetBool("flank_run", false);
            anim.SetBool("idle", true);
            ifInput = true;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            anim.SetBool("back_run", true);
            anim.SetBool("idle", false);
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.up);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            anim.SetBool("back_run", false);
            anim.SetBool("idle", true);
            ifInput = true;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            anim.SetBool("front_run", true);
            anim.SetBool("idle", false);
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.down);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            ifInput = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {
            anim.SetBool("front_run", false);
            anim.SetBool("idle", true);
            ifInput = true;
        }

        if (!ifInput) {
            if (Time.time - lastTime > 8) {
                Debug.Log(Time.time - lastTime);
                anim.SetTrigger("stand");
                ifInput = true;
                lastTime = Time.time;
            }
        }
        else {
            lastTime = Time.time;
        }*/
    }
}
