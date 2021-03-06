using UnityEngine;

public class SCR_Pickup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Vector3 objectPos;
    [SerializeField] GameObject item;
    [SerializeField] Rigidbody itemRigidbody;
    [SerializeField] GameObject temporaryParent;
    [SerializeField] GameObject cameraObject;

    [Header("Throwing Variables")]
    [SerializeField] float throwForce = 600f;

    [Header("General Variables")]
    [SerializeField] bool canHold = true;
    [SerializeField] bool isHolding = false;
    [SerializeField] float distance;
    [SerializeField] float rotationSpeed;

    private void Awake()
    {
        itemRigidbody = item.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ObjectRotate();
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

    void ObjectRotate()
    {
        if(Input.GetKey(KeyCode.E) && isHolding)
        {
            Debug.Log("Rotating");
            cameraObject.GetComponent<SCR_MouseLook>().enabled = false;
            this.transform.Rotate((Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime), 0, (Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime), Space.World);
        }
        else
        {
            cameraObject.GetComponent<SCR_MouseLook>().enabled = true;
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
