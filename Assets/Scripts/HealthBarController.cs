using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class HealthBarController : MonoBehaviour
{
    public Canvas gameOverMenu;
    public AudioSource m_audio;
    public Color red;
    public Color white;
    public float speed = 1.0f;
    
    private static float health;
    private static float maxHealth;
    private Animator changeColorAnimation;

    SpriteRenderer spriteRenderer;
    [SerializeField] private Healthbar healthBar;


    public static void changeHealth(float deltaHealth)
    {
        health += deltaHealth;
    }

    private void Start()
    {
        health = 1f;
        maxHealth = 1f;
        changeColorAnimation = GameObject.Find("BarSprite").GetComponent<Animator>();
    }

    private void Update()
    {
        //health -= .01f;
        healthBar.SetSize(health);

        if (health < 0.3f)
        {
            changeColorAnimation.enabled = true;
        } else
        {
            changeColorAnimation.enabled = false;
        }

        if (health <= 0.0f)
        {
            health = 0.0f;
            gameOverMenu.gameObject.SetActive(true);

            //this audio should only be played once; not in this function!
            //m_audio.Play();

            Time.timeScale = 0;
            AudioListener.pause = true;
        }
    }

}
