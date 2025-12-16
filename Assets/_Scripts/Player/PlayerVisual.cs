using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
   [SerializeField] PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;
    float CurrentFacingDirectionX ;
    float TargetFacingDirectionX;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentFacingDirectionX = playerMovement.PlayerDirection.x;
        
        if (CurrentFacingDirectionX > 0.01f )
        {
            
            spriteRenderer.flipX = false;
            //Debug.Log(playerMovement.PlayerDirection);
        }
        else if(CurrentFacingDirectionX < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
        


    }
}
