using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TropfenController : MonoBehaviour
{
    private PflanzeController parentPflanze;
    
    
    private void Start()
    {
        parentPflanze = transform.parent.parent.GetComponent<PflanzeController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        parentPflanze.OnTriggerEnter2D(other);
    }
}
