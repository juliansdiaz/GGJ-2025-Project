using UnityEngine;
using TMPro;

public class ZoneInteractionWithText : MonoBehaviour
{
    [Header("Player Settings")]
    public Material newMaterial;          // Nuevo material del jugador

    [Header("Interaction Settings")]
    public GameObject objectToDestroy;    // Objeto que será eliminado
    public float holdDuration = 3f;       // Tiempo necesario para mantener el clic izquierdo

    [Header("Text Settings")]
    public TextMeshPro textComponent;     // Componente de texto en otro objeto
    public string newText = "Interacción completada"; // Texto que se mostrará al completar la interacción

    private Renderer playerRenderer;      // Renderer del jugador
    private bool playerInZone = false;    // Bandera para saber si el jugador está en la zona
    private float holdTime = 0f;          // Tiempo acumulado al mantener el clic

    private void Start()
    {
        // Obtiene automáticamente el Renderer del objeto al que pertenece este script
        playerRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Solo procesa la interacción si el jugador está en la zona
        if (playerInZone)
        {
            // Verifica si el botón izquierdo está presionado
            if (Input.GetMouseButton(0))
            {
                holdTime += Time.deltaTime; // Acumula tiempo mientras se mantiene presionado

                // Si el tiempo acumulado supera el requerido, aplica los cambios
                if (holdTime >= holdDuration)
                {
                    ApplyChanges();
                }
            }
            else
            {
                // Reinicia el tiempo acumulado si se suelta el botón
                holdTime = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si el jugador entra en la zona
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detecta si el jugador sale de la zona
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            holdTime = 0f; // Reinicia el tiempo acumulado
        }
    }

    private void ApplyChanges()
    {
        // Cambia el material del jugador
        if (playerRenderer != null && newMaterial != null)
        {
            playerRenderer.material = newMaterial;
        }

        // Elimina el objeto especificado
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }

        // Cambia el texto en el componente especificado
        if (textComponent != null)
        {
            textComponent.text = newText;
        }

        // Resetea el tiempo acumulado para evitar múltiples ejecuciones
        holdTime = 0f;
    }
}
