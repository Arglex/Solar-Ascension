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

    [SerializeField] private float darknessCoolDown = 1.5f;
    [SerializeField] private float darknessAmount = 0.001f;
    [SerializeField] private float lightAmount = 0.06f;
    [SerializeField] private float burstAbillityAmount = 0.15f;
    [SerializeField] private float maxLight = 0.25f;

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
        darknnessCoolDownTimer = darknessCoolDown;
        volume = volumeGameObject.GetComponent<Volume>();
        volume.profile.TryGet(out vg);
    }

    private void Update()
    {
        if (darknessCoolDown > 0)
        {
            darknessCoolDown -= Time.deltaTime;
        }
        else
        {
            vg.intensity.value += darknessAmount;
            darknessCoolDown = darknnessCoolDownTimer;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            BurstAbillity();
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