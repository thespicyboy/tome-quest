using UnityEngine;
using UnityEngine.InputSystem;

//automatically add missing component to parent object, in this case a CharacterController
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField]
    private InputActionReference jumpControl;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float rotationSpeed = 4.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraMainTrans;

    //enable input actions?? when parent object is enabled maybe?
    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }
    //disable input actions?? when parent object is disabled maybe?
    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
    }


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTrans = Camera.main.transform;
    }

    void Update()
    {
        //keep player on ground
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //read movement input vector from mouse or gamepad joystick
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Debug.Log("Movement Values " + movement);

        //assign 2d movement input to 3d movement vector target
        Vector3 moveTarget = new Vector3(movement.x, 0f, movement.y);
        moveTarget = cameraMainTrans.forward * moveTarget.z + cameraMainTrans.right * moveTarget.x;
        moveTarget.y = 0f;
        controller.Move(moveTarget * Time.deltaTime * playerSpeed); //apply movement velocity
        

        // Changes the height position of the player..
        if (jumpControl.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Debug.Log("Jump!");
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        //rotate player towards input rotation, considering camera position
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTrans.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
