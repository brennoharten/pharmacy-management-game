using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inventarioScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] slots;
    public GameObject[] itens;
    public GameObject[] clones = new GameObject[4];
    public GameObject[] npcs = new GameObject[4];
    public GameObject[] npcsInstanciados = new GameObject[100];
    public GameObject spawn;
    public GameObject[] clonesAux = new GameObject[4];
    public int[] slotOcupado = { 0, 0, 0, 0 };
    int ultimoSlot = 0;
    bool primeiro = true;


    GameObject clone;
    GameObject aux;
    GameObject ultimoClone;

    public void  instanciarItem(string nomeItem) {
       
        for (int i = 0; i < itens.Length; i++) {
            if (itens[i].name == nomeItem)
            {
                clone = Instantiate(itens[i]);
            }
        }

            if (slotOcupado[ultimoSlot % 4] == 1)
            {
                Destroy(clones[ultimoSlot % 4]);
            }

            clones[ultimoSlot % 4] = clone;
            slotOcupado[ultimoSlot % 4] = 1;
            ultimoSlot++;
            ultimoClone = clone;        
    }

    public void entregarRemedio(string nomeNpc) {
        string[] remedios = nomeNpc.Replace("(Clone)","").Split('_');
        
        List<string> remediosAux = new List<string>();
        
        for (var i = 1; i < remedios.Length; i++)
        {
            remediosAux.Add(remedios[i]);
            Debug.Log(remedios[i]);
        }

        
        
            for (var z = 0; z < clones.Length; z++)
            {
            for (var i = 0; i < remediosAux.Count; i++) {
                if (slotOcupado[z] == 1)
                {
                    
                    if (remediosAux[i] + "(Clone)" == clones[z].name)
                    {
                        remediosAux.RemoveAt(i);
                    }
                }
            }

            }
        

        
       
        if (remediosAux.Count == 0) {
            
            for (var i = 1; i < remedios.Length; i++)
            {
                removerItem(remedios[i]);
            }
            npcsInstanciados[0].GetComponent<npcScript>().sair();
        }

    }

    

    void removerItem(string nomeItem)
    {

       
        for (int i = 0; i < clones.Length; i++)
        {

            if (clones[i] != null) {
                if (clones[i].name == nomeItem + "(Clone)")
                {
                    Destroy(clones[i]);
                    slotOcupado[i] = 0;
                    break;
                }
            }
                
               
            
        }


    }

    void Start()
    {
        
       npcsInstanciados[0] =  Instantiate(npcs[0],spawn.transform);
        npcsInstanciados[0].transform.position = spawn.transform.position;



    }

    // Update is called once per frame
    void Update()
    {

        for (int i =0;i < clones.Length;i++)
        {
            if (clones[i] !=null) {
                clones[i].transform.position = new Vector2(slots[i].transform.position.x, slots[i].transform.position.y);
            }
        }
       
    }
    
}
