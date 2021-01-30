using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController playerCharacterController;
    [SerializeField] bool playerGrounded;
    [SerializeField] Vector3 playerVelocity;
    public GameObject cypherObject;

    [Header("Movement Settings")]
    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = -9.81f;

    [Header("Ground Checking Settings")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;


    // Start is called before the first frame update
    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = Physics.CheckSphere(groundCheck.position, groundDistance);

        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        else
        {
            playerVelocity.y += gravity;
        }

        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.right * xInput + transform.forward * zInput;

        playerCharacterController.Move(moveDirection.normalized * speed * Time.deltaTime);
        playerCharacterController.Move(playerVelocity * Time.deltaTime);
    }
}
