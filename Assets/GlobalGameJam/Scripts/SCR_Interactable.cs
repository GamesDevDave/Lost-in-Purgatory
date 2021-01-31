using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_Interactable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject guideReference;
    [SerializeField] GameObject uiNoteCanvas;
    [SerializeField] GameObject playerGameObject;
    [SerializeField] GameObject instantiatedNote;

    [Header("Guide Variables")]
    [SerializeField] float guideDistance;
    private bool displayMessage = false;

    [Header("Key Variables")]
    [SerializeField] bool keyRetrieved;
    [SerializeField] string keyRetrievedString;

    // Update is called once per frame
    void Update()
    {

        guideDistance = Vector3.Distance(this.transform.position, guideReference.transform.position);

        if (gameObject.tag == "Note")
        {
            if (Input.GetMouseButtonDown(0) && guideDistance < 2)
            {
                NoteAction();
            }
        }
        else if (gameObject.tag == "Key")
        {
            if (Input.GetMouseButtonDown(0) && guideDistance < 2)
            {
                KeyAction();
            }
        }
        else if(gameObject.tag == "Cup") 
        {
            if(Input.GetMouseButtonDown(0) && guideDistance < 1 && TeaPuzzle.teaPoured)
            {
                TeaAction();
            }
        }
    }

    void NoteAction()
    {
        if (instantiatedNote == null)
        {
            instantiatedNote = Instantiate(uiNoteCanvas);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            Destroy(instantiatedNote);
        }
    }

    void KeyAction()
    {
        keyRetrieved = true;
    }

    void TeaAction()
    {
        keyRetrieved = true;
    }

    void OnGUI()
    {
        if (keyRetrieved && !displayMessage)
        {
            GUI.color = Color.black;
            GUI.Label(new Rect(10, 10, 400, 20), keyRetrievedString);
            StartCoroutine(displayCountdown());
        }
    }
    IEnumerator displayCountdown()
    {
        yield return new WaitForSeconds(5f);
        displayMessage = true;
    }
}
