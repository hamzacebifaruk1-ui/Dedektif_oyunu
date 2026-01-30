using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Görünen Bilgi")]
    public string title;

    [Header("Kanıt (Boş olabilir)")]
    public string evidenceID;

    public void Interact()
    {
        Debug.Log(title + " ETKİLEŞİLDİ");

        if (!string.IsNullOrEmpty(evidenceID))
        {
            Debug.Log("KANIT TOPLANDI: " + evidenceID);
        }
    }
}
