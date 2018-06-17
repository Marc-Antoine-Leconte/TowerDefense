﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float startHealth = 100;

    private float health;

    public int moneyValue = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    public void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
            Die();
        healthBar.fillAmount = health / startHealth;
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1 - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += moneyValue;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
}