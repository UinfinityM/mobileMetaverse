using UnityEngine;
using UnityEngine.Events;

public class GrabObject : MonoBehaviour
{
    public Transform grabPoint; // Sphere objesi
    private GameObject grabbedObject; // Tutulan obje
    private Animation grabbedObjectAnimation; // Animation bileþeni

    private bool isGrabbing = false;

    // Animasyonun baþladýðýný bildiren event
    public UnityEvent onAnimationPlayed;

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            Debug.Log("T ye basýlý tutuyosun");
            if (grabbedObject != null)
            {
                isGrabbing = true;
                MoveObjectWithGrabPoint();
            }
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            isGrabbing = false;
            ReleaseObject();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (grabbedObject != null && grabbedObjectAnimation != null)
            {
                grabbedObjectAnimation.Play();
                // Eventi tetikle
                onAnimationPlayed?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            grabbedObject = other.gameObject;
        }

        if (other.CompareTag("Pushable"))
        {
            grabbedObject = other.gameObject;
            grabbedObjectAnimation = grabbedObject.GetComponent<Animation>();

            if (grabbedObjectAnimation == null)
            {
                Debug.LogError("Pushable object does not have an Animation component!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabbedObject)
        {
            ReleaseObject();
        }
    }

    private void MoveObjectWithGrabPoint()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = grabPoint.position;
        }
    }

    private void ReleaseObject()
    {
        grabbedObject = null;
        grabbedObjectAnimation = null;
    }
}
