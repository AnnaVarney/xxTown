using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    public GameObject knapsack = null;
    private bool isActive = false;
    private Vector3 showPos = new Vector3(2100, 0, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B)) {
            if (!isActive) {
                knapsack.transform.Translate(-showPos);
                Debug.Log(showPos + "  "+knapsack.transform.position);
                isActive = true;
            }
            else {
                knapsack.transform.Translate(showPos);
                Debug.Log(showPos + "  " + knapsack.transform.position);
                isActive = false;
            }
        }
	}
}
