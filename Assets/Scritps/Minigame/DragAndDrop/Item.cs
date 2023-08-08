using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    //Item scriptable objects set the parameter of an item
    public int ItemIndex;  //1 Wire //2 Resistor //3 Battery //4 Lamp
    public Sprite icon;
}

