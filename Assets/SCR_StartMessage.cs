using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_StartMessage : MonoBehaviour
{

    bool displayMessage = true;

    public string startMessage = "*Yawn* I should probably go check the mail.";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(displayCountdown());
    }

    private void OnGUI()
    {
        if (displayMessage)
        {
            GUI.Label(new Rect(10, 10, 300, 20), startMessage);
        }
    }

    IEnumerator displayCountdown()
    {
        yield return new WaitForSeconds(5f);
        displayMessage = false;
    }
}
