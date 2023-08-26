using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponID : MonoBehaviour
{ 
    
    public float weaponStrength;
    public string weaponName;
    [Multiline()]
    public string weaponDesc;
    public int tier;
    public float tierBuff;
    private void Update()
    {
        tierBuff = 1f + (((tier - 1f) * 5f)/100f);
    }
}
