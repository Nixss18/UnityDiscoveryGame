using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light m_light;
    public bool flashlightDrain;
    public float maxBrightness;
    public float minBrightness;
    public float drainRate;
    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        m_light.intensity = Mathf.Clamp(m_light.intensity,minBrightness,maxBrightness);
        if(flashlightDrain == true && m_light.enabled == true){
            if(m_light.intensity > minBrightness){
                m_light.intensity -= Time.deltaTime * (drainRate / 1000);
            }
        }
        if(Input.GetKeyDown(KeyCode.F)){
            m_light.enabled = !m_light.enabled;
        }
    }
}
