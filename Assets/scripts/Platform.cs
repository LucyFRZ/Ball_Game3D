using UnityEngine;

public class Platform : MonoBehaviour
{
    //Tiempo en el que se tarda en destruir la plataforma.
    public float timetoDestroy = 3f;

    //Cuenta el tiempo que pasa.
    public float timer;

    public bool playerTouch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTouch == true)
        {
            timer += Time.deltaTime;
            
            if(timer > timetoDestroy)
            {
               
                Destroy(gameObject);
            }
        }    
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.transform.CompareTag("Player")) 
        {

            
            playerTouch = true;
        }
    }
}
