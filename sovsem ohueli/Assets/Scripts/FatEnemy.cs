using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatEnemy : AbstractEnemy
{
    //public override float Health { get => Health; set => Health = 100f; }
    private void Start()
    {
        health = 100;
    }
}
