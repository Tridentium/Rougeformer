using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KbResistanceArmour : MonoBehaviour
{
    public ArmourStats armourStats;
    public float buff = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        armourStats = this.transform.parent.GetComponent<ArmourStats>();
    }
    void Update()
    {
        if (this.transform.GetSiblingIndex() < 3 && this.transform.parent.tag == "InventoryStorage")
        {
            armourStats.kbResistance = buff;
        }
    }
}
