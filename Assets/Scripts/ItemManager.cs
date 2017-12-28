
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    public float minY = -10;
    public float maxY = 10;
    public float minX = -10;
    public float maxX = 10;
    public int minNumber = 5;
    public int maxNumber = 10;
    public Object prefab;

	// Use this for initialization
	void Start () {
        randItem();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void randItem() {
        for(int i = 0; i < Random.Range(minNumber, maxNumber); i++) {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            Object temp = Instantiate(prefab, new Vector3(x, y, y), Quaternion.identity);
            temp.name = "itemontheground" + i;
            (temp as GameObject).transform.SetParent(GameObject.Find("ItemManager").transform);
        }
    }
}
