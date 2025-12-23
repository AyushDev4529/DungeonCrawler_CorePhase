using UnityEngine;
using System;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField] CircleCollider2D interactCollider;
    [SerializeField] LayerMask interactableLayer;




    // Event triggered when an interactable is found or changed
    public static event Action<IInteractable> OnInteractableFound;

    // Currently selected interactable in memory
    public IInteractable selectedIntractable;

    private void Awake()
    {
        // Initialize the event to avoid null reference issues
        OnInteractableFound = null;
    }

    // Start is called before the first frame update
    private void Start()
    {

        interactCollider.isTrigger = true;
        interactCollider.radius = interactRange;
    }
    // Update is called once per frame
    private void Update()
    {
        HandleInteractions();

        if (gameInput.IsInteractPressedThisFrame)
        {
            // Attempt to interact with the selected interactable
            selectedIntractable?.Interact(this.gameObject);
        }
    }


    // Handle interactions with nearby interactable objects
    private void HandleInteractions()
    {
        // Check for interactable objects within range
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRange,interactableLayer);

        IInteractable closestInteractable = null;
        float closestDistance = interactRange;
        // Iterate through colliders to find interactable objects
        foreach (var collider in colliders)
        {
            // Check if the collider has an IInteractable component
            IInteractable interactable = collider.GetComponentInParent<IInteractable>();
            
            
            var compareDistance = Vector2.Distance(collider.transform.position, transform.position);
            // If found, call the Interact method
            if (interactable != null && interactable.CanInteract()&& compareDistance < closestDistance)
            {
                closestDistance = compareDistance;
                closestInteractable = interactable;
            }
        }

        // Update the selected interactable if it has changed
        if (closestInteractable != selectedIntractable)
        {
            selectedIntractable = closestInteractable;

            OnInteractableFound?.Invoke(selectedIntractable);
        }
    }

}
