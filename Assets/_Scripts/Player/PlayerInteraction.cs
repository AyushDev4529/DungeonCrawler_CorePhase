using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField]CircleCollider2D interactCollider;
    

    // Start is called before the first frame update
    public void Start()
    {
        interactCollider.isTrigger = true;
        interactCollider.radius = interactRange;
    }
    // Update is called once per frame
    public void Update()
    {
        if (gameInput.IsInteractPressedThisFrame)
        {
            // Check for interactable objects within range
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRange);

            // Iterate through colliders to find interactable objects
            foreach (var collider in colliders)
            {
                // Check if the collider has an IInteractable component
                IInteractable interactable = collider.GetComponentInParent<IInteractable>();

                // If found, call the Interact method
                if (interactable != null && interactable.CanInteract())
                {
                    interactable.Interact(this.gameObject);
                    break; // Interact with the first valid interactable found
                }
            }

        }
    }

}
