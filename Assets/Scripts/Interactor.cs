using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    //Interaction Behaviour
    public void OnInteract();
}
public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.OnInteract();
                    Debug.Log("Interaction with" + hitInfo.collider.gameObject.name);
                }
            }
        }
    }
}
