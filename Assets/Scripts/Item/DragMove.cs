using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragMove : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler, IPointerDownHandler {

    public GameObject ItemsPool;
    public GameObject Player;
    GameObject tempObject;
    GameObject item;
    Text numberText;
    int number;
    // Use this for initialization
    void Start () {
        ItemsPool = GameObject.Find("Knapsack").transform.Find("ItemsPool").gameObject;
        Player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrag(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            GetComponent<RectTransform>().pivot.Set(0, 0);
            transform.position = Input.mousePosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            tempObject = transform.parent.gameObject;
            transform.SetParent(ItemsPool.transform, true);
            transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

    }

    public void OnEndDrag(PointerEventData eventData) {
        if(eventData.button == PointerEventData.InputButton.Left) {
            Debug.Log("HIT " + eventData.pointerCurrentRaycast.gameObject.tag);
            if(eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "Cell" && eventData.pointerCurrentRaycast.gameObject.transform.childCount < 1) {
                //条件可以优化
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                Debug.Log("in the Cell");
            }
            else if(eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "Item") {
                Transform exchangeTransform = eventData.pointerCurrentRaycast.gameObject.transform;
                Transform exchangeParentTransform = exchangeTransform.parent.transform;
                exchangeTransform.SetParent(tempObject.transform, true);
                exchangeTransform.localPosition = Vector3.zero;
                transform.SetParent(exchangeParentTransform);
                Debug.Log("in the Item");
            }
            else {
                transform.SetParent(tempObject.transform, true);
            }
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.localPosition = Vector3.zero;
            transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (Input.GetMouseButtonDown(1)) {
            numberText = transform.GetChild(0).GetComponent<Text>();
            int item_id = transform.GetComponent<Info>().getId();
            number = int.Parse(numberText.text);
            if (number > 1) {
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
            Player.SendMessage("useItem", 8);
        }
    }
}
