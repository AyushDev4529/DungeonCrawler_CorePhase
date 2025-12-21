using Unity.Mathematics;
using UnityEngine;

public class PlayerFacingDirection : MonoBehaviour
{
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] Sprite sideSprite;
    [SerializeField] SpriteRenderer playerVisual;
    [SerializeField] PlayerMovement playerMovement;
    float directionX, directionY;
    public enum FacingDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    
    private void Awake()
    {
        if (playerVisual == null)
        {
            Debug.LogWarning("Player Visual SpriteRenderer is not assigned.");
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        var newFacingDirection = CheckFacingDirection(playerMovement.PlayerDirection, currentDirection);
            currentDirection = newFacingDirection;
            ApplyFacingDirection();        
       
    }

    // Determine the facing direction based on movement input
    
    public FacingDirection CheckFacingDirection(Vector2 direction, FacingDirection currentFacingDirection)
    {
        float bias = 0.01f; // Bias towards horizontal movement
        directionX = Mathf.Abs(direction.x);
        directionY = Mathf.Abs(direction.y);
        // No movement input, do not change sprite
        if (directionX < bias && directionY < bias) return currentFacingDirection;
        // Determine dominant direction with bias
        if (directionX > directionY+bias )
        {
            if (direction.x > 0) return FacingDirection.Right;

            if(direction.x < 0) return FacingDirection.Left;

        }
        else 
        {
            if (direction.y > 0) return FacingDirection.Up;
 
            if (direction.y < 0) return FacingDirection.Down;

        }

        return currentFacingDirection;

    }

    private FacingDirection currentDirection = FacingDirection.Down;
    public void ApplyFacingDirection()
    {
        switch(currentDirection)
        {
            case FacingDirection.Up:
                playerVisual.sprite = backSprite;
                playerVisual.flipX = false;
                break;
            case FacingDirection.Down:
                playerVisual.sprite = frontSprite;
                playerVisual.flipX = false;
                break;
            case FacingDirection.Left:
                playerVisual.sprite = sideSprite;
                playerVisual.flipX = false;
                break;
            case FacingDirection.Right:
                playerVisual.sprite = sideSprite;
                playerVisual.flipX = true;
                break;
        }

    }
}
    


