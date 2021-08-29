using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerDialogues : MonoBehaviour
{
    public TMP_Text customerDialogue;
    public TMP_Text customerName;

    public CanvasGroup canvas;

    public delegate void CustomerMessages(string textCustomer);
    public static CustomerMessages delegateCustomerMessages;
    private void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }
    private void OnEnable()
    {
        CustomersManager.delegateCustomerDialogue += SetDialogueCustomer;
    }

    private void OnDisable()
    {
        CustomersManager.delegateCustomerDialogue -= SetDialogueCustomer;
    }

    private void Update()
    {
        EnterDialogue();
    }
    private void SetDialogueCustomer(ICustomer c)
    {
        canvas.alpha = 1f;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;

        
        customerDialogue.text = c.Dialogue;
        customerName.text = c.Name;

        delegateCustomerMessages?.Invoke(customerDialogue.text);
    }

    private void EnterDialogue()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        }
    }

}
