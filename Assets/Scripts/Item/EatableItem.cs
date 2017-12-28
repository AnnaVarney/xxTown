using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableItem : BaseItem {

    public int HealHP {
        get;
        private set;
    }

    public int HealHunger {
        get;
        private set;
    }

    public EatableItem(int id, string name, int type, string icon,string description,int HealHP,int HealHunger) 
        : base(id, name, type, icon, description) {
        this.HealHP = HealHP;
        this.HealHunger = HealHunger;
    }
	
}
