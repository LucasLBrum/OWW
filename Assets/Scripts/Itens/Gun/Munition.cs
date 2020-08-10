using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour
{
    public int boxMunition;
    public int boxMunitionMax = 50;
    public UnityEngine.UI.Text bulletText;
    public MunitionType type;

    public void AddMunition(int munition)
    {
        boxMunition += munition;
        if(boxMunition > boxMunitionMax)
        {
            boxMunition = boxMunitionMax;
        }
        bulletText.text = boxMunition.ToString();
    }

    public void RemoveMuniton(int munition)
    {
        boxMunition -= munition;
         bulletText.text = boxMunition.ToString();
        if(boxMunition < 0)
        {
            boxMunition = 0;
        }
        bulletText.text = boxMunition.ToString();
    }

    private void Start()
    {
        if(bulletText != null)
        bulletText.text = boxMunition.ToString();
    }
}
