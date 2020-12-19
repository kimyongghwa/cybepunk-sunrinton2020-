using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public int hp;
    public bool canhit = true;
    public bool comein = false;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
           
    }
    
    IEnumerator HurtCoroutine()
    {
        canhit = false;
        hp--;
        if (hp <= 0)
            Destroy(this.gameObject);
        yield return new WaitForSeconds(0.1f);
        canhit = true;
    }
}
