using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; //LIbreria para reiniciar escena
public class Player : MonoBehaviour
{
   
    PlayerInput input;
    
    private Vector2 movement;

    private Vector3 direction;

    [Header("Parameters")]
    
    [SerializeField] private float speed = 10;

    private Vector3 jumpDirection;
   
    public bool isJumping;

    public float limitY;

    //Punto de referencia si el jugador se cae al vacio.
    public GameObject spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
        movement = input.actions["Move"].ReadValue<Vector2>();

       
        direction = new Vector3(movement.x, 0f, movement.y);

        
        direction = transform.TransformDirection(direction);

        if (isJumping == false)
        {
            //El personaje no esta saltando la direccion del salto es la misma que la normal.
            //En el momento en el que el personaje salte la dirección del salto no se puede cambiar, hasta que el personaje acabe el salto.
            jumpDirection = direction;

        }

        if (isJumping == true)
        {
            //Como el personaje está saltando se queda en la misma posición de dirección de movimiento.
            transform.position += jumpDirection * speed * Time.deltaTime;
        }
        else
        {
          
            transform.position += direction * speed * Time.deltaTime;

        }

        //Comprobamos si player ha llegado al limite.
        if (transform.position.y <= limitY) 
        {
            //Movemos al jugador a la posición del Spawn
            transform.position = spawnPoint.transform.position;
        
        }

        if (input.actions["Reset"].IsPressed())
        {
            SceneManager.LoadScene(0);
        }

    }


}
