using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mustafa;
using UnityEngine.SceneManagement;
public class GameManage : MonoBehaviour
{
    public static int anlikkaraktersayisi = 1;

    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektler;
    public List<GameObject> KaybolmaEfektler;
    public List<GameObject> AdamLekesi;
    [Header("Level Datas")]
    public List<GameObject> Enemies;
    public int CountEnemies;
    public GameObject _MainChar;
    public bool isGameEnd; //finishgame//
    public bool IsItEnd; //arenacolllision//

    MatematikselHesaplamalar _Math_Calcs = new MatematikselHesaplamalar();
    MemoryManage _memoryManage = new MemoryManage();
    Scene _Scene;
    [Header("-------General Datas")]
    public AudioSource[]SoundsVoices;
    public GameObject[] ProcessPanels;
    public Slider GameVoiceSet;
    public GameObject LoadingScreen;
    public Slider LoadingSlider;

    private void Awake()
    {
        SoundsVoices[0].volume = _memoryManage.DataRead_Float("GameMusic");
        GameVoiceSet.value = _memoryManage.DataRead_Float("GameMusic");
        SoundsVoices[1].volume = _memoryManage.DataRead_Float("MenuFx");
        Destroy(GameObject.FindWithTag("MenuMusic"));
    }

    void Start()
    {
        CreateEnemy();
        /* _memoryManage.DataSave_String("Name", "Mustafa");
         _memoryManage.DataSave_int("Age",23);
         _memoryManage.DataSave_Float("Point",1.5f ); 

         Debug.Log(_memoryManage.DataRead_String("Name"));
         Debug.Log(_memoryManage.DataRead_int("Age"));
         Debug.Log(_memoryManage.DataRead_Float("Point")); */
        _Scene = SceneManager.GetActiveScene();
    }
    public void CreateEnemy()
    {
        for (int i = 0; i < CountEnemies; i++)
        {
            Enemies[i].SetActive(true);
        }
    }


    public void EnemyAttack()
    {
        foreach (var item in Enemies)
        {
            if(item.activeInHierarchy)
            {
                item.GetComponent<Enemy>().AnimasyonTetikle();
            }
        }
        IsItEnd = true;
        WarSituation();
    }

   

    void WarSituation()
    {
        if(IsItEnd)
        {
            if (anlikkaraktersayisi == 1 || CountEnemies == 0)
            {
                isGameEnd = true;
                foreach (var item in Enemies)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Attack", false);
                    }
                }
                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Attack", false);
                    }
                }
                _MainChar.GetComponent<Animator>().SetBool("Attack", false);

                if (anlikkaraktersayisi <= CountEnemies)
                {
                    ProcessPanels[3].SetActive(true);
                }
                else
                {
                    _memoryManage.DataSave_int("LastLevel",_memoryManage.DataRead_int("LastLevel")+1 );
                    ProcessPanels[2].SetActive(true);

                }

            }
        }

    }

    public void AdamYonetim(string islemturu, int Gelensayi, Transform pozisyon)
    {
        switch (islemturu)
        {
            case "carpma":
                _Math_Calcs.carpma(Gelensayi, Karakterler, pozisyon,OlusmaEfektler);
                break;
            case "toplama":
                _Math_Calcs.toplama(Gelensayi, Karakterler, pozisyon,OlusmaEfektler);
                break;
            case "cikartma":
                _Math_Calcs.cikartma(Gelensayi, Karakterler,KaybolmaEfektler);
                break;
            case "bolme":
                _Math_Calcs.bolme(Gelensayi, Karakterler,KaybolmaEfektler);
                break;

        }
    }

    public void Yokolmaefektiolustur(Vector3 pozisyon,bool Balyoz=false, bool situation=false)
    {
        foreach (var item in KaybolmaEfektler)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                item.GetComponent<AudioSource>().Play();
                if (!situation)
                    anlikkaraktersayisi--;
                else
                    CountEnemies--;
                break;
              

            }
        }
        
        if (Balyoz)
        {
            Vector3 yenipoz = new Vector3(pozisyon.x, .005f, pozisyon.z);
            foreach (var item in AdamLekesi)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yenipoz;
                    

                    break;


                }
            }
        }
        if (!isGameEnd)
        {
            WarSituation();
        }
    }

    public void ExitButtonProcess(string _situation)
    {
        SoundsVoices[1].Play();
        Time.timeScale = 0;
        if (_situation == "Pause")
        { 
            ProcessPanels[0].SetActive(true); 
        }
        else if (_situation== "Continue")
        { 
            ProcessPanels[0].SetActive(false);
            Time.timeScale = 1;
        }
        else if (_situation == "Restart")
        {
            SceneManager.LoadScene(_Scene.buildIndex);
            Time.timeScale = 1;
        }
        else if (_situation == "MainMenu")
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }


    }
    public void Settings(string _situation)
    {
        if (_situation == "Set")
        {
            ProcessPanels[1].SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            ProcessPanels[1].SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void VoiceSet()
    {
        _memoryManage.DataSave_Float("GameMusic", GameVoiceSet.value);
        SoundsVoices[0].volume = GameVoiceSet.value;


        
    }

    public void NextLevel()
    {
        StartCoroutine(LoadAsync(_Scene.buildIndex + 1));

    }
    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneIndex);
        LoadingScreen.SetActive(true);
        while (!Operation.isDone)
        {
            float progress = Mathf.Clamp01(Operation.progress / .9f);
            LoadingSlider.value = progress;
            yield return null;
        }

    }


}
