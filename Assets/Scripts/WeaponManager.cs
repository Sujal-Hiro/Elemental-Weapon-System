using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class WeaponManager : MonoBehaviour
{
    private Weapon currentWeapon;

    [Header("Weapons")]
    public Weapon fireWeapon;
    public Weapon iceWeapon;
    public Weapon electricityWeapon;

    [Header("Buttons")]
    public Button fireButton;
    public Button iceButton;
    public Button electricityButton;

    [Header("VFX_EFX")]
    public GameObject fireEffect;
    public GameObject frostEffect;
    public GameObject electricEffect;

    [Header("Impact_EFX")]
    public GameObject fireImpact;
    public GameObject iceImpact;
    public GameObject electricImpact;

    private bool isShooting = false;

    [Header("Firing")]
    public float bulletSpeed = 5f;
    public float fireRate = 0.5f;
    float nextFireTime = 0f;

    public ToggleFiring toggleFiring;
   

    SoundManager soundManager;
    private void Start()
    {
        //for (int i = 0; i < weapons.Count && i < weaponButtons.Count; i++)
        //{
        //    weaponButtons[i].onClick.AddListener(() => EquipWeapon(weapons[i]));
        //}
        if(soundManager == null)
        {
            soundManager = FindObjectOfType<SoundManager>();
        }
        if(toggleFiring==null)
        {
            toggleFiring = gameObject.GetComponent<ToggleFiring>();
        }
    
        if(currentWeapon==null)
        {
            currentWeapon = fireWeapon.GetComponent<Weapon>();
            //currentWeapon = GetComponent<Weapon>();
        }
        fireButton.onClick.AddListener(() => EquipWeapon(fireWeapon));
        iceButton.onClick.AddListener(() => EquipWeapon(iceWeapon));
        electricityButton.onClick.AddListener(() => EquipWeapon(electricityWeapon));
        //firingOff.onClick.AddListener(() => TurnOffFiring());
        EquipWeapon(fireWeapon);

    }

    //public void TurnOffFiring()
    //{
    //    isShooting = !isShooting; 
    //    Debug.Log("Firing turned " + (isShooting ? "off" : "on"));
    //}
    private void Update()
    {
        //if (!isShooting) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

           
            if ((touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) && !EventSystem.current.IsPointerOverGameObject(touch.fingerId) && toggleFiring.firing)
            {
                if (Time.time >= nextFireTime)
                {
                    if (currentWeapon != null)
                    {
                        currentWeapon.ApplyEffect();
                        ShootProjectile();
                        Debug.Log("Applied Effect");

                        nextFireTime = Time.time + fireRate;
                    }
                }
            }
            else
            {
                Debug.Log("TOGGLE OFF");
            }
        }
        else if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject() &&  toggleFiring.firing) //Toggle firing check
        {
            if (!isShooting)
            {
                isShooting = true;
                if (Time.time >= nextFireTime)
                {
                    if (currentWeapon != null)
                    {
                        currentWeapon.ApplyEffect();
                        ShootProjectile();
                        //Debug.Log("Applied Effct");
                        nextFireTime = Time.time + fireRate;
                    }
                }
            }

        }
        else
        {
            Debug.Log("TOGGLE OFF");
            isShooting = false;
        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        if (currentWeapon == weapon)
        {
            Debug.Log("Weapon already equipped");
            return;
        }
        if (currentWeapon != null)
        {
            currentWeapon.Deactivate();

            currentWeapon = weapon;
            currentWeapon.Activate();
        }
    }

    public void ShootProjectile()
    {
        GameObject pro = GameObject.FindGameObjectWithTag("ProjectileShootPos");
        if (pro != null)
        {
            Transform projectilePos = pro.transform;

            GameObject instantiateEffect = GetEffect(currentWeapon);
            if (projectilePos != null)
            {
                GameObject effect = Instantiate(instantiateEffect, projectilePos.position, projectilePos.rotation);

                //SFX
                PlayWeaponSFX();
                Rigidbody rb = effect.GetComponent<Rigidbody>();

                ProjectileImpact projectileScript = effect.GetComponent<ProjectileImpact>();
                if (projectileScript != null)
                {
                    GameObject instantiateImpact = GetImpactEffect(currentWeapon);
                    projectileScript.impactEffect = instantiateImpact;
                    
                }
                

                if (rb != null)
                {
                    rb.AddForce(projectilePos.forward * bulletSpeed, ForceMode.Impulse);
                    Debug.Log("Effect Apply");
                }

                Destroy(effect,1.5f);



            }
            else
            {
                Debug.LogError("NO CHILD GOT TAGGED");
            }
        }
    }

    GameObject GetEffect(Weapon weapon)
    {
        if (weapon == fireWeapon)
        {
            return fireEffect;
        }
        else if (weapon == iceWeapon)
        {
            return frostEffect;
        }
        else if (weapon == electricityWeapon)
        {
            return electricEffect;
        }

       
        return null;
    }

    GameObject GetImpactEffect(Weapon weapon)
    {
        if(weapon == fireWeapon)
        {
            return fireImpact;
        }
        else if (weapon == iceWeapon)
        {
            return iceImpact;
        }
        else if (weapon == electricityWeapon)
        {
            return electricImpact;
        }
        return null;
    }

    private void PlayWeaponSFX()
    {
        if (soundManager == null) return;

        if (currentWeapon == fireWeapon)
        {
            soundManager.PlaySFX("fire");
        }
        else if (currentWeapon == iceWeapon)
        {
            soundManager.PlaySFX("ice");
        }
        else if (currentWeapon == electricityWeapon)
        {
            soundManager.PlaySFX("electric");
        }
    }




}
