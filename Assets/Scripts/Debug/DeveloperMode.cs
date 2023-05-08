using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    [Header("Variables")]
    public bool developerMode = false;

    [Header("References")]
    public GameObject DebugLogHud;

    private void Update()
    {
        if (developerMode == true)
        {
            DebugLogHud.SetActive(true);
            
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.D))
            {
                developerMode = false;
            }
        }
        else
        {
            DebugLogHud.SetActive(false);
            
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.D))
            {
                developerMode = true;
            }
        }
    }
}
