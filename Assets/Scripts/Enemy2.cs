using UnityEngine;
using TMPro;

public class ExitZoneTrigger : MonoBehaviour
{
    [Header("Player Settings")]
    public Renderer playerRenderer;       // Renderer del jugador para cambiar material
    public Material newMaterial;          // Nuevo material del jugador

    [Header("Dialogue Settings")]
    public TextMeshProUGUI dialogueText;  // Referencia al texto del diálogo
    public string newDialogue;            // Nuevo texto de diálogo

    [Header("Objects to Manage")]
    public GameObject objectToDisable;    // Objeto que se desactivará al salir de la zona

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que salió es el jugador
        if (other.CompareTag("Player"))
        {
            // Cambia el material del jugador
            if (playerRenderer != null && newMaterial != null)
            {
                playerRenderer.material = newMaterial;
            }

            // Cambia el diálogo
            if (dialogueText != null)
            {
                dialogueText.text = newDialogue;
            }

            // Desactiva el objeto especificado
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
        }
    }
}