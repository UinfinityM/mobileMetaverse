using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İnspectAvioice : MonoBehaviour
{
    private GrabObject grabObject;    
    public GameObject avoice; 
    public bool isPushed = false; 

    void Start()
    {
        grabObject = FindObjectOfType<GrabObject>();

        if (grabObject != null)
        {
            grabObject.onAnimationPlayed.AddListener(OnAnimationPlayed);
        }
        else
        {
            Debug.LogError("GrabObject sahnede bulunamadı!");
        }
    }

    private void OnAnimationPlayed()
    {
        // Durumu değiştir
        isPushed = !isPushed;

        // Objenin dönüşünü kontrol et
        if (avoice != null)
        {
            if (isPushed)
            {
                RotateObject(90f); // 90 derece döndür
            }
            else
            {
                RotateObject(-90f); // -90 derece döndür
            }
        }

        Debug.Log($"Animasyon oynatıldı, isPushed: {isPushed}");
    }

    private void RotateObject(float angle)
    {
        // Objenin mevcut rotasyonuna açı ekle
        avoice.transform.Rotate(Vector3.up * angle);
    }
}
