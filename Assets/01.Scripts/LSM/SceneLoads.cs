using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoads : MonoBehaviour
{
    public void SceneLaod(int load)
    {
        SceneManager.LoadScene(load);
    }
}
