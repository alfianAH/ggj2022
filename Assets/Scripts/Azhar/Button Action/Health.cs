using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Transform panelHealth; 
    public RawImage healthImage;

    [SerializeField]
    private int health = 3;

    public int HealthValue 
    { 
        get 
        { 
            return health; 
        } 
        set 
        { 
            health = value;
            RefreshObject();
        } 
    }

    private void Start()
    {
        RefreshObject();
    }

    public void RefreshObject()
    {
        foreach (Transform t in panelHealth.transform)
        {
            Destroy(t);
        }
        for (int i = 0; i < health; i++)
        {
            Instantiate(healthImage, panelHealth);
        } 
    }
}
