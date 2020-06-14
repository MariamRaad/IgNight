using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PflanzeController : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Debug.Log("Tropfen TRIGGER! ");
        
        HealthBarController.changeHealth(-0.1f);
    }
}
