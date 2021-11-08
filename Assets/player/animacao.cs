using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacao : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator playerAnimator;
    string lado = "baixo";
    void ani() {
        if (Input.GetKey(KeyCode.A))
        {
            playerAnimator.Play("esquerda");
            lado = "parado esq";
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerAnimator.Play("direita");
            lado = "parado dir";
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerAnimator.Play("baixo");
            lado = "parado baixo";
        }
        else if (Input.GetKey(KeyCode.W))
        {
            playerAnimator.Play("cima");
            lado = "parado cima";
        }
        else {
            playerAnimator.Play(lado);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ani();
    }
}
