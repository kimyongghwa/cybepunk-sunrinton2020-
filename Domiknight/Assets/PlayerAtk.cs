using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtk : MonoBehaviour
{
    Animator anim;
    public Transform pos;
    public GameObject bullet;
    public GameObject effect;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (StringManager.instance.missionNum == 4)
                StringManager.instance.go.SetActive(true);
            Vector3 posi = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            if(anim.GetInteger("Mode") == 1)
                posi = new Vector3(this.transform.position.x, this.transform.position.y-1.5f, 0);
            if (anim.GetInteger("Mode") == 4)
                posi = new Vector3(this.transform.position.x, this.transform.position.y + 1.5f, 0);
            if (anim.GetInteger("Mode") == 2)
                posi = new Vector3(this.transform.position.x - 1.5f, this.transform.position.y, 0);
            if (anim.GetInteger("Mode") == 3)
                posi = new Vector3(this.transform.position.x + 1.5f, this.transform.position.y, 0);
            pos.position = posi;
            GameObject a = Instantiate(effect, pos);
            a.transform.parent = null;
        }
    }
}
