using UnityEngine;
using System.Collections;

public class TowerSpace : MonoBehaviour {

    void OnMouseUp()
    {

        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
        if (bm.selectedTower != null)
        {

            ScoreManager sm= GameObject.FindObjectOfType<ScoreManager>();
            if(sm.money < bm.selectedTower.GetComponent<tower>().cost){
                return;
            }
            sm.money -= bm.selectedTower.GetComponent<tower>().cost;
            print(sm.money);
            Instantiate(bm.selectedTower, transform.parent.position,transform.parent.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
