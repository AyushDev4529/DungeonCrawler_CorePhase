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
        if(playerMovement.PlayerDirection != Vector2.zero )
        {
            SetFacingDirection();
        }
    }

    // Determine the facing direction based on movement input
    public enum FacingDirection
    {
        Up,
        Down,
        Left,
        Right
    }
    public FacingDirection CheckFacingDirection(Vector2 direction)
    {
        float bias = 0.01f; // Bias towards horizontal movement
        directionX = math.abs(direction.x);
        directionY = math.abs(direction.y);
        if (directionX == 0 && directionY == 0)
        {
            // No movement input, do not change sprite
            return FacingDirection.Down;
        }
        else if (directionX > directionY+bias )
        {
            if (direction.x > 0.5)
            {
                return FacingDirection.Right;
            }
            else
            {
                return FacingDirection.Left;
            }
        }
        else
        {
            if (direction.y > 0.5)
            {
                return FacingDirection.Up;
            }
            else
            {
                return FacingDirection.Down;
            }
        }
        


    }
    public void SetFacingDirection()
    {
        FacingDirection currentDirection = CheckFacingDirection(playerMovement.PlayerDirection);
        if (currentDirection == FacingDirection.Left)
        {
            playerVisual.flipX = true;
        }
        else if(currentDirection == FacingDirection.Right)
        {
            playerVisual.flipX = false;
        }
        playerVisual.sprite = currentDirection switch
        {
            FacingDirection.Up => backSprite,
            FacingDirection.Down => frontSprite,
            FacingDirection.Left or FacingDirection.Right => sideSprite,
            _ => frontSprite,
        };

    }
}
    


