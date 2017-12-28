using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public GameObject player = null;
    public int ap = 10;
	// Use this for initialization
	void Start () {
        //player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
       // Debug.Log("---" + collision.gameObject.tag);
        if(collision.gameObject.tag == "Player") {
            InvokeRepeating("attack", 0.5f, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            CancelInvoke("attack");
        }
    }

    void attack() {
        player.SendMessage("attacked",ap);
    }

    void stopAttack() {
        CancelInvoke("attack");
    }
}
