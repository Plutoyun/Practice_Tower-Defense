using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//控制从一点到另一点
public class Enemy : MonoBehaviour // Class enemy
{
    // default attributes
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed ;
    public float specialSpeed;
    public float startHealth = 100;
    private float health;
    public AudioClip deathClip;

    public int worth = 50; // Money will gain after destroy
    [Header("NEW")]
    Animator anim; // Animation
    AudioSource enemyAudio;
    public bool isDead= false;
    public bool isIdle;
    ParticleSystem hitParticles;

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Start()
    {
        //Set all attributes
        isDead = false;
        isIdle = true;
        speed = startSpeed;
        health = startHealth;
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
     }

    

    public void TakeDamage(float amout) // Decrese health and play hit audio. If health < 0, enemy die. 
    {
        if (isDead)
        {
            return;
        }
        health -= amout;
        healthBar.fillAmount = health / startHealth;
        //hitParticles.transform.position = hitPoint;
        hitParticles.Play();
        enemyAudio.Play();
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct) // Special situation of slowing speed when hit by laser
    {
        speed = startSpeed * (1f - pct);
    }

    void Die() // Set enemy to dead and increse player's money
    {
        isDead = true;
        PlayerStats.Money += worth;
        // GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        // Tell the animator that the enemy is dead.
        anim.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathClip;

        enemyAudio.Play();

        WaveSpawner.EnemiesAlive --; //Minus 1 from current wave
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >1f)
        {
            Destroy(gameObject,1.5f); // Destroy after animation
        }
        
    }
}


     
