using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringManager : MonoBehaviour
{
    public string[] mission = new string[5];
    public string[] missionText = new string[5];
    public int missionNum;
    public int sadoNum;
    public int galNum;
    public GameObject book;
    public GameObject go;
    public GameObject clear;

   public static StringManager instance;
    

    public void Awake()
    {
       
        if (instance == null)
            instance = this;
        StartCoroutine("EndingCoroutine");
    }
    private void Update()
    {
        if (missionNum == 1 && PlayerPrefs.GetInt("TheBox") == 1)
        {
            Time.timeScale = 0;
            book.SetActive(true);
            missionNum++;
        }
        if (missionNum == 2 && PlayerPrefs.GetInt("FirstKill") == 1)
        {
            Time.timeScale = 0;
            book.SetActive(true);
            missionNum++;
        }
        if (missionNum == 3 && sadoNum <= 0)
        {
            Time.timeScale = 0;
            book.SetActive(true);
            missionNum++;
        }
    }
    IEnumerator EndingCoroutine()
    {
        yield return new WaitForSeconds(300f);
        if(missionNum == 1)
        clear.SetActive(true);
    }
}
