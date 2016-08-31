using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject selectedTower;
    BuildingManager bm;
    tower stats;
    public GameObject tooltip;
    

	// Use this for initialization
	void Start () {
        bm = GameObject.FindObjectOfType<BuildingManager>();
        stats = selectedTower.GetComponent<tower>();
	}

    public void Click()
    {
        bm.selectedTower = this.selectedTower;
    }

    public void OnPointerEnter(PointerEventData data){
        tooltip.SetActive(true);
        tooltip.transform.GetChild(0).GetComponent<Text>().text = stats.name;
        tooltip.transform.GetChild(1).GetComponent<Text>().text = "Damage:"+stats.damage.ToString();
        tooltip.transform.GetChild(2).GetComponent<Text>().text = "Range:"+stats.range.ToString();
        tooltip.transform.GetChild(3).GetComponent<Text>().text = "Attack speed:"+stats.fireCooldown.ToString();
        tooltip.transform.GetChild(4).GetComponent<Text>().text = "Price:" + stats.cost.ToString();
        tooltip.transform.GetChild(5).GetComponent<Text>().text = stats.description;
    }

    public void OnPointerExit(PointerEventData data)
    {
        tooltip.SetActive(false);
    }
}
