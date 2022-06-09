using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class J : MonoBehaviour
{
    public static List<GameObject> Find_Child_List(string name, GameObject rootObject)
    {
        List<GameObject> childList = new List<GameObject>();

        Transform[] allChild = rootObject.GetComponentsInChildren<Transform>();

        foreach(var child in allChild)
        {
            if(child == rootObject.transform) continue;

            if(child.name == name)
            {
                childList.Add(child.gameObject);
                Debug.Log(child.name + ": ADD !");
            } 
        }

        return childList;
    }
}
