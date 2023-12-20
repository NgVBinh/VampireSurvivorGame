using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Attributes
{
    public int indexAttribute;
    public string nameAttribute;
    public Sprite sprite;
    public int amount;

    public Attributes(int indexAttribute, string nameAttribute, Sprite sprite, int amount)
    {
        this.indexAttribute = indexAttribute;
        this.nameAttribute = nameAttribute;
        this.sprite = sprite;
        this.amount = amount;
    }
}
