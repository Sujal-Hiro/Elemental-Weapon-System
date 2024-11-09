using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWeapon : Weapon
{
   
    public override void Activate()
    {
        Debug.Log("Electric Weapon Activated");
    }
    public override void Deactivate()
    {
        Debug.Log("Electric Weapon Deactivated");
    }

    public override void ApplyEffect()
    {
        Debug.Log(" Electric Effect ");
        
    }
}
