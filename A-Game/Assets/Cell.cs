using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public static GameObject MakeObj(Vector2 pos, Transform parent)
    {
        GameObject obj = new GameObject("Cell");
        Cell cell = obj.AddComponent<Cell>();
        obj.transform.position = pos;
        obj.transform.parent = parent;
        return obj;
    }


}
