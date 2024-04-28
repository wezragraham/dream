using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float vInput, hInput, mouseX, mouseY;

    [SerializeField]
    float movementSpeedMultiplier, rotationSpeedMultiplier, stepSpeedMultiplier, walkTimerMax;

    GameObject myCamera;

    bool walking;

    InteractiveItem itemBeingTouched;

    InventoryManager inventoryManager;

    Vector3 cameraMovementDirection, cameraAngles;

    float walkTimer;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
        myCamera = this.transform.GetChild(0).gameObject;
        cameraMovementDirection = myCamera.transform.up;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (vInput < 0 || vInput > 0 || hInput < 0 || hInput > 0)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }

        MovePlayer();

        if (walking)
        {
            walkTimer += Time.deltaTime;
            if (walkTimer > walkTimerMax)
            {
                walkTimer = 0;
                cameraMovementDirection = -cameraMovementDirection;

            }

            CameraWalkingMovement();

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSpeedMultiplier += 2.5f;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movementSpeedMultiplier -= 2.5f;
            }
        }


        if (itemBeingTouched != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                PickupItem();
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        CheckObject(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (itemBeingTouched != null)
        {
            itemBeingTouched = null;
        }
    }



    void PickupItem()
    {
        inventoryManager.AddItem(itemBeingTouched.itemName);
        itemBeingTouched.pickedUp = true;
    }

    //for seeing if a collided object can be added to inventory
    void CheckObject(GameObject other)
    {
        if (other.GetComponent<InteractiveItem>() != null)
        {
            itemBeingTouched = other.GetComponent<InteractiveItem>();
        }
    }

    void MovePlayer()
    {
        transform.Translate(Vector3.forward * vInput * movementSpeedMultiplier * Time.deltaTime);
        transform.Translate(Vector3.right * hInput * movementSpeedMultiplier * Time.deltaTime);

        transform.Rotate(Vector3.up * mouseX * rotationSpeedMultiplier * Time.deltaTime);
        myCamera.transform.Rotate(-Vector3.right * mouseY * rotationSpeedMultiplier * Time.deltaTime);

        cameraAngles = myCamera.transform.rotation.eulerAngles;

        if (cameraAngles.x < 320 && cameraAngles.x > 270)
        {
            myCamera.transform.rotation = Quaternion.Euler(320.0f, cameraAngles.y, cameraAngles.z);
        }
        if (cameraAngles.x > 40 && cameraAngles.x < 90)
        {
            myCamera.transform.rotation = Quaternion.Euler(40.0f, cameraAngles.y, cameraAngles.z);
        }
    }

    void CameraWalkingMovement()
    {
        myCamera.transform.Translate(cameraMovementDirection * (stepSpeedMultiplier) * Time.deltaTime);
    }
}