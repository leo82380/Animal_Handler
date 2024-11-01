using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour
{
    [SerializeField] private GameObject optionUI;
    public List<string> mapString;

    [Range(1,3)] public int stage = 1;

    public void OpenOptionUI()
    {
        Time.timeScale = 0;
        optionUI.SetActive(true);
    }

    private void Start()
    {
        if(FindObjectsOfType<option>().Length == 1)
        {
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(optionUI);
        }

        
        optionUI.SetActive(false);

        for (int i = 0; i < 10; i++)
        {
            int n = Random.Range(1, 4), r =  Random.Range(1,4);
            string temp = mapString[n];
            mapString[n] = mapString[r];
            mapString[r] = temp;
        }
    }

    public void NextScene()
    {
        SceneMove("PolarBear");
    }

    public void SceneMove(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void CloseOption()
    {
        optionUI.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenOptionUI();
        }
    }
}
