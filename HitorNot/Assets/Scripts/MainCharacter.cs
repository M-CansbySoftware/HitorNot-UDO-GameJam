using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCharacter : MonoBehaviour
{
    public GameManage _GameManager;
    public GameObject _Camera;
    public bool IsItEnd;
    public GameObject CameraWay;
    public Slider _Slider;
    public GameObject ArenaCollision;
    
    private void FixedUpdate()
    {
        if(!IsItEnd)
        { 
        transform.Translate(Vector3.forward * .5f * Time.deltaTime);
        }
    }
    private void Start()
    {
        float distance = Vector3.Distance(transform.position, ArenaCollision.transform.position);
        _Slider.maxValue = distance;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (IsItEnd)
            {
                transform.position = Vector3.Lerp(transform.position, CameraWay.transform.position, .015f);
                if (_Slider.value != 0)
                {
                    _Slider.value -= .005f;
                }
            }
            else
            {
                float distance = Vector3.Distance(transform.position, ArenaCollision.transform.position);
                _Slider.value = distance;

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    if (Input.GetAxis("Mouse X") < 0)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .1f);
                    }
                    if (Input.GetAxis("Mouse X") > 0)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .1f);
                    }
                }


            }
        }

            
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("carpma") || other.CompareTag("toplama") || other.CompareTag("cikartma") || other.CompareTag("bolme"))
        {
            int sayi = int.Parse(other.name);
            _GameManager.AdamYonetim(other.tag,sayi, other.transform);

        }
      else if(other.CompareTag("ArenaCollision"))
        {
            _Camera.GetComponent<ThirdPerson>().IsItEnd = true;
            _GameManager.EnemyAttack();
            IsItEnd = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Column")|| collision.gameObject.CompareTag("ignelikutu") || collision.gameObject.CompareTag("PervaneIgneler"))
        {
            if (transform.position.x > 0)
            {
                transform.position = new Vector3(transform.position.x - .2f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + .2f, transform.position.y, transform.position.z);
            }
        }
    }
}
