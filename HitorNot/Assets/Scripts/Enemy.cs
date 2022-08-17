using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject saldiri_hedefi;
    NavMeshAgent _Navmesh;
    bool AttackisON;
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
    }
    public void AnimasyonTetikle()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        AttackisON = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (AttackisON) { 
        _Navmesh.SetDestination(saldiri_hedefi.transform.position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarakterler"))
        {
            Vector3 yenipoz = new Vector3(transform.position.x, .23f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManage>().Yokolmaefektiolustur(yenipoz,false,true);
            gameObject.SetActive(false);

        }
    }
}
