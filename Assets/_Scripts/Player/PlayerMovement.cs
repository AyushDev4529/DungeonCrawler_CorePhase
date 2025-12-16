
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] GameInput gameInput;
    
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] float moveSpeed = 7f;
    public Vector2 PlayerDirection => direction;



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
        var newPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
        
        rb.MovePosition(newPosition);

    }
}
