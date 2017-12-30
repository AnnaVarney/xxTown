using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour {

    public GameObject player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector3 newPos;
	// Use this for initialization
	void Start () {
        newPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate() {
        if(player.transform.position.x < minX) {
            newPos.x = minX;
        }else if(player.transform.position.x > maxX) {
            newPos.x = maxX;
        }
        else {
            newPos.x = player.transform.position.x;
        }

        if (player.transform.position.y < minY) {
            newPos.y = minY;
        }
        else if (player.transform.position.y > maxY) {
            newPos.y = maxY;
        }
        else {
            newPos.y = player.transform.position.y;
        }
        transform.position = newPos;
    }
}
