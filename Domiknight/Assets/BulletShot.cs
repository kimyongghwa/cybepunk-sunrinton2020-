using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public bool find;
    public Monster monster;
    public GameObject bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
            find = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            find = false;
    }

    public void Shot()
    {
        if (find)
        {
            Bullet a = Instantiate(bullet, this.transform).GetComponent<Bullet>();
            a.target = monster.a;
            a.Make();
            a.transform.parent = null;
        }

    }
}
