using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_cam_script : MonoBehaviour
{   
    public Transform hedef;
    public Vector3 hedefMesafe;
    [SerializeField]
    private float fareHassasiyeti;
    float fareX, fareY;

    Vector3 objRot;
    public Transform c_body;

    c_script hpControl;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        hpControl = this.gameObject.GetComponent<c_script>();
    }

    void LateUpdate()
    {
        if (hpControl.c_IsLive() == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, hedef.position + hedefMesafe, Time.deltaTime * 10);
            fareX += Input.GetAxis("Mouse X") * fareHassasiyeti;
            fareY -= Input.GetAxis("Mouse Y") * fareHassasiyeti;
            if (fareY >= 45)
            {
                fareY = 45;
            }
            if (fareY <= -60)
            {
                fareY = -60;
            }
            this.transform.eulerAngles = new Vector3(fareY, fareX, 0);
            hedef.transform.eulerAngles = new Vector3(0, fareX, 0);

            Vector3 gecici = this.transform.localEulerAngles;
            gecici.z = 0;
            gecici.y = 0;
            gecici.x = this.transform.localEulerAngles.x + 10;
            objRot = gecici;
            c_body.transform.localEulerAngles = objRot;
        }
    }
}