using Cinemachine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Enemy Details")]
    private float x, z;
    [SerializeField][Range(0,20)]  private float speed = 10f;
    [SerializeField][Range(0, 20)] private float sprintSpeed = 15f;
    [SerializeField][Range(0, 20)] private float jumpHeight = 3f;
    [SerializeField] Healthscript healthscript;
    [SerializeField] GameObject Attacking;
    [HideInInspector]
     public int MaxHealth = 100;
    [HideInInspector]
    public int currentHealth;
    
    private CharacterController characterController;
    private Vector3 velocity;
    private Vector3 move;
    private float gravity = -19.81f;
    [HideInInspector]
    public bool IsPlayerDead=false;
    private AudioSource audio;
    [SerializeField] AudioSource HurtsSound;

    private void Start()
    {
       
        Time.timeScale = 1f;
        characterController = GetComponent<CharacterController>();
        healthscript.setMaxHealth(MaxHealth);
        currentHealth = MaxHealth;
        audio = GetComponent<AudioSource>();    
        
    }

    private void Update()
    {
        HandleGroundedMovement();
        HandleGravity();
        if(IsPlayerDead)
        {
            die();
            audio.Stop();
        }
    }

    private void HandleGroundedMovement()
    {
      
        if (characterController.isGrounded)
        {
            move.y = -2f;

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                audio.Play();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                audio.Pause();
              
            }


            // Check if the player wants to jump
            if (Input.GetButtonDown("Jump"))
            {
               
                Jump();
           
            }

            // Apply movement
            characterController.Move(move * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed) * Time.deltaTime);
           
        }
        else
        {
            // Apply air control if not grounded
            AirControl();
        }
        // Apply movement and jump 
        characterController.Move(velocity * Time.deltaTime);
        characterController.Move(move * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed) * Time.deltaTime);
    }

    private void Jump()
    {
        // Ensure the player is grounded before jumping
       if (characterController.isGrounded)
        {
            //Time taken for a free fall of an object
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

 

    }
   
    private void AirControl()
    {
        
    }

    private void HandleGravity()
    {
        // Apply gravity if not grounded
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
           
        }
        characterController.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {

        
        currentHealth -= damage;
        healthscript.SetHealth(currentHealth);
        if (currentHealth < 0)
            IsPlayerDead = true;
        if (currentHealth < 40)
            Attacking.SetActive(true);
        else
            StartCoroutine(isAttacking());

    }
    IEnumerator isAttacking()
    {
       
        Attacking.SetActive(true);
        HurtsSound.Play();
        yield return new WaitForSeconds(.2f);
        Attacking.SetActive(false);
        yield return new WaitForSeconds(.2f);
    }
    void die()
    {
       //write someting if you need after the player is dead
       
    }
    void pickUpAmo(Collider amo,int count)
    {
        WeponManager wepon=GetComponentInChildren<WeponManager>();
        Debug.Log(amo.name);
        WeponManager.Maxmag += count;
        Destroy(amo.gameObject);


    }
    void pickUp(Collider amo,int count)
    {
        AutoGunScripts autoGun = GetComponentInChildren<AutoGunScripts>();
        AutoGunScripts.Maxmagauto += count;
        Destroy(amo.gameObject);
    }
   
}
