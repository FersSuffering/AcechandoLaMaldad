using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Transform cameraTransform;

    public Transform firePoint;

    public Gun activeGun;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UI.instance.ammoText.text = "" + activeGun.currentAmmo;
    }

    void Update()
    {
        UI.instance.ammoText.text = "" + activeGun.currentAmmo;

        // Shooting
        if (Input.GetMouseButtonDown(0) && activeGun.fireCounter <= 0)
        {
            RaycastHit hit;

            if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, 200f))
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
    }

    public void FireShot()
    {
        if (activeGun.currentAmmo > 0)
        {
            activeGun.currentAmmo--;

            Instantiate(activeGun.bullet, firePoint.position, firePoint.rotation);

            activeGun.fireCounter = activeGun.fireRate;
        }
    }

}
