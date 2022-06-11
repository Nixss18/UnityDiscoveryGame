using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    public int KeyAmount;

    public AudioSource sfx;

    public AudioSource monsterChaseSfx;

    public GameObject monster;
    public GameObject monster2;


    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void OnTriggerEnter(Collider other){ //atslegu skaits
        if(other.tag == "Key"){
            sfx.Play();
            KeyAmount += 1;
            Destroy(other.gameObject);
        }
        else if(other.tag == "KeyAndActivateMonster"){ //aktivizē ka monstrs ķer speletaju
            monsterChaseSfx.Play();
            KeyAmount +=1;
            Destroy(other.gameObject);
            monster.SetActive(true);
        }
        else if(other.tag == "KeyAndActivateMonster2"){ //aktivizē ka monstrs ķer speletaju
            monsterChaseSfx.Play();
            KeyAmount +=1;
            Destroy(other.gameObject);
            monster2.SetActive(true);
        }
        else if(other.tag == "DisableMonsterChase"){ //ja ieiet triggeri DisableMonsterChase izsledz monstru
            monster.SetActive(false);
        }
        else if(other.tag == "DisableMonsterTriggerChase2"){ //ja ieiet triggeri DisableMonsterChase izsledz monstru
            monster2.SetActive(false);
        }
    }
}
