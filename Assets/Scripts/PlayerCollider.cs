using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {

    private Dictionary<string, Collider2D> items;

	// Use this for initialization
	void Start () {
        items = new Dictionary<string, Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F)) {
            if(items.Count > 0) {
                foreach (KeyValuePair<string,Collider2D> temp in items) {
                    BaseItem tempItem = new BaseItem(temp.Value.gameObject.GetComponent<Info>().id,
                        temp.Value.gameObject.GetComponent<Info>().name,
                        temp.Value.gameObject.GetComponent<Info>().type,
                        temp.Value.gameObject.GetComponent<Info>().icon,
                        temp.Value.gameObject.GetComponent<Info>().description);
                    GameObject.Find("Knapsack").transform.Find("Grids1").GetComponent<KnapsackManager>().pickItem(tempItem);
                    GameObject.Find("HitText").GetComponent<Text>().text = GameObject.Find("HitText").GetComponent<Text>().text +  "你获得了" + tempItem.name +" x1\n";
                    items.Remove(temp.Value.gameObject.name);
                    Destroy(temp.Value.gameObject);
                    break;
                }

            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collider) {
       // Debug.Log(collider.gameObject.name+ " in the trigger  "+collider.tag);
        if(collider.gameObject.tag == "itemonground") {
            if (!items.ContainsKey(collider.gameObject.name)) {
                items.Add(collider.gameObject.name, collider);
            }
        }    
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "itemonground") {
            if (items.ContainsKey(collider.gameObject.name)) {
                items.Remove(collider.gameObject.name);
            }
        }
    }
}
