using UnityEngine;

public class SelectedVisual : MonoBehaviour
{
    [SerializeField] GameObject selectedHighlight;

    IInteractable currentInteractable;


    private void Awake()
    {
        currentInteractable = GetComponent<IInteractable>();
    }
    private void OnEnable()
    {
        PlayerInteraction.OnInteractableFound += HighlightInteractable;
    }

    private void OnDisable()
    {
        PlayerInteraction.OnInteractableFound -= HighlightInteractable;
    }

    void HighlightInteractable(IInteractable interactable)
    {
        if (interactable == currentInteractable)
            selectedHighlight.SetActive(true);
        else
            selectedHighlight.SetActive(false);
    }
}