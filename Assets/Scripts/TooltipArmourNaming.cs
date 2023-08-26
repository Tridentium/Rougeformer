using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TooltipArmourNaming : MonoBehaviour
{
    public WeaponID weaponID;
    string Description;
    DamageBuffArmour tempDamageBuff;
    HealingBuffArmour tempHealingBuff;
    KbResistanceArmour tempKbResistance;
    KbAttacked tempKbAttacked;
    ThornsArmourTrigger tempThorsArmour;
    // Start is called before the first frame update
    void Start()
    {
        weaponID.weaponName = "Countering Chestplate";
        Description = "A tattered leather chestplate that has an aura of magic surrouding it. " +
            "Having this armour equipped in the hotbar can provide these buffs: ";
        if (this.gameObject.TryGetComponent<DamageBuffArmour>(out tempDamageBuff))
        {
            Description += @"

Damage buff when attacked:

Damage Buff: " + Decimal.Round((decimal)this.gameObject.GetComponent<DamageBuffArmour>().buff, 2) * 100 + @"%
Buff Time When Actvated: "  + Decimal.Round((decimal)this.gameObject.GetComponent<DamageBuffArmour>().buffTime);
        }

        if (this.gameObject.TryGetComponent<HealingBuffArmour>(out tempHealingBuff))
        {
            Description += @"

Healing buff when attacked:

Healing Buff: " + Decimal.Round((decimal)this.gameObject.GetComponent<HealingBuffArmour>().buff, 2) * 100+ @"%
Buff Time When Actvated: " + Decimal.Round((decimal)this.gameObject.GetComponent<HealingBuffArmour>().buffTime);
        }

        if (this.gameObject.TryGetComponent<KbResistanceArmour>(out tempKbResistance))
        {
            Description += @"

Knockback Resistance:

Knockback Negation: " + Decimal.Round((decimal)this.gameObject.GetComponent<KbResistanceArmour>().buff, 2) * 100 + "%";
        }

        if (this.gameObject.TryGetComponent<KbAttacked>(out tempKbAttacked))
        {
            Description += @"

Responding Knockback When Attacked:

Response Amount: " + Decimal.Round((decimal)this.gameObject.GetComponent<KbAttacked>().respondAmount, 2);
        }

        if (this.gameObject.TryGetComponent<ThornsArmourTrigger>(out tempThorsArmour))
        {
            Description += @"

Responding Damage When Attacked:

Respond Amount: " + Decimal.Round((decimal)this.gameObject.GetComponent<ThornsArmourTrigger>().respondPercent, 2);
        }
        Description += @"

Armour Strength: " + Decimal.Round((decimal)weaponID.weaponStrength * 100, 2);
        weaponID.weaponDesc = Description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
