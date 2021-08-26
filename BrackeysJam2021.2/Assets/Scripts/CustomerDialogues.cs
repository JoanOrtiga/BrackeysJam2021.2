using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerDialogues : MonoBehaviour
{
    public TMP_Text customerDialogue;
    public TMP_Text customerName;

    private void OnEnable()
    {
        CustomersManager.delegateCustomerDialogue += SetDialogueCustomer;
    }

    private void OnDisable()
    {
        
    }
    private void SetDialogueCustomer(ICustomer c)
    {
        customerDialogue.text = c.Dialogue;
        customerName.text = c.Name;
    }

    private void EnterDialogue()
    {
        if (Input.GetKey(KeyCode.S)){

        }
    }

}
