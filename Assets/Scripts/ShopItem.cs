using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject selectedTower;
    BuildingManager bm;
    tower stats;
    public GameObject tooltip;
    perspectiveChanger perspective;
    weaponController robotStats;
    

	// Use this for initialization
	void Start () {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        stats = selectedTower.GetComponent<tower>();
        robotStats = selectedTower.GetComponentInChildren<weaponController>();
        perspective = GameObject.Find("Level").GetComponent<perspectiveChanger>();
	}

    public void Click()
    {
        if (stats != null)
        {
            bm.selectedTower = this.selectedTower;
        }
        else
        {
            perspective.purchased = true;
            perspective.fpsButton.interactable = true;
        }
        
    }

    public void OnPointerEnter(PointerEventData data){
        tooltip.SetActive(true);
        if (stats != null)
        {
            tooltip.transform.GetChild(0).GetComponent<Text>().text = stats.name;
            tooltip.transform.GetChild(1).GetComponent<Text>().text = "Damage:" + stats.damage.ToString();
            tooltip.transform.GetChild(2).GetComponent<Text>().text = "Range:" + stats.range.ToString();
            tooltip.transform.GetChild(3).GetComponent<Text>().text = "Reload time:" + stats.fireCooldown.ToString();
            tooltip.transform.GetChild(4).GetComponent<Text>().text = "Price:" + stats.cost.ToString();
            tooltip.transform.GetChild(5).GetComponent<Text>().text = stats.description;
        }
        else
        {
            tooltip.transform.GetChild(0).GetComponent<Text>().text = robotStats.name;
            tooltip.transform.GetChild(1).GetComponent<Text>().text = "Damage:" + robotStats.damage.ToString();
            tooltip.transform.GetChild(2).GetComponent<Text>().text = "Reload time:" + robotStats.fireCooldown.ToString();
            tooltip.transform.GetChild(3).GetComponent<Text>().text = "Price:" + robotStats.cost.ToString();
            tooltip.transform.GetChild(5).GetComponent<Text>().text = robotStats.description;
        }

    }

    public void OnPointerExit(PointerEventData data)
    {
        tooltip.SetActive(false);
    }
}
