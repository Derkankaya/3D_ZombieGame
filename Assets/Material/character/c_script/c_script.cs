using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_script : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    public float karakterHiz;

    private float c_Healt = 100;
    bool isLive;

    void Start()
    {
        anim = GetComponent<Animator>();
        isLive = true;
    }

    void Update()
    {
        if (c_Healt <= 0)
        {
            isLive = false;
            anim.SetBool("LiveIs", isLive);
        }
        if (isLive == true)
        {
            Hareket();
        }
    }
    public bool c_IsLive()
    {
        return isLive;
    }
    public void TakeDamage()
    {
        c_Healt -= Random.Range(5, 10);
    }
    void Hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        anim.SetFloat("Horizontal", yatay);
        anim.SetFloat("Vertical", dikey);
        this.gameObject.transform.Translate(yatay * karakterHiz * Time.deltaTime, 0, dikey * karakterHiz * Time.deltaTime);

    }
}