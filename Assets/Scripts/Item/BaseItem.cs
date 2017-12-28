using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem{

    public int id {
        get;
        private set;
    }
    public string name {
        get;
        private set;
    }

    public int type{
        get;
        private set;
    }

    public string icon {
        get;
        private set;
    }

    /*public string image {
        get;
        private set;
    }*/ 

    public string description {
        get;
        private set;
    }

    public BaseItem(int id,string name,int type,string icon,string description) {
        this.id = id;
        this.name = name;
        this.type = type;
        this.icon = icon;
        this.description = description;
    }
}

