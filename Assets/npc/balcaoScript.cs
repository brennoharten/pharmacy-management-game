using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balcaoScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool playerDentro = false;
    bool npcDentro = false;
    string nomeNpc = "";
    public GameObject clone;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDentro && npcDentro && Input.GetKeyDown(KeyCode.J)) {
           
            clone.GetComponent<inventarioScript>().entregarRemedio(nomeNpc);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("npc") ) {
            npcDentro = true;
            nomeNpc = collision.gameObject.name;
            Debug.Log("deu certo");
        }
        if (collision.gameObject.name == "player")
        {
             playerDentro = true;
            Debug.Log("deu certo");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("npc"))
        {
            npcDentro = false;
          
        }
        if (collision.gameObject.name == "player")
        {
            playerDentro = false;
           
        }
    }

}
