using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private GameObject optionUI;
    public List<string> mapString;

    [Range(1,3)] public int stage = 1;

    public void OpenOptionUI()
    {
        Time.timeScale = 0;
        optionUI.SetActive(true);
    }

    private void Awake()
    {
        foreach (var item in FindObjectsOfType<OptionPanel>())
        {
            if(item != this)
            {
                Destroy(item.gameObject);
            }
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
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
