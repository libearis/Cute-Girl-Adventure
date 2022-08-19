using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleBox : MonoBehaviour
{
    public static PuzzleBox instance;
    public Transform boxField;
    public int maxBox;
    public GameObject prefab;
    GameObject button;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        for (int index = 0; index < maxBox; index++)
        {
            button = Instantiate(prefab);
            button.name = "" + index;
            button.transform.SetParent(boxField, false);
        }
    }

    
}
