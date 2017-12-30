using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBackButton : MonoBehaviour {
    public GameObject SettingUI;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void hide() {
        SettingUI.SetActive(false);
    }
}
