using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBagMgr {

    private static Dictionary<int, ItemInfo> FoodBag = new Dictionary<int, ItemInfo>();

    public static void addItem(int item_id,BaseItem item,int addNumber) {
        if (FoodBag.ContainsKey(item_id)) {
            FoodBag[item_id].changeQuantity(addNumber);
        }
        else {
            ItemInfo item_info = new ItemInfo(item, addNumber);
            FoodBag.Add(item_id, item_info);
        }
        //Debug.Log(FoodBag[item_id].getQuantity() + " " + FoodBag[item_id].getItem().name);

        /*Debug.Log("-------");
        foreach (ItemInfo temp in FoodBag.Values) {
            Debug.Log(temp.getItem().name + ": " + temp.getQuantity());
        }
        Debug.Log("-------");*/
    }

    public static void consumeItem(int item_id,int consumeNumber) {
        if (FoodBag.ContainsKey(item_id)) {
            if(FoodBag[item_id].getQuantity() >= consumeNumber) {
                if(FoodBag[item_id].changeQuantity(-consumeNumber) <= 0) {
                    FoodBag.Remove(item_id);
                }
            }
            else {
               // Debug.Log("not enough **[" + FoodBag[item_id].getItem().name+"]**");
            }
           /* Debug.Log("-------");
            foreach (ItemInfo temp in FoodBag.Values) {
                Debug.Log(temp.getItem().name + ": " + temp.getQuantity());
            }
            Debug.Log("-------");*/
        }
    }
}
