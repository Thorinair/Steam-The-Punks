using UnityEngine;
using System.Collections;

public class ShopScript : MonoBehaviour {

    public void ToggleShop()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
