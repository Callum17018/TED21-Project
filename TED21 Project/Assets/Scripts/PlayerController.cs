using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(GravityBody))]
public class PlayerController : MonoBehaviour
{
    // Delaring varibles
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;
    public float walkSpeed = 6;
    public float jumpForce = 220;

    // The ground
    public LayerMask groundedMask;

    // Still declearing the varibles
    bool grounded;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    Transform cameraTransform;
    Rigidbody rb;

    // on start 
    void Awake()
    {
        // Hides the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Makes the game camera sit to the player 
        cameraTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
    }

    //Runs every tick
    void Update()
    {

        // Changes the Player direction based on the movement of the mouse
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
        // Locks the vertical direction so you cant keep going up or down
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

        
        float inputX = 0;
        float inputY = 0;
        // Gets Input keys
        if (Input.GetKey("w"))
        {
            inputY += 1;
        }
        if (Input.GetKey("a"))
        {
            inputX -= 1;
        }
        if (Input.GetKey("s"))
        {
            inputY -= 1;
        }
        if (Input.GetKey("d"))
        {
            inputX += 1;
        }

        // Creates a new varible to get where to go the next gameUpdate (frame)
        Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        // Smooths the movement so it isnt jerky
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        // Jump when space key.
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (grounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }

        // check if player is on the ground
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

    }

    // Runs every update (frame)
    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + localMove);
    }

    //Dection of collison with rubbish (touching)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rubbish")
        {
            Destroy(collision.gameObject);
            GameManager.score += 100;
            GameManager.removeRubbish();
        }
    }
}
