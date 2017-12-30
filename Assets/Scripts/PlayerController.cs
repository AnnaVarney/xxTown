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
    private bool isbusy = false;
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
        if (!isbusy) {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.K)) {
                anim.SetTrigger("stand_front");
            }

            if (horizontalInput > 0) {
                xsign = 1;
            }
            else if (horizontalInput < 0) {
                xsign = -1;
            }
            else
                xsign = 0;

            if (verticalInput > 0) {
                ysign = 1;
            }
            else if (verticalInput < 0) {
                ysign = -1;
            }
            else
                ysign = 0;

            if (xsign == 0 && ysign == 0) {
                anim.SetBool("ifMove", false);
            }
            else {
                anim.SetBool("ifMove", true);
            }

            deltaDir = Mathf.Abs(horizontalInput) - Mathf.Abs(verticalInput);

            if (deltaDir > 0) {
                if (horizontalInput > 0) {
                    faceDirection = 3;
                }
                else {
                    faceDirection = 2;
                }
            }
            else if (deltaDir < 0) {
                if (verticalInput > 0) {
                    faceDirection = 1;
                }
                else {
                    faceDirection = 0;
                }
            }

            if (faceDirection == 2) {
                transform.localScale = new Vector3(-1, 1, 1);// Debug.Log("turn!");
            }
            else if (faceDirection == 3) {
                transform.localScale = new Vector3(1, 1, 1); //Debug.Log("turn~");
            }
            anim.SetInteger("facedirection", faceDirection);

            transform.Translate(moveSpeed * Time.deltaTime * xsign, moveSpeed * Time.deltaTime * ysign, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

            if (xsign == 0 && ysign == 0) {
                if (Time.time - lastTime > 8) {
                    //Debug.Log(Time.time - lastTime);
                    anim.SetTrigger("stand");
                    ifInput = true;
                    lastTime = Time.time;
                }
            }
            else {
                lastTime = Time.time;
            }
        }
    }

    public void setLastTime() {
        lastTime = Time.time;
    }

    public void isDoingsomething() {
        isbusy = !isbusy;
    }
}
