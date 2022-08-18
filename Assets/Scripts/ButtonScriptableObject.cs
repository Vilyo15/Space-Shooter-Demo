using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Button", menuName = "ScriptableObjects/ButtonScriptableObject", order = 1)]
public class ButtonScriptableObject : ScriptableObject
{
    public Sprite image;
    public Effect category;
    public int power;
    public string description;
}

public enum Effect 
{ maxHealthPoints, 
    bulletSpeed,
    bulletDamage,
    bulletQuantity,
    hasShield,
    shieldStrenght,
    shieldRecovery,
    nuke,
    heal};

