using UnityEngine;
// Importamos el nuevo sistema de entrada de Unity
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ControladorJugador : MonoBehaviour

{
    public Rigidbody2D rb;
    public float velocidad = 5f; 

    private Vector2 direccionMovimiento;

    [SerializeField] 
    private float fuerzaSalto = 5f; // Fuerza del salto

    private float elapsedTime = 6f; // Variable para almacenar el tiempo transcurrido
    [SerializeField]

    private UIDocument uiDocument;

  [SerializeField]
    private ParticleSystem explosionEffect;


    private Label scoreLabel;

    private void Start()
    {
        // Obtener la referencia al Label del puntaje
        scoreLabel = uiDocument.rootVisualElement.Q<Label>("ScoreLabel");
        Mathf.FloorToInt(elapsedTime);
    }

    private void Update()
    {
        UpdateScoreLabel();
        UpdateMovement();
    }



    // Esta función detecta el nuevo sistema automáticamente
     private void UpdateMovement()
    {
    
        
        if(Mouse.current.leftButton.isPressed)
        {
            Debug.Log("the left button is clicked");
             Debug.Log("the current mouse potision on the screen is: " + Mouse.current.position.ReadValue());
              Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
              Debug.Log("the current mouse potision in the world is: " + posicionMundo);

              Vector2 dir = (posicionMundo - gameObject.transform.position).normalized;

              
              Debug.Log("the direction to the mouse position is: " + dir);
              transform.up = dir; 
              rb.AddForce(dir * fuerzaSalto);



              
              

            







        }
        
    }

    private void UpdateScoreLabel()
    {
        elapsedTime += Time.deltaTime; // Incrementar el tiempo transcurrido
        scoreLabel.text = "score:  " + elapsedTime.ToString("F2");
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //transform.position
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }


}
