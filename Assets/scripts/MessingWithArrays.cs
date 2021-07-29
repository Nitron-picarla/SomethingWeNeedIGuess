using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessingWithArrays : MonoBehaviour
{
    public string[] myStringArray;
    public int x = 0;
    void Start()
    {
        print(myStringArray[x]); 
    }
}
