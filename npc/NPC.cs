using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(DialogueHandler))]
[RequireComponent(typeof(InteractableObject))]
public class NPC : MonoBehaviour
{
    [SerializeField] private Entity entity;
    private bool player_has_attacked; // is currently aggressive?
    
    //public UnityEvent on_interact;

    public UnityEvent on_hit_by_player; 


    private Health _health;
    private DialogueHandler _dialog_handler;
    private InteractableObject _interactable_obj;

    private void Start()
    {
        _health = GetComponent<Health>();
        _dialog_handler = GetComponent<DialogueHandler>();
        _interactable_obj = GetComponent<InteractableObject>();
    }

    public void Awake() 
    {

    }


    public void Update() 
    {

    }


    public void StartInteraction()
    {
        if (_health._dead) return;
        UIHandler.OpenDialogScreen(entity.dialog_options);
    }

    public string GetName() 
    {
        return this.entity.npc_name;
    }

    public void OnPlayerHit() 
    {
        player_has_attacked = true;   
        if (!_health._dead) on_hit_by_player.Invoke();
        
    }

    public void OnDeath()
    {
        gameObject.AddComponent<Rigidbody>();
    }


}
