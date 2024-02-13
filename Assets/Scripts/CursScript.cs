using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursScript : MonoBehaviour
{
    public bool toggleCursor;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = toggleCursor;
        Cursor.lockState = toggleCursor ? CursorLockMode.None : CursorLockMode.Locked;
        
    }

}
