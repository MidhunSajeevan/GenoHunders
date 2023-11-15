
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody[] ragdollRegidbodies;
    private bool died=false;
    public int MaxHealth = 100;
    public int currentHealth;
    [SerializeField] EnemyHealthScript healthScript;
    private Canvas canvas;
    public static event Action<EnemyScript> OnEnemyKilled;
    EnemyPoolManager enemyPoolManager;
    void Start()
    {
       
        Refferences();

    }

    void Update()
    {
        if(!died)
        {
            MoveEnemy();
        }
       
    }
    private void MoveEnemy()
    {
        //Movements of enemy
        agent.SetDestination(target.position);
        Vector3 direction = target.position - transform.position;
        Quaternion rotation=Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
        
        //Animations
        animator.SetFloat("speed",1,0.1f,Time.deltaTime);
        float distanceToTarget=Vector3.Distance(transform.position, target.position);
     
        if(distanceToTarget <= agent.stoppingDistance) 
        {
            animator.SetFloat("speed", 2, 0.1f, Time.deltaTime);
        }

    }
  
    public void die()
    {
        animator.enabled = false;
        agent.enabled = false;
        foreach(Rigidbody rb in ragdollRegidbodies)
        {

            rb.isKinematic = false;
        }
        
 //       enemyPoolManager.DespawnEnemy(this.gameObject);
        canvas.enabled = false;
        died = true;
        Debug.Log("Called");
        StartCoroutine(DestroyEnemy());
    }
    private void Refferences()
    {
       
        currentHealth = MaxHealth;
        healthScript.setMaxHealth(MaxHealth);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        animator =GetComponentInChildren<Animator>();
        ragdollRegidbodies=GetComponentsInChildren<Rigidbody>();
        canvas =GetComponentInChildren<Canvas>();

    }
  public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthScript.SetHealth(currentHealth);
        if (currentHealth < 0)
        {
            die();
            OnEnemyKilled?.Invoke(this);
        }
            
    }
    IEnumerator DestroyEnemy()
    {
        Debug.Log("started");
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
        Debug.Log("Ended");
    }
}
