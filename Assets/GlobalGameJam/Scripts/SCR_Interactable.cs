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
            if (Input.GetMouseButtonDown(0) && guideDistance < 1)
            {
                KeyAction();
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

    void OnGUI()
    {
        if (keyRetrieved)
        {
            GUI.Label(new Rect(10, 10, 200, 20), keyRetrievedString);
        }
    }
}
