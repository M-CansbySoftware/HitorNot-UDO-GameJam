using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mustafa;

public class LevelManager : MonoBehaviour
{
    public Button[] LevelButtons;
    public int Level;
    public Sprite LockButton;
    public GameObject LoadingScreen;
    public Slider LoadingSlider;

    MemoryManage _MemoryManage = new MemoryManage();
    public AudioSource ButtonSound;
    void Start()
    {

        ButtonSound.volume = _MemoryManage.DataRead_Float("MenuFx");
        int currentLevel = _MemoryManage.DataRead_int("LastLevel");
        int Index = 1;

        for(int i=0; i<LevelButtons.Length; i++)
        {
            if (Index <= currentLevel)
            {
                LevelButtons[i].GetComponentInChildren<Text>().text = Index.ToString();
                int SceneIndex = Index;
                LevelButtons[i].onClick.AddListener(delegate { SceneLoader(SceneIndex); });
            }
            else 
            {
                LevelButtons[i].GetComponent<Image>().sprite = LockButton;
                LevelButtons[i].enabled = false;
            }
            Index++;
        }
    }
    public void SceneLoader(int Index)
    {
        ButtonSound.Play();
        
        StartCoroutine(LoadAsync(Index));

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

    public void TurnBack()
    {
        ButtonSound.Play();
        SceneManager.LoadScene(0);
    }
}
