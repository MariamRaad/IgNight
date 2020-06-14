using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float timeToDie = 5.0f;

    private float percentageDead = 1.0f;
    private Vector3 originalScale;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        currentTime = timeToDie;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        percentageDead = currentTime / timeToDie;

        transform.localScale = originalScale * percentageDead;
        
        if (currentTime < 0)
        {
            Destroy(gameObject);
            Debug.Log("DEAD");
        }
    }
}
