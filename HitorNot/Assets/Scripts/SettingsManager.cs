using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mustafa;


public class SettingsManager : MonoBehaviour
{
    public AudioSource ButtonSound;
    public Slider MenuMusic;
    public Slider MenuFx;
    public Slider GameMusic;
    MemoryManage _MemoryManage = new MemoryManage();

    void Start()
    {
        ButtonSound.volume = _MemoryManage.DataRead_Float("MenuFx");

        MenuMusic.value = _MemoryManage.DataRead_Float("MenuMusic");
        MenuFx.value = _MemoryManage.DataRead_Float("MenuFx");
        GameMusic.value = _MemoryManage.DataRead_Float("GameMusic");
    }

   

    public void SetVolume(string whichOption)
    {
        switch (whichOption)
        {
            case "MenuMusic":
                
                _MemoryManage.DataSave_Float("MenuMusic", MenuMusic.value);
                break;

            case "MenuFx":
                
                _MemoryManage.DataSave_Float("MenuFx", MenuFx.value);
                break;

            case "GameMusic":
                
                _MemoryManage.DataSave_Float("GameMusic", GameMusic.value);
                break;
        }

    }


    public void TurnBack()
    {
        ButtonSound.Play();
        SceneManager.LoadScene(0);
    }
}
