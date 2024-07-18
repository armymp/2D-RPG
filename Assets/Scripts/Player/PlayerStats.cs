using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
  ScriptableObjects can live inside assets folder
  In order to create scriptable object in folder you must use [CreateAssetMenu]
 */
[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    // Scriptable Object. Acts like a container to store player stats
    [Header("Config")] 
    public int Level;

    [Header("Health")] 
    public float Health;
    public float MaxHealth;
}
