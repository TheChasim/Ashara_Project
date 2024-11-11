using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleEffect : MonoBehaviour
{
    [SerializeField] GameObject hoverParticle;
    ParticleSystem hoverEffect;

    [SerializeField] ParticleSystem engineParticleSystem;
    [SerializeField] TrailRenderer engineTrailRenderer;


    HoverBike bike;


    // Start is called before the first frame update
    void Start()
    {
        bike = GetComponent<HoverBike>();
        hoverEffect = hoverParticle.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        HoverEffect();
        EngineParticleSystem();
    }

    private void EngineParticleSystem()
    {
        if(bike.input.y != 0)
        {
            engineParticleSystem.Play();
            engineTrailRenderer.emitting = true;
        }
        else
        {
            engineParticleSystem.Stop();
            engineTrailRenderer.emitting = false;
        }
    }

    private void HoverEffect()
    {
        if (bike.isMoving)
        {
            Ray ray = new Ray(this.transform.position, Vector3.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, bike.maxHover + 2f, bike.layerMask))
            {           
                hoverParticle.transform.position = hit.point;
                hoverEffect.Play();
            }
        }
        else
        {
           hoverEffect.Stop();       
        }


    }
}
