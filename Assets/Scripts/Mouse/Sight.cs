using UnityEngine;

public class Sight : MonoBehaviour
{
    public GameObject AimPoint;
    public bool customCrosshair;

    private void Update()
    {
        if (customCrosshair == false)
        {
            CancelInvoke(); //cancels the invoke
            CustomCrosshair(); //calls cutom crosshair
            InvokeRepeating(nameof(CursorLock), 0, 5); //calls cursor lock
        }
        else
        {
            CancelInvoke(); //cancels the invoke
            InvokeRepeating(nameof(NoCursorLock), 0, 5); //calls no cursor lock
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
