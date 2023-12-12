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
        vg.intensity.value -= lightAmount;
    }

    // Start is called before the first frame update
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
    }
}