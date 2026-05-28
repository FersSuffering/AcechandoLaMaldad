using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Transform cameraTransform;

    public Transform firePoint;
    public GameObject muzzleFlash;

    public Gun activeGun;
    public List<Gun> allGuns = new List<Gun>();
    public int currentGun;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGun--;
        SwitchGun();
    }

    void Update()
    {
        if (!GameManager.isPaused) 
        { 
            UI.instance.ammoText.text = "" + activeGun.currentAmmo;

            // Shooting
            if (Input.GetMouseButtonDown(0) && activeGun.fireCounter <= 0)
            {
                RaycastHit hit;

                if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 200f))
                {
                    if (Vector3.Distance(cameraTransform.position, hit.point) > 1f)
                    {
                        firePoint.LookAt(hit.point);
                    }
                    else
                    {
                        firePoint.LookAt(cameraTransform.position + (cameraTransform.forward * 40f));
                    }
                }

                FireShot();
            }

            if (Input.GetMouseButton(0) && activeGun.canAutoFire)
            {
                if (activeGun.fireCounter <= 0)
                {
                    RaycastHit hit;

                    if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 200f))
                    {
                        if (Vector3.Distance(cameraTransform.position, hit.point) > 1f)
                        {
                            firePoint.LookAt(hit.point);
                        }
                        else
                        {
                            firePoint.LookAt(cameraTransform.position + (cameraTransform.forward * 40f));
                        }
                    }

                    FireShot();
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SwitchGun();
            }
        }
    }

    public void FireShot()
    {
        if (activeGun.currentAmmo > 0)
        {
            activeGun.currentAmmo--;

            Instantiate(activeGun.bullet, firePoint.position, firePoint.rotation);

            activeGun.fireCounter = activeGun.fireRate;

            StartCoroutine(MuzzleFlash());
        }
    }

    IEnumerator MuzzleFlash()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        muzzleFlash.SetActive(false);
    }

    public void SwitchGun()
    {
        activeGun.gameObject.SetActive(false);

        currentGun++;

        if (currentGun >= allGuns.Count)
        {
            currentGun = 0;
        }

        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);

        firePoint.position = activeGun.firepoint.position;
    }

}
