using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MoreVision : MonoBehaviour
{
    [SerializeField] private GameObject volumeGameObject;
    private Volume volume;
    private Vignette vg;
    private float darknnessCoolDownTimer;
    private float abillityCoolDownTimer;
    private bool abillityReady = true;
    private bool postAbillityBool = false;

    [SerializeField] private float minimumLight = 0.55f;
    [SerializeField] private float abillityCoolDown = 5f;
    [SerializeField] private float darknessCoolDown = 1.5f;
    [SerializeField] private float darknessAmount = 0.001f;
    [SerializeField] private float lightAmount = 0.06f;
    [SerializeField] private float burstAbillityAmount = 0.15f;
    [SerializeField] private float maxLight = 0.25f;
    [SerializeField] private float postAbillityDecay = 0.02f;
    [SerializeField] private float postAbillityDecayReach = 0.675f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            BrighterTheScreen();
            Destroy(other.gameObject);
        }
    }

    public void BrighterTheScreen()
    {
        if (vg.intensity.value - lightAmount <= maxLight)
        {
            vg.intensity.value = maxLight;
        }
        else
        {
            vg.intensity.value -= lightAmount; 
        }
    }
    
    void Start()
    {
        abillityCoolDownTimer = abillityCoolDown;
        darknnessCoolDownTimer = darknessCoolDown;
        volume = volumeGameObject.GetComponent<Volume>();
        volume.profile.TryGet(out vg);
    }

    private void Update()
    {
        if (abillityCoolDown >= 0)
        {
            abillityCoolDown -= Time.deltaTime;
        }
        else
        {
            abillityReady = true;
        }
        if (darknessCoolDown >= 0)
        {
            darknessCoolDown -= Time.deltaTime;
        }
        else
        {
            float tempValue = vg.intensity.value;
            tempValue += darknessAmount;
            if (tempValue >= minimumLight)
            {
                vg.intensity.value = minimumLight;
            }
            else
            {
                vg.intensity.value = tempValue;
            }
            
            if (postAbillityBool)
            {
                darknessCoolDown = postAbillityDecay;
                if (vg.intensity.value >= postAbillityDecayReach)
                {
                    TogglePostAbillity();
                    darknessCoolDown = darknnessCoolDownTimer;
                }
            }
            else
            {
                darknessCoolDown = darknnessCoolDownTimer;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (abillityReady)
            {
                BurstAbillity();
                abillityCoolDown = abillityCoolDownTimer;
                abillityReady = false;
                TogglePostAbillity();
            }
            
        }
    }

    private void TogglePostAbillity()
    {
        if (postAbillityBool)
        {
            postAbillityBool = false;
        }
        else
        {
            postAbillityBool = true;
        }
    }

    private void BurstAbillity()
    {
        if (vg.intensity.value - lightAmount <= maxLight)
        {
            vg.intensity.value = maxLight;
        }
        else
        {
            vg.intensity.value -= burstAbillityAmount;
        }
    }
}