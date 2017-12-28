using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnapsackManager : MonoBehaviour {

    public static Dictionary<int, BaseItem> ItemList;
    GameObject item;
    public GameObject[] Cells;
    Image iconImage;
    Text numberText;
    int number;
    public GameObject ItemsPool;

    private void Awake() {
        loadItemList();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H)) {
            int randomItem = Random.Range(0, 5);
            //Debug.Log("you pick up a " + ItemList[randomItem].name);
            pickItem(ItemList[randomItem]);
        }
	}

    private void loadItemList() {
        ItemList = new Dictionary<int, BaseItem>();
        EatableItem strawberry = new EatableItem(0, "Strawberry", 1, "itemicon/item_strawberry", "sweet!", 30, 10);
        EatableItem Apple = new EatableItem(1, "Apple", 1, "itemicon/item_Apple", "sweet!", 30, 10);
        EatableItem Orange = new EatableItem(2, "Orange", 1, "itemicon/item_Orange", "sweet!", 30, 10);
        EatableItem Mushroom = new EatableItem(3, "Mushroom", 1, "itemicon/item_Mushroom", "sweet!", 30, 10);
        EatableItem Carrot = new EatableItem(4, "Carrot", 1, "itemicon/item_Carrot", "sweet!", 30, 10);
        ItemList.Add(strawberry.id, strawberry);
        ItemList.Add(Apple.id, Apple);
        ItemList.Add(Orange.id, Orange);
        ItemList.Add(Mushroom.id, Mushroom);
        ItemList.Add(Carrot.id, Carrot);
    }

    public void pickItem(BaseItem pickedItem) {
        //item = Instantiate(Resources.Load("Prefabs/Item"), transform.position, transform.rotation) as GameObject;
        item = ObjectPool.getObject("Item", transform.position, transform.rotation) as GameObject;
        iconImage = item.transform.GetComponent<Image>();
        iconImage.overrideSprite = Resources.Load(pickedItem.icon,typeof(Sprite)) as Sprite;
        //Debug.Log("pickedItem.icon: " + pickedItem.icon);
        //Debug.Log("iconImage.overrideSpride.name: " + iconImage.overrideSprite.name);
        for (int i = 0; i < Cells.Length; i++) {
            if (Cells[i].transform.childCount > 0) {
                if(iconImage.overrideSprite.name == Cells[i].transform.GetChild(0).transform.GetComponent<Image>().overrideSprite.name) {
                    Debug.Log("you already have " + pickedItem.name);
                    Debug.Log(iconImage.overrideSprite.name + "   ----    " + Cells[i].transform.GetChild(0).transform.GetComponent<Image>().overrideSprite.name);
                    numberText = Cells[i].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                    number = int.Parse(numberText.text);
                    number += 1;
                    numberText.text = number.ToString();
                    //Destroy(item);
                    ObjectPool.Return(item);
                    item.transform.SetParent(ItemsPool.transform);
                    item.GetComponent<Info>().setId(pickedItem.id);
                    FoodBagMgr.addItem(pickedItem.id, pickedItem, 1);
                    return;
                }
            }
        

        }

        for(int i = 0; i < Cells.Length; i++) {
            if(Cells[i].transform.childCount == 0) {
                //Debug.Log("iconImage.overrideSpride.name: " + iconImage.overrideSprite.name);
                //Debug.Log("woops! you get a new "+pickedItem.name);
                item.transform.SetParent(Cells[i].transform);
                item.transform.localPosition = Vector3.zero;
                item.GetComponent<Info>().setId(pickedItem.id);
                FoodBagMgr.addItem(pickedItem.id, pickedItem, 1);
                return;
            }
        }
        
    }
}
