using UnityEngine;
using UnityEngine.InputSystem; //Para acceder a los inputs.

public class jump : MonoBehaviour
{
    public float jumpForce;

    public bool keyPressed;

    public bool canJump;

    public Player movement;

    PlayerInput input;

    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //Comprobamos si la tecla salto presionada
        if (input.actions["Jump"].IsPressed())
        {
            if(keyPressed == false)
            {
                if (canJump == true) 
                {

                    keyPressed = true;
                    
                    canJump = false;

                    
                    movement.isJumping = true;

                    //Aplicamos fuerza hacia arriba
                    rb.AddForce(Vector3.up * jumpForce);
                      
                    Debug.Log("Salto");

                }

                
            }
            
        }
        else
        {
            keyPressed = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Comprobar si jugador ha tocado el suelo.
        if (collision.transform.CompareTag("Ground")) 
        {
           
            canJump = true;
            
            movement.isJumping = false;
        
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
           
            canJump = false;

        }
    }
}
