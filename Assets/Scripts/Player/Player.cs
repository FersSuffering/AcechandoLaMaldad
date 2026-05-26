using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Transform cameraTransform;

    public GameObject bullet;
    public Transform firePoint;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Shooting
        if (Input.GetMouseButtonDown(0))
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

            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
