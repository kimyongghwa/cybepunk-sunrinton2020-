using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public Text texxt;
    public Text texxxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texxt.text = StringManager.instance.mission[StringManager.instance.missionNum];
        texxxt.text = StringManager.instance.missionText[StringManager.instance.missionNum];
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
    
}
