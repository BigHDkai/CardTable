using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardsManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] Button card;

    Tweener tweener;
    //int[] poke = new int[54];
    int[] poke1 = {0,1,21};
    int[] poke2 = {5,11,44};
    int[] poke3 = {23,45,27};
    void Start()
    {
        for(int i =0 ,j=0,k=0; i < poke1.Length+poke2.Length+poke3.Length+1 ; i++)
        {
            var cards = Instantiate(card,transform.position,new Quaternion(0,0,0,0) ,transform );
            if(i<3)
            {
            cards.GetComponentInChildren<Text>().text = poke1[i].ToString();
            }else if(i<6)
            {
                cards.GetComponentInChildren<Text>().text = poke2[j].ToString();
                j++;
                
            }else if(i<9)
            {
                cards.GetComponentInChildren<Text>().text = poke3[k].ToString();
                k++;
            }
            cards.GetComponentInChildren<Text>().enabled = false;
        }

        for(int i =0 , j =-300 ; i < poke1.Length ; i++,j+=30)
        {
            tweener = transform.GetChild(i).DOLocalMove(new Vector3(j,0,0),1);   
        }

        for(int i =3 , j =240 ; i < poke1.Length+poke2.Length ; i++,j+=30)
        {
            tweener = transform.GetChild(i).DOLocalMove(new Vector3(j,0,0),1);   
        }

        for(int i =6 , j =-30 ; i < poke1.Length+poke2.Length+poke3.Length ; i++,j+=30)
        {
            tweener = transform.GetChild(i).DOLocalMove(new Vector3(j,-130,0),1);   
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.GetChild(8).transform.localPosition.x == 30 & transform.GetChild(0).GetComponentInChildren<Text>().enabled == false){
            
            for(int i =0 ; i < poke1.Length+poke2.Length+poke3.Length ; i++)
            {
                transform.GetChild(i).GetComponentInChildren<Text>().enabled = true;
            }
        }
    }
}
