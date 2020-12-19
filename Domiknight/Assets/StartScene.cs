using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            PlayerPrefs.SetInt("TheBox", 0);
            PlayerPrefs.SetInt("FirstKill", 0);
            SceneManager.LoadScene(1);
        }
    }
}
