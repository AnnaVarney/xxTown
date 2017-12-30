using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour {
    public float moveX = 100f;
    public float speed = 200;
    public bool  isLeft = false;
    private Vector3 newPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
	}
    private void OnEnable() {
        getNewPos();
    }

    void getNewPos() {
        newPos = transform.position;
        if (isLeft) {
            newPos.x -= moveX;
            isLeft = false;
        }
        else {
            newPos.x += moveX;
            isLeft = true;
        }
    }

}
