using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public LayerMask mobLayer;

    void Start()
    {
        Destroy(this.gameObject, 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mob" && !collision.isTrigger)
        {
            if (--collision.gameObject.GetComponent<PlayerInfo>().nowHp <= 0)
            {
                if (collision.gameObject.GetComponent<PlayerInfo>().isBox)
                    PlayerPrefs.SetInt("TheBox", 1);
                else
                {
                    PlayerPrefs.SetInt("FirstKill", 1);
                }
                if (collision.gameObject.GetComponent<PlayerInfo>().sado)
                    StringManager.instance.sadoNum--;
                Destroy(collision.gameObject);
                Collider2D[] colliderArray = Physics2D.OverlapCircleAll(collision.gameObject.transform.position, 10f, mobLayer);
                foreach(Collider2D col in colliderArray)
                {
                    Debug.Log(col.gameObject.name);
                    if (col.gameObject.tag == "Mob" && !col.isTrigger)
                    {

                        col.GetComponent<Monster>().Run(this.gameObject);/*StartCoroutine("RunCoroutine", col.gameObject);*/
                        col.GetComponent<Monster>().Stop();/*topCoroutine("FlagCoroutine");*/
                    }
                }
            }
        }
    }
}
