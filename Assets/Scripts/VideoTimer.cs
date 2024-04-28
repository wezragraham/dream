using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoTimer : MonoBehaviour
{
    float timeElapsed;
    float maxTime = 16.4f;
    SceneChanger changer;

    private void Start()
    {
        changer = GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > maxTime)
        {
            changer.LoadNextScene();
        }
    }
}
