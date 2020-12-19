using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
   public GameObject a;
    public bool donMove;
    Animator anim;
    public BulletShot shot;
    public Animator []anims = new Animator[3];
    int flag = 0;
    float moveSpeed = 1f;
    Rigidbody2D rigid;
    void Awake()
    {
        a = GameObject.Find("PC");
        anim = GetComponent<Animator>();
       rigid = GetComponent<Rigidbody2D>();
        if (!donMove)
            StartCoroutine("FlagCoroutine");
        else
            StartCoroutine("POCoroutine");
    }
    void FixedUpdate()
    {
        Move();
    }
     public void Stop()
    {
        StopCoroutine("FlagCoroutine");
    }
    public void Run(GameObject a)
    {
        if(!donMove)
        StartCoroutine("RunCoroutine", a);
    }

    void Move()
    {
        rigid.velocity = new UnityEngine.Vector3(0, 0, 0);
        if (flag == 1)
        {
            if (!donMove &&this.transform.position.y <= 17)
                rigid.velocity = new UnityEngine.Vector3(0, moveSpeed, 0);
                this.transform.localScale = new Vector3(1, 1, 1);
            if (!donMove)
                anim.SetInteger("Mode", 4);

            for (int i = 0; i < anims.Length; i++)
            {
                if (anims[i] == null)
                    continue;
                anims[i].SetInteger("Mode", 4);
            } 
        }
        if (flag == 2)
        {
            if (!donMove &&  this.transform.position.y >= -25 )
                rigid.velocity = new UnityEngine.Vector3(0, -moveSpeed, 0);
                this.transform.localScale = new Vector3(1, 1, 1);
            if (!donMove)
                anim.SetInteger("Mode", 1);
            for (int i = 0; i < anims.Length; i++)
            {
                if (anims[i] == null)
                    continue;
                anims[i].SetInteger("Mode", 1);
            }
        }
        if (flag == 3)
        {
            if (!donMove && this.transform.position.x <= 47 )
                rigid.velocity = new UnityEngine.Vector3(moveSpeed, 0, 0);
                this.transform.localScale = new Vector3(-1, 1, 1);
            if (!donMove)
                anim.SetInteger("Mode", 3);
            for (int i = 0; i < anims.Length; i++)
            {
                if (anims[i] == null)
                    continue;
                anims[i].SetInteger("Mode", 3);
            }
        }
        if (flag == 4)
        {
            if (!donMove &&  this.transform.position.x >= -23 )
                rigid.velocity = new UnityEngine.Vector3(-moveSpeed, 0, 0);
                this.transform.localScale = new Vector3(1, 1, 1);
            if (!donMove)
                anim.SetInteger("Mode", 2);
            for (int i = 0; i < anims.Length; i++)
            {
                if (anims[i] == null)
                    continue;
                anims[i].SetInteger("Mode", 2);
            }
        }
    }

    IEnumerator FlagCoroutine()
    {
        flag = Random.Range(1, 5);
        int time = Random.Range(29, 50);
        yield return new WaitForSeconds(time / 10f);
        StartCoroutine("FlagCoroutine");
    }
    IEnumerator RunCoroutine(GameObject a)
    {
        moveSpeed = 2.2f;
        if (a.transform.position.x >= this.transform.position.x)
            flag = 2;
        else if (a.transform.position.x <= this.transform.position.x)
            flag = 3;
        else if (a.transform.position.y >= this.transform.position.y)
            flag = 1;
        else if (a.transform.position.y <= this.transform.position.y)
            flag = 4;
       
        yield return new WaitForSeconds(4f);
        moveSpeed = 1f;
        StartCoroutine("FlagCoroutine");
    }
    IEnumerator POCoroutine()
    {
        if (a.transform.position.x >= this.transform.position.x)
            flag = 3;
        else if (a.transform.position.x <= this.transform.position.x)
            flag = 2;
        yield return new WaitForSeconds(4f);
        anims[0].SetBool("Shot", true);
        yield return new WaitForSeconds(0.4f);
        anims[0].SetBool("Shot", false);
        shot.Shot();
        StartCoroutine("POCoroutine");
    }
}