﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_HoldingHUD : MonoBehaviour
{

    [SerializeField] SCR_Pickup pickupScript;
    [SerializeField] GameObject holdingGUI;

    // Start is called before the first frame update
    void Start()
    {
        pickupScript = pickupScript.GetComponent<SCR_Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupScript.isHolding)
        {
            holdingGUI.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            holdingGUI.GetComponent<Canvas>().enabled = false;
        }
    }
}
