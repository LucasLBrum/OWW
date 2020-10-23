using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeCharge : MonoBehaviour
{
    public Sprite[] sprites;
    int currentSprite;
    public Image panel;


    private void Start()
    {
        currentSprite = sprites.Length;
    }
    public void ChangeSprite() 
    {
 
        if(currentSprite <= 0) 
        {
            Game.singleton.estadoJogando.EnterState();
            panel.gameObject.SetActive(false);
        }
        else 
        {
            currentSprite--;
            panel.sprite = sprites[currentSprite];
        }
    }


    public void ChangeSpriteFinal()
    {

        if (currentSprite <= 0)
        {
            panel.gameObject.SetActive(false);
            Game.singleton.estadoFim.EnterState();

        }
        else
        {
            currentSprite--;
            panel.sprite = sprites[currentSprite];
        }
    }
}
