using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_Level1Door : MonoBehaviour
{

    public Vector3 doorEndRotation = new Vector3(0, 20, 0);
    public SCR_Interactable interactableScript;
    [SerializeField] float distance;
    [SerializeField] Transform player;
    [SerializeField] GameObject fadeCanvas;
    bool canSwitch;

    private void Start()
    {
        interactableScript = interactableScript.GetComponent<SCR_Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactableScript.keyRetrieved)
        {
            if (Vector3.Distance(this.transform.position, player.position) < 5f && Input.GetMouseButtonDown(0))
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(doorEndRotation), .3f);
                fadeCanvas.SetActive(true);
                Invoke("LevelSwitch", 2f);
            }
        }
    }

    void LevelSwitch()
    {
        SceneManager.LoadScene("SCN_Level2");
    }
}
