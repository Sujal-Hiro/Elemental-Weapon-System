using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWeapon : Weapon
{
    public override void Activate()
    {
        Debug.Log("Ice Weapon Activated");
    }

    public override void Deactivate()
    {
        Debug.Log("Ice Weapon Deactivated");
    }

    public override void ApplyEffect()
    {
        Debug.Log("Ice Effect ");
    }


}
