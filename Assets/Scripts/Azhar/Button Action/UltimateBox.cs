using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateBox : MonoBehaviour
{
    public float requestedPower = 20;
    public Slider power;

    [SerializeField]
    private float currentPower;
    // Start is called before the first frame update
    void Start()
    {
        currentPower = 0;
        //StartCoroutine(testCombo());
    }

    // Update is called once per frame
    void Update()
    {
        power.value = currentPower / requestedPower;    
    }

    /// <summary>
    /// add Power smoothly
    /// </summary>
    /// <param name="power">adding power</param>
    public void addPower(float power)
    {
        StartCoroutine(changePower());

        IEnumerator changePower()
        {
            float goal = (currentPower + power);
            float t = 0;
            while (currentPower < goal)
            {
                currentPower = Mathf.MoveTowards(currentPower, goal, t);
                t += Time.deltaTime;
                yield return null;
            }
        }
    } 

    

    IEnumerator testCombo()
    {
        float t = 0;
        while (currentPower < requestedPower)
        {
            currentPower = Mathf.MoveTowards(currentPower, requestedPower, t);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
