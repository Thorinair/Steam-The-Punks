using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class perspectiveChanger : MonoBehaviour {

    public Slider fuelUsedBar;
    public int fuelUsed = 0;
    public bool FPS = false;
    public bool purchased = false;
    public Camera FpsCamera;
    public Camera NormalCamera;
    public Button fpsButton;

	// Use this for initialization
	void Start () {
        fuelUsedBar.value = fuelUsed;
        fpsButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (fuelUsedBar.value == fuelUsedBar.maxValue && FPS==true)
        {
            CancelInvoke("UseFuel");
            DeactivateFPS();
        }
        else if (fuelUsedBar.value == fuelUsedBar.minValue-1)
        {
            CancelInvoke("FillFuel");
            fuelUsed++;
        }
	}

    void UseFuel()
    {
        fuelUsed++;
        fuelUsedBar.value = fuelUsed;
    }

    void FillFuel()
    {
        fuelUsed--;
        fuelUsedBar.value = fuelUsed;
    }

    public void ActivateFPS()
    {
        if (purchased == true)
        {
            FPS = true;
            Cursor.lockState = CursorLockMode.Locked;
            InvokeRepeating("UseFuel", 1, 0.5f);
            FpsCamera.gameObject.SetActive(true);
            NormalCamera.gameObject.SetActive(false);
            fpsButton.gameObject.SetActive(false);
            fuelUsedBar.gameObject.SetActive(true);
        }

    }

    public void DeactivateFPS()
    {
        FPS = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        InvokeRepeating("FillFuel", 1, 2);
        NormalCamera.gameObject.SetActive(true);
        FpsCamera.gameObject.SetActive(false);
        fpsButton.gameObject.SetActive(true);
        fuelUsedBar.gameObject.SetActive(false);
        
    }
}
