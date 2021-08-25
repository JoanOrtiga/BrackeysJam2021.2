using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;


public class CustomersManager : MonoBehaviour
{
    private static List<ICustomer> customersList;

    private static ICustomer customer;

    public static ICustomer Customer { get { return customer; } }

    private void Awake()
    {
        customersList = new List<ICustomer>();
        GetProjectCustomers();
        SetRandomCustomer();
    }

    private void GetProjectCustomers()
    {
        var listCustomers = Assembly.GetAssembly(typeof(ICustomer)).GetTypes()
            .Where(x => !x.IsInterface && typeof(ICustomer).IsAssignableFrom(x));

        foreach (var type in listCustomers)
        {
            var tempCustomer = Activator.CreateInstance(type);
            customersList.Add((ICustomer)tempCustomer);
        }
    }

    public static void SetRandomCustomer()
    {
        customer = customersList[UnityEngine.Random.Range(0, customersList.Count)];
    }
}
