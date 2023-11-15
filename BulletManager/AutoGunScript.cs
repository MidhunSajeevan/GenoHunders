using UnityEngine;
using System.Collections;
using Cinemachine;


public class AutoGunScripts : MonoBehaviour
{
    [Header("Scope Animation")]
    [SerializeField] Animator animator;
    private bool scoped = false;
    [SerializeField] GameObject Scopeoverlay;
    [SerializeField] float time = .9f;
    [SerializeField] GameObject weponcamera;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float fov = 15f;
    private float Normalfov = 60f;
    [SerializeField] Transform BarrelPosition;
    [SerializeField] TrailRenderer bulleteffect;
    [SerializeField] GameObject crossair;


  
    [SerializeField]
    ParticleSystem flash;
    float shotDelay =.1f;
    float shotTimer = 0f;
    [SerializeField] AudioClip gunshot;
    AudioSource audioSource;
    [HideInInspector]
    public RaycastHit hitinfo;
    [SerializeField]
    Enemy enemy;
    [HideInInspector]
    public static int GunAmo=40;
    [HideInInspector]
    public static int Maxmagauto=200;
    [SerializeField] AudioSource source;
    private bool isReloading = false;

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        GunAmo = 40;
        Maxmagauto = 200;
    }

    void Update()
    {

        crossair.SetActive(true);
        if (Input.GetButtonDown("Fire2"))
        {

            scoped = !scoped;
            if (scoped)
            {
                StartCoroutine(onScoped());
            }
            else
            {
                Scopeoverlay.SetActive(false);
                weponcamera.SetActive(true);
                virtualCamera.m_Lens.FieldOfView = Normalfov;

            }
            animator.SetBool("AutoScoped", scoped);

        }
        if (Input.GetButton("Fire1"))
        {
            
            if (shotTimer <= 0f)
            {
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
        if((isReloading) || ((GunAmo == 0)&&(Maxmagauto == 0)))
        {
            return;
        }else if(GunAmo == 0 && Maxmagauto != 0) {
            GunAmo = Maxmagauto;    
        }
        flash.Play();
        audioSource.PlayOneShot(gunshot);
        var tracer = Instantiate(bulleteffect, BarrelPosition.position, Quaternion.identity);
        tracer.AddPosition(BarrelPosition.position);
        if (Physics.Raycast(BarrelPosition.position, BarrelPosition.forward, out hitinfo))
        {
            tracer.transform.position = hitinfo.point;
            if (hitinfo.collider.gameObject.TryGetComponent<Enemy>(out Enemy component))
            {
            
                component.TakeDamage(25);
              

            }

        }
        
        if (GunAmo == 1)
        {
            source.Play();
            Maxmagauto -= 40;
            if (Maxmagauto <= 0) 
            {
                Maxmagauto = 0;
                GunAmo = 0;
                return;
            }
            else
            {
                StartCoroutine(Reloading());
            }
        }
        GunAmo--;



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
        isReloading = true;
        yield return new WaitForSeconds(2);
        GunAmo = 40;
        Maxmagauto -= 40;
        isReloading = false;
    }

}