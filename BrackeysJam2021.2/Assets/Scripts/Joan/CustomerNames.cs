using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChaosAlchemy
{
    [CreateAssetMenu(fileName = "CustomerNames", menuName = "CustomerNames", order = 1)]
    public class CustomerNames : ScriptableObject
    {
        public List<string> customerNames = new List<string>();

        public string GetRandomCustomerName()
        {
            return customerNames[Random.Range(0, customerNames.Count)];
        }
    }

}

