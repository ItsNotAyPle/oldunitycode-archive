using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WEAPON_TYPE {
    MELEE,
    PISTOL,
    SHOTGUN,
    AR,
    SNIPER
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/weapon", order = 1)]
public class WeaponData : ScriptableObject
{
    public string weapon_name;
    public string weapon_desc;
    public uint firerate;
    public uint damage;
    public float shoot_distance;
    public Animation fire_animation; // mostly for melee weapons
    public Animation reload_animation; 
    public WEAPON_TYPE weapon_type;
    

}