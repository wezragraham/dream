using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadNextScene()
    {
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(sceneToLoad);
    }
}
