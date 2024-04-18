using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DialogeOption", menuName = "ScriptableObjects/dialogue option")]
public class DialogueOption : ScriptableObject
{
    public string question;
    public string response;
    public UnityEvent onpress;
    public List<DialogueOption> unlocks;
    public AudioClip dialog_response_audio;
}
