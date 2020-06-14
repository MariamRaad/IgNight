using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SavepointController : MonoBehaviour
{
    public static Transform lastActiveCheckpoint;
    
    
    public bool burning = false;
    private Transform fire;
    
    // Start is called before the first frame update
    void Start()
    {
        fire = transform.Find("Fire");
    }

    private void Update()
    {
        if (burning)
        {
            fire.gameObject.SetActive(true);
        }
        else
        {
            fire.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || burning) return;
        
        burning = true;
        // todo: sound
        lastActiveCheckpoint = transform;
    }
}
