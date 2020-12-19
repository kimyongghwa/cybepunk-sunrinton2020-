using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionText : MonoBehaviour
{
    public Text texxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texxt.text = StringManager.instance.mission[StringManager.instance.missionNum];
    }
}
