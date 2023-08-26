using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Transform shopItemHolder;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < this.transform.childCount - 2; i++)
        {
            GameObject Go = this.transform.GetChild(i).gameObject;
            Image slotImage = Go.transform.GetChild(0).GetComponent<Image>();
            slotImage.enabled = true;
            slotImage.sprite = shopItemHolder.GetComponent<ShopGenerator>().finalList[3 - i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}

