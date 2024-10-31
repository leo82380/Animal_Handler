using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour
{
    [SerializeField] private GameObject optionUI;

    public void OpenOptionUI()
    {
        Time.timeScale = 0;
        optionUI.SetActive(true);
    }

    private void Start()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(optionUI);
        optionUI.SetActive(false);
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
