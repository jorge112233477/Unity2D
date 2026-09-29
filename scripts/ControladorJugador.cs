using UnityEngine;
// Importamos el nuevo sistema de entrada de Unity
using UnityEngine.InputSystem; 

public class ControladorJugador : MonoBehaviour
{
    public float velocidad = 5f; 
    private Rigidbody2D rb;
    private Vector2 direccionMovimiento;

    void Start()
    {
        
    }

    // Esta función detecta el nuevo sistema automáticamente
    void Update()
    {

        if(Mouse.current.leftButton.isPressed)
        {
            Debug.Log("the left button is clicked");
             Debug.Log("the current mouse potision on the screen is: " + Mouse.current.position.ReadValue());

        }
        
    }


}
