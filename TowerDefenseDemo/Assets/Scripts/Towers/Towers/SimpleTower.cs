using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTower : Tower
{
    private void Start()
    {
        gun = FindObjectOfType<Gun>();
    }

}
