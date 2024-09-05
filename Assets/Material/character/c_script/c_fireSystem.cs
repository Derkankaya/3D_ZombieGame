using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_fireSystem : MonoBehaviour
{
    Camera cam;
    public LayerMask ZombieLayer;
    c_script hpControl;

    void Start()
    {
        cam = Camera.main;
        hpControl = this.gameObject.GetComponent<c_script>();
    }

    void Update()
    {
       if (hpControl.c_IsLive() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fireOn();
            }
        }
    }

    void fireOn()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ZombieLayer))
        {
            hit.collider.gameObject.GetComponent<z_script>().HasarAl();
        }
    }
}