using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SimpleInteractionRay : MonoBehaviour
{
    public float distance = 5f;
    public TextMeshProUGUI interactionText;
    
    // 📍 YAZININ KONUMUNDAKİ AYARLAR
    public Vector2 textOffset = new Vector2(0, -100); // Ekranın merkezinden ne kadar uzak?
    // Vector2(0, -100) = merkez altında 100 pixel aşağıda
    // Vector2(100, -100) = sağ alt
    // Vector2(-100, -100) = sol alt
    // Değiştirerek deneyebilirsiniz!

    bool isLookingAtInteractable;

    void Start()
    {
        if (interactionText != null)
            interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        Debug.Log("SCRIPT ÇALIŞIYOR");

        if (Camera.main == null) return;
        if (Keyboard.current == null) return;

        isLookingAtInteractable = false;

        Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward
        );

        RaycastHit hit;

        // 🔵 Ray yerine SphereCast (daha stabil)
        if (Physics.SphereCast(ray, 0.3f, out hit, distance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                isLookingAtInteractable = true;

                interactionText.text = "E - İncele";
                
                // 📍 YAZININ POZISYONUNU AYARLA
                RectTransform rectTransform = interactionText.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = textOffset;

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact();
                }
            }
        }

        // 🔴 Yazıyı tek yerden aç/kapat (titreme yok)
        interactionText.gameObject.SetActive(isLookingAtInteractable);
    }
}