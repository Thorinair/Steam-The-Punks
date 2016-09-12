using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerSpace : MonoBehaviour {

    perspectiveChanger perspective;
    public Text infoText;
    private bool informed = false;
    private float timeInformed = 1f;

    void Start()
    {
        perspective = GameObject.Find("Level").GetComponent<perspectiveChanger>();
    }

    void Update()
    {
        if (informed == true)
        {
            timeInformed -= Time.deltaTime;
            if (timeInformed <= 0)
            {
                infoText.text = "";
                informed = false;
            }
        }
        
    }

    void OnMouseUp()
    {
        if (perspective.FPS == false)
        {
            BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
            if (bm.selectedTower != null)
            {

                ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
                if (sm.money < bm.selectedTower.GetComponent<tower>().cost)
                {
                    infoText.text = "Not enough money";
                    informed = true;
                    timeInformed = 1f;
                    return;
                }
                sm.money -= bm.selectedTower.GetComponent<tower>().cost;
                Instantiate(bm.selectedTower, transform.parent.position, transform.parent.rotation);
                Destroy(transform.parent.gameObject);
            }
        }

    }
}
