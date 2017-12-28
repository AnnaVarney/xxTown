using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnGround : MonoBehaviour {
    public int id = 0;
    public string image = "itemicon/item_strawberry";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void iniItem(int id,string image) {
        this.id = id;
        this.image = image;
    }


}
