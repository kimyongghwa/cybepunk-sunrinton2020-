using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rigid;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();    
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Move()
    {
            direction.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            direction = direction.normalized * moveSpeed * Time.deltaTime;
            rigid.MovePosition(transform.position + direction);
    }
}
