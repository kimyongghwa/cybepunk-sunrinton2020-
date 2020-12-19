using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float gak;
    public float moveSpeed;
    public GameObject target;
    // Start is called before the first frame update
    public void Make()
    {
        gak = Mathf.Atan2(transform.position.y - target.transform.position.y, transform.position.x - target.transform.position.x) * 180f / Mathf.PI;

        transform.Rotate(0, 0, gak);
        transform.localScale = new Vector3(1, 1, 1);
        Destroy(this.gameObject, 2.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, gak));
        transform.localScale = new Vector3(1, 1, 1);
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (--collision.GetComponent<PlayerInfo>().nowHp <= 0)
                StringManager.instance.go.SetActive(true);
        }
    }
}
