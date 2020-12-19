using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerReach : MonoBehaviour
{
    public GameObject target;
    public CameraCont cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = cam.GetClickedObject();
            if(target.tag == "Block")
            {
                Block block = target.GetComponent<Block>();
                if (block.comein && block.canhit)
                {
                    block.StartCoroutine("HurtCoroutine");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if(collision.tag == "Block")
        {
            Block block = collision.GetComponent<Block>();
            block.comein = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Block")
        {
            Block block = collision.GetComponent<Block>();
            block.comein = false;
        }
    }
    


}
