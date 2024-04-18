using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOptionUIObject : MonoBehaviour
{
    DialogueOption option;

    public DialogueOptionUIObject(Transform parent, DialogueOption option)
    {
        this.option = option;
        //transform.GetChild(0).GetComponent<Text>().text = option.question;
        //transform.SetParent(parent, true);
    }

    void Awake()
    {
            
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
