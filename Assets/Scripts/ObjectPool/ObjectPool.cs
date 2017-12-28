using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    private static Dictionary<string, ArrayList> pool = new Dictionary<string, ArrayList>();

    public static Object getObject(string prefabName,Vector3 position,Quaternion rotation) {
        string key = prefabName + "(Clone)";
        Object obj;
        if(pool.ContainsKey(key) && pool[key].Count > 0) {
            ArrayList list = pool[key];
            obj = list[0] as Object;
            list.RemoveAt(0);
            if(obj == null) {
                obj = Instantiate(Resources.Load("Prefabs/" + prefabName), position, rotation);
            }
            (obj as GameObject).SetActive(true);
            (obj as GameObject).transform.position = position;
            (obj as GameObject).transform.rotation = rotation;
        }
        else {
            obj = Instantiate(Resources.Load("Prefabs/" + prefabName), position, rotation);
        }
        return obj;
    }

    public static Object Return(GameObject obj) {
        string key = obj.name;
        if (pool.ContainsKey(key)) {
            ArrayList list = pool[key];
            list.Add(obj);
        }
        else {
            pool[key] = new ArrayList { obj };
        }
        obj.SetActive(false);
        return obj;
    }
}
