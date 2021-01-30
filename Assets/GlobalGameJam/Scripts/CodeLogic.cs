using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeLogic : MonoBehaviour
{
    public int digit;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = digit.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (digit == 10)
        {
            digit = 0;
        }
        if(digit == -1)
        {
            digit = 9;
        }
        this.GetComponent<TextMeshProUGUI>().text = digit.ToString();

    }

    public void DigitUp()
    {
        digit++;
    }

    public void DigitDown()
    {
        digit--;
    }
}
