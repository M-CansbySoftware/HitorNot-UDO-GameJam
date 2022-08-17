using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Crew : MonoBehaviour
{
    
    NavMeshAgent _Navmesh;
    public GameManage _gameManager;
    public GameObject Target;

    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }
   Vector3 PositionController()
    {
        return new Vector3(transform.position.x, .23f, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ignelikutu"))
        {
            
            _gameManager.Yokolmaefektiolustur(PositionController());
            gameObject.SetActive(false);
            
        }
        else if (other.CompareTag("Testere"))
        {
            
            _gameManager.Yokolmaefektiolustur(PositionController());
            gameObject.SetActive(false);

        }
        else if (other.CompareTag("PervaneIgneler"))
        {
            
            _gameManager.Yokolmaefektiolustur(PositionController());
            gameObject.SetActive(false);

        }
        else if (other.CompareTag("Balyoz"))
        {         
            _gameManager.Yokolmaefektiolustur(PositionController(), true);
            gameObject.SetActive(false);

        }
        else if (other.CompareTag("Enemy"))
        {
            _gameManager.Yokolmaefektiolustur(PositionController(), false,false);
            gameObject.SetActive(false);

        }
    }


}
