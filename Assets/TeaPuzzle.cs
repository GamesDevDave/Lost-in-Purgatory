using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaPuzzle : MonoBehaviour
{
    public static bool teaPoured;

    // Start is called before the first frame update
    void Start()
    {
        teaPoured = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.GetComponent<SCR_Pickup>().isRotating)
        {
            teaPoured = true;
        }
        
    }
}
