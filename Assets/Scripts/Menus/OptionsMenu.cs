using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public string returnScene = "returnScene"; 
    public void ReturnButton()
    {
        SceneManager.LoadScene(returnScene);
        
    }

}
