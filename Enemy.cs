using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private float MaxHealth = 100;
    public float currentHealth = 0;
  
    EnemyPoolManager enemyPoolManager;
    private NavMeshAgent agent;
    private Transform target;

    private Animator animator;
    private Rigidbody[] ragdollRegidbodies;
    EnemyHealthScript healthScript;
    private Canvas canvas;
    private bool died = false;
    private Collider collider;

    void Start()
    {
        References();
    }

    private void Update()
    {
        if (!died)
        {
            MoveEnemy();
        }
       
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthScript.SetHealth(currentHealth);
        if(currentHealth < 0)
        {
            
      
            die();
        }


    }
    void MoveEnemy()
    {
        //Movements of enemy
        agent.SetDestination(target.position);
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        animator.SetFloat("speed", 1, 0.1f, Time.deltaTime);
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= agent.stoppingDistance)
        {
            animator.SetFloat("speed", 2, 0.1f, Time.deltaTime);
        }
    }
    void References()
    {
        agent=GetComponent<NavMeshAgent>();
        currentHealth = MaxHealth;
        enemyPoolManager = GameObject.FindObjectOfType<EnemyPoolManager>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        animator = GetComponentInChildren<Animator>();
        ragdollRegidbodies = GetComponentsInChildren<Rigidbody>();
        canvas = GetComponentInChildren<Canvas>();
       healthScript= canvas.GetComponentInChildren<EnemyHealthScript>();
        collider = GetComponent<Collider>();
        healthScript.setMaxHealth(MaxHealth);
    }
     void die()
    {
        animator.enabled = false;
        agent.enabled = false;
        foreach (Rigidbody rb in ragdollRegidbodies)
        {

            rb.isKinematic = false;
        }
        canvas.enabled = false;
        died = true;
        collider.enabled= false; // if Despawn enemy turn on collider also
        StartCoroutine(DestroyEnemy());
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);
        enemyPoolManager.DespawnEnemy(this.gameObject);
    }
}
