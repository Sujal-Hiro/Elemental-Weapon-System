using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : Weapon
{
    public override void Activate()
    {
        Debug.Log("Fire Weapon Activated");
    }
    public override void Deactivate()
    {
        Debug.Log("Fire Weapon Deactivated");
    }

    public override void ApplyEffect()
    {
        Debug.Log("Fire Effect");
    }
}
