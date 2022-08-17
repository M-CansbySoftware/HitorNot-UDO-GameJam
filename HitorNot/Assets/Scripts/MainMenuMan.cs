using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mustafa;

public class MainMenuMan : MonoBehaviour
{
    MemoryManage _Memorymanage = new MemoryManage();
    public AudioSource ButtonSound;
    public GameObject LoadingScreen;
    public Slider LoadingSlider;
    // Start is called before the first frame update
    void Start()
    {
        _Memorymanage.ControlnDefinition();
        //ButtonSound.volume= _Memorymanage.DataRead_Float("MenuFx");
    }

    public void SceneLoad(int Index)
    {
        ButtonSound.Play();
        SceneManager.LoadScene(Index);
    }
    public void playGame()
    {

        ButtonSound.Play();
        StartCoroutine(LoadAsync(_Memorymanage.DataRead_int("LastLevel")));
           
        
    }
    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneIndex);
        LoadingScreen.SetActive(true);
        while (!Operation.isDone)
        {
            float progress = Mathf.Clamp01(Operation.progress/.9f);
            LoadingSlider.value = progress;
            yield return null;
        }

    }
}
