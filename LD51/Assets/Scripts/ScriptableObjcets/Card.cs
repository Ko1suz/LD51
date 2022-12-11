using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 1)]
public class Card : ScriptableObject
{
    public int id;
    public string cardName;
    public int cost;
    public string cardDescription;

    public Sprite artwork;

}
