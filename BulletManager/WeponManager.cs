using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using Cinemachine;
using System.Threading.Tasks;

public class WeponManager : MonoBehaviour
{
    [Header("Scope Animation")]
    [SerializeField] Animator animator;
    private bool scoped=false;
    [SerializeField] GameObject Scopeoverlay;
    [SerializeField]  float time = .9f;
    [SerializeField]  GameObject weponcamera;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float fov = 15f;
    private float Normalfov = 60f;
    [SerializeField] Transform BarrelPosition;
    [SerializeField] TrailRenderer bulleteffect;
    [SerializeField] GameObject crossair;
    [SerializeField] AudioSource source;
   


    [SerializeField]
    ParticleSystem flash;
    float shotDelay = 1.0f;
    float shotTimer = 0f;
    [SerializeField] AudioClip gunshot;
    AudioSource audioSource;
    private RaycastHit hitinfo;
    [HideInInspector]
    public static int GunAmo = 7;
    [HideInInspector]
    public static int Maxmag = 28;

 
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        GunAmo = 7;
        Maxmag = 28;
    }

    void Update()
    {

       
        if(Input.GetButtonDown("Fire2"))
        {
           
            scoped = !scoped;
            if(scoped)
            {
                StartCoroutine(onScoped());
            }else
            {
                Scopeoverlay.SetActive(false);
                weponcamera.SetActive(true);
                virtualCamera.m_Lens.FieldOfView = Normalfov;

            }
            animator.SetBool("IsScoped", scoped);
            
        }
        if (Input.GetButtonDown("Fire1"))
        {
            crossair.SetActive(true);
            if (shotTimer <= 0f && GunAmo > 0)
            {
                shotDelay = 1f;
                fire();
            }
        }
        if (shotTimer > 0f)
        {
            shotTimer -= Time.deltaTime;
        }


    }
  
    void fire()
    {

        flash.Play();
        audioSource.PlayOneShot(gunshot);
       
        var tracer=Instantiate(bulleteffect,BarrelPosition.position, Quaternion.identity); 
        tracer.AddPosition(BarrelPosition.position);
        if (Physics.Raycast(BarrelPosition.position,BarrelPosition.forward, out hitinfo))
        {
            tracer.transform.position = hitinfo.point;

           
            if (hitinfo.collider.gameObject.TryGetComponent<Enemy>(out Enemy component))
            {
                component.TakeDamage(120);
                
                 
            }
        }
        GunAmo--;
        if(GunAmo == 0)
        {
       
           
            source.PlayDelayed(1);
            Maxmag -= 7;
            
            if (Maxmag == 0) {
                GunAmo = 0;
                return;
            } else{
                StartCoroutine(Reloading());
              
            }

        }
        shotTimer = shotDelay;
    }
   
    IEnumerator onScoped()
    {
        yield return new WaitForSeconds(time);
        Scopeoverlay.SetActive(true);
        weponcamera.SetActive(false);
        virtualCamera.m_Lens.FieldOfView = fov;


    }
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(3);
        GunAmo = 7;
    }
   
}