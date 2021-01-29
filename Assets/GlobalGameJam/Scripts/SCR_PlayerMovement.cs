using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CharacterController playerCharacterController;
    [SerializeField] bool playerGrounded;
    [SerializeField] Vector3 playerVelocity;

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
        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * xInput + transform.forward * zInput;

        playerCharacterController.Move(moveDirection * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        playerCharacterController.Move(playerVelocity * Time.deltaTime);
    }
}
