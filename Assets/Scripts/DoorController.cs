using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    public GameObject crosshair;

    public void OnInteract()
    {
        Animator anim = GetComponentInParent<Animator>();
        anim.SetTrigger("DoorTrigger");
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Door")
        {
            crosshair.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
                anim.SetTrigger("DoorTrigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            crosshair.SetActive(false);
        }
    }*/
}
