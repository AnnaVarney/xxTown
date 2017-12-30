using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spreadButton : MonoBehaviour {
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    bool ifSpread = true;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void spread() {
        button2.GetComponent<ButtonMove>().enabled = ifSpread;
        button3.GetComponent<ButtonMove>().enabled = ifSpread;
        ifSpread = !ifSpread;

    }
}
