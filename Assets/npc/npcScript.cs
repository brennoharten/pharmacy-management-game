using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
 public float speedy = 0.08f;
     float speedx = 0.00f;
  
    public Animator npcAnimator;
   
    
    void moverDireita() {
       
        speedx = 0.08f;
    }
    void moverBaixo() {
        npcAnimator.Play("andandoBaixo");
        
        speedx = 0;
        speedy = -0.08f;

    }
    
    public void sair() {
        
        moverDireita();
        npcAnimator.Play("andandoDireita");
        Invoke("moverBaixo",1f);
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
        npcAnimator.enabled = true;
        speedy = 0.08f;
        npcAnimator.Play("andandoCima");
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += new Vector3(speedx/20, speedy/20, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

           speedy = 0;
           npcAnimator.Play("parado");
        

    }
}
