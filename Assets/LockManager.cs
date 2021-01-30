using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public GameObject lockSlotOne;
    public GameObject lockSlotTwo;
    public GameObject lockSlotThree;
    public GameObject lockSlotFour;
    public int correctCode1, correctCode2, correctCode3, correctCode4;
    private bool oneCorrect, twoCorrect, threeCorrect, fourCorrect = false;
    private bool lockOpen;

    // Update is called once per frame
    void Update()
    {
        BoolUpdate();
        if (oneCorrect && twoCorrect && threeCorrect && fourCorrect)
        {
            lockOpen = true;
        }
        else
        {
            lockOpen = false;
        }
    }

    bool CodeChecker(GameObject slot, int rightDigit)
    {
        return (slot.GetComponent<CodeLogic>().digit == rightDigit);
    }

    void BoolUpdate()
    {
        oneCorrect = CodeChecker(lockSlotOne, correctCode1);
        twoCorrect = CodeChecker(lockSlotTwo, correctCode2);
        threeCorrect = CodeChecker(lockSlotThree, correctCode3);
        fourCorrect = CodeChecker(lockSlotFour, correctCode4);
    }
}
