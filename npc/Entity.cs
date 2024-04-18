using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName="NPC", menuName="Entity/npc")]
public class Entity : ScriptableObject 
{
    public static GameObject default_model;
    public string npc_name;
    public bool will_attack_back; // will attack back?

    [Header("Interaction options")]
    // surely if dialog_options is zero
    // then theres no interaction. duh
    public bool interactable;
    public List<DialogueOption> dialog_options;
}
