
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] GameInput gameInput;
    
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] float moveSpeed = 7f;
    public Vector2 PlayerDirection => direction;
    public float MoveSpeed => moveSpeed;
    



    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        direction = gameInput.MovementInput;

    }
    // Update is called once per frame
    private void FixedUpdate()
    {


        // Move the player based on input
        var newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
        // Update the Rigidbody2D position
        rb.MovePosition(newPosition);

    }
}
