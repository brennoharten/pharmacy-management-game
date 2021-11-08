using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.05f;
    public bool colidiu = false;
    public GameObject clone;
 
    string prateleiraAtual = "";



    void andar() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float directionX = 1;
        float moveY = Input.GetAxisRaw("Vertical");
        float directionY = 1;

        if (Input.GetKeyDown(KeyCode.D)) {
            directionX = 1;
        } else if (Input.GetKeyDown(KeyCode.A)) {
            directionX = -1;
        };

        if (Input.GetKeyDown(KeyCode.W))
        {
            directionY = 1;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directionY = -1;
        };

        transform.position += new Vector3(moveX * directionX * speed /40, moveY * directionY * speed/40, 0);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        andar();
        if (Input.GetKeyDown(KeyCode.J) && prateleiraAtual !="")
        {
            clone.GetComponent<inventarioScript>().instanciarItem(prateleiraAtual);
        }

    }
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "prateleira_omeprazol")
        {
            prateleiraAtual = "omeprazol";
        }

        else if (collision.gameObject.name == "prateleira_buscopan")
        {
            prateleiraAtual = "buscopan";
        }
        else if (collision.gameObject.name == "prateleira_bandaid")
        {
            prateleiraAtual = "bandaid";
        }
        else if (collision.gameObject.name == "prateleira_paracetamol")
        {
            prateleiraAtual = "paracetamol";
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prateleiraAtual = "";
       
    }
}
