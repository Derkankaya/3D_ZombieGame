using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class z_script : MonoBehaviour
{
    private float zombieHP = 100;
    bool zombieDead;
    Animator zombieAnim;

    GameObject hedefOyuncu;
    public float rangePlayer;
    public float rangeEnemy;
    NavMeshAgent zombieNavMesh;

    void Start()
    {
        zombieAnim = this.GetComponent<Animator>();
        hedefOyuncu = GameObject.Find("character");
        zombieNavMesh = this.GetComponent<NavMeshAgent>();

    }

    
    void Update()
    {
        
        if (zombieHP <= 0)
        {
            zombieDead = true;
        }
        if (zombieDead == true)
        {
            zombieAnim.SetBool("Dead", true);
            StartCoroutine(YokOl());
        }
        else
        {
           float range = Vector3.Distance(this.transform.position, hedefOyuncu.transform.position);
            if (range < rangePlayer) {
                zombieNavMesh.isStopped = false;
                zombieNavMesh.SetDestination(hedefOyuncu.transform.position);
                zombieAnim.SetBool("Run", true);
                zombieAnim.SetBool("Strike", false);
                this.transform.LookAt(hedefOyuncu.transform.position);
            }
            else
            {
                zombieNavMesh.isStopped = true;
                zombieAnim.SetBool("Run", false);
                zombieAnim.SetBool("Strike", false);
            }
            if(range<rangeEnemy)
            {
                zombieNavMesh.isStopped = true;
                zombieAnim.SetBool("Run", false);
                zombieAnim.SetBool("Strike", true);
                this.transform.LookAt(hedefOyuncu.transform.position);

            }
        }
    }
    public void inflictDamage()
    {
        hedefOyuncu.GetComponent<c_script>().TakeDamage();

    }
    IEnumerator YokOl()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

    public void HasarAl()
    {
        zombieHP -= Random.Range(25f, 35f);
    }
}