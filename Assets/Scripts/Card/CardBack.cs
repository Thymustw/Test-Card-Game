using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    GameObject front;
    GameObject back;
    Card card;

    void Awake()
    {
        front = transform.GetChild(0).gameObject;
        back = transform.GetChild(1).gameObject;
        card = GetComponent<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        if(card.GetCardBackBool())
        {
            front.SetActive(false);
            back.SetActive(true);
        }
        else
        {
            front.SetActive(true);
            back.SetActive(false);
        }
    }
}
