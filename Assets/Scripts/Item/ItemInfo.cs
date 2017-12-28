using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo{

    BaseItem item;
    int quantity;

    public ItemInfo(BaseItem item,int quantity) {
        this.item = item;
        this.quantity = quantity;
    }

    public int getQuantity() {
        return this.quantity;
    }

    public int changeQuantity(int quantity) {
        this.quantity += quantity;
        return this.quantity;
    }

    public BaseItem getItem() {
        return this.item;
    }

}
