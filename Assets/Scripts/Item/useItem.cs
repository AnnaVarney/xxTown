using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class useItem : MonoBehaviour,IPointerDownHandler {
    GameObject item;
    Text numberText;
    int number;
    public GameObject ItemsPool;
	// Use this for initialization
	void Start () {
        ItemsPool = GameObject.Find("Knapsack").transform.Find("ItemsPool").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData) {
        if (Input.GetMouseButtonDown(1)) {
            numberText = transform.GetChild(0).GetComponent<Text>();
            int item_id = transform.GetComponent<ItemInfo>().getItem().id;
            number = int.Parse(numberText.text);
            if(number > 1) {
                number -= 1;
                numberText.text = number.ToString();
                
                FoodBagMgr.consumeItem(item_id, 1);
            }
            else {
                item = eventData.pointerCurrentRaycast.gameObject;
                //Destroy(item);
                ObjectPool.Return(item);
                //Debug.Log("use a " + item.name);
                FoodBagMgr.consumeItem(item_id, 1);
                item.transform.SetParent(ItemsPool.transform);
            }
        }
    }
}
