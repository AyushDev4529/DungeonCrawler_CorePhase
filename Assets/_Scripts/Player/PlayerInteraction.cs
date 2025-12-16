using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] float interactDistance = 1.5f;
    public LayerMask detectionLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameInput.IsInteractPressedThisFrame)
        {
            CheckForIntractable(gameObject);
            Debug.Log("Interact Pressed");
        }
    }

    protected void CheckForIntractable(GameObject gameObject)
    {
        Collider2D Intractable = Physics2D.OverlapCircle(transform.position, interactDistance, detectionLayer);
    }
}
