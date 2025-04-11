using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject loot;
    public GameObject targetLoot;

    private bool pos = false;
    private GameObject other = null;

    private void Update()
    {
        if (pos && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Is Work");
            targetLoot = other.GetComponent<Player>().ChangeStaff(loot);
            loot = targetLoot;
        }
        
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pos = true;
            other = collision.gameObject;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pos = false;
        other = null;
    }
    //(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {

    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            targetLoot = collision.gameObject.GetComponent<Player>().ChangeStaff(loot);
    //            loot = targetLoot;
    //        }
    //    }
    //}

}
