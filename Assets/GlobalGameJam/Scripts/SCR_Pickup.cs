using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Pickup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Vector3 objectPos;
    [SerializeField] GameObject item;
    [SerializeField] Rigidbody itemRigidbody;
    [SerializeField] GameObject temporaryParent;

    [Header("Throwing Variables")]
    [SerializeField] float throwForce = 600f;

    [Header("General Variables")]
    [SerializeField] bool canHold = true;
    [SerializeField] bool isHolding = false;
    [SerializeField] float distance;

    private void Awake()
    {
        itemRigidbody = item.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        distance = Vector3.Distance(item.transform.position, temporaryParent.transform.position);

        if (distance >= 1f)
        {
            isHolding = false;
        }

        if (isHolding)
        {
            itemRigidbody.velocity = Vector3.zero;
            itemRigidbody.angularVelocity = Vector3.zero;
            item.transform.SetParent(temporaryParent.transform);

            if (Input.GetMouseButtonDown(1))
            {
                itemRigidbody.AddForce(temporaryParent.transform.forward * throwForce);
                isHolding = false;
            }

        }

        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            itemRigidbody.useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        if (distance <= 1f)
        {
            isHolding = true;
            itemRigidbody.useGravity = false;
            itemRigidbody.detectCollisions = true;
        }
    }

    void OnMouseUp()
    {
        isHolding = false;
    }
}
