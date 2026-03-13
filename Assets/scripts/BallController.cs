using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    
    private PlayerInput input;

    
    private Rigidbody rb;

     
    private Vector2 InputMovement;

    private Vector3 direction;

    [Header("Parameters")]
    
    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 10;
    




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>(); 

    }

    // Update is called once per frame
    void Update()
    {
        InputMovement = input.actions["Move"].ReadValue<Vector2>();
        direction.x = InputMovement.x;
        direction.z = InputMovement.y;

    } 

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode.Impulse);
        

    }
    public void Jump(InputAction.CallbackContext callbackContext)
    {
      
        if (callbackContext.performed)
        {
          
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

}
