using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CypherSquareRemove : MonoBehaviour
{
    public Image gridSquare;
    [SerializeField] bool tileRemoved;

    public void SquarePressed()
    {
        if (!tileRemoved)
        {
            tileRemoved = true;
            gridSquare.enabled = false;
        }
        else if (tileRemoved)
        {
            tileRemoved = false;
            gridSquare.enabled = true;
        }
    }
}
