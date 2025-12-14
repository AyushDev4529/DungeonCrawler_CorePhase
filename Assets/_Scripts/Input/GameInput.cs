using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    //This Script is responsible for handling player input using the new Input System
    //and providing access to movement input data. INTENT only not the button presses.

    PlayerInputActions playerInputActions;
    Vector2 movementInput;
    public Vector2 MovementInput => movementInput;

    // Start is called before the first frame update
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        movementInput = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        Debug.Log("Movement Input: " + movementInput);
    }
}
