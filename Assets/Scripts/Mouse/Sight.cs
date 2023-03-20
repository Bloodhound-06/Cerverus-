using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject AimPoint;
    public PausMenu pm;

    private void Update()
    {
        if (!pm.paused)
        {
            CustomCrosshair(); //calls custom croshair
            CursorLock(); //calls cursor lock
        }
        else
        {
            CancelInvoke(); //cancels the invoke
            NoCursorLock(); //calls no cursor lock
        }
    }

    public void CustomCrosshair()
    {
        AimPoint.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0) ; 
        //sets aim point to mouse position
    }

    public void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Confined; //locks the mouse to the program
        Cursor.visible = false; //hides mouse
        AimPoint.SetActive(true); //activates the aimpoint
    }

    public void NoCursorLock()
    {
        Cursor.lockState = CursorLockMode.Confined; //locks th mouse to the program
        Cursor.visible = true; //shows the mouse
        AimPoint.SetActive(false); //deactivates the aimpoint
    }
}
