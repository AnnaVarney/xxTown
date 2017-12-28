using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour {

    private int item_id;
    public int id = 1;
    public string name = "1";
    public int type = 1;
    public string icon = "itemicon/item_strawberry";
    public string description = "1";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setId(int id) {
        item_id = id;
    }

    public int getId() {
        return item_id;
    }
}
