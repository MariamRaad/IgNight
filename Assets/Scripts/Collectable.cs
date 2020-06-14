using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public AudioSource audioCollectable;
    public Text collectableText;
    public Renderer rend;

    private int amount = 0;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //audioCollectable.Play();
            rend.enabled = false;
            amount += 1;
            collectableText.text = amount.ToString();
            Destroy(gameObject);
        }
    }
}
