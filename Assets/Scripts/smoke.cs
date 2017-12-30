using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour {
    public Material m_matBG;
    public float moveSpeed = 1.0f;
    private float m_fOffset = 0.0f;
    // Use this for initialization
    void Start () {
		
	}



    void Update() {
        m_matBG.mainTextureOffset += new Vector2(Time.deltaTime * moveSpeed * 0.02f, 0);
    }
}
