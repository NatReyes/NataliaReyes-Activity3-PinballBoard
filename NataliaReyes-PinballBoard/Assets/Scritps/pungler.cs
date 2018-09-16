using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pungler : MonoBehaviour {
    float power;
    float Minpower = 0f;
    public float Maxpower = 100f;
    public Slider powerSlider;
    List<Rigidbody> ballList;
    bool ballReady;

    void Start () {

        powerSlider.minValue = 0f;
        powerSlider.minValue = Maxpower;
        ballList = new List<Rigidbody>();

    }

    
    void Update ()
    {
        if(ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;
        if (ballList.Count > 0)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power <= Maxpower)
                {
                    power += 50 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach(Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }
        else
        {
            ballReady = false;
            power = 0f;

        }

        
    }
        

    // Se llama a OnTriggerEnter cuando el colisionador other escribe en el disparador
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
