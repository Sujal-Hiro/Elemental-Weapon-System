using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFiring : MonoBehaviour
{
    public bool firing=false;

    public void ToggleON()
    {
        firing=true;
    }

    public void ToggleOFF()
    {
        firing=false;
    }

    
}
