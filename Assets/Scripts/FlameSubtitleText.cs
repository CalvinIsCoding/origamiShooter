using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlameSubtitleText : MonoBehaviour
{
   public CapsuleCollider2D capsuleCollider;
    public FireActivator fireActivator;
    public bool switchFlipped;
    public Animator animator;
    public Light2D subtitleLighting;
    

    void Start()
    {
        fireActivator = FindObjectOfType<FireActivator>();
        capsuleCollider.enabled = false;
        subtitleLighting.intensity = 0.7f;
        subtitleLighting.falloffIntensity = 0.9f;
        subtitleLighting.color = new Color(171f/255f, 63f/ 255f, 38f/ 255f);

    }

    // Update is called once per frame
    void Update()
    {

        if(fireActivator == null)
        {
            capsuleCollider.enabled = true;
            animator.SetBool("switchFlipped", true);
            subtitleLighting.intensity = 0.9f;
            subtitleLighting.falloffIntensity = 0.585f;
            subtitleLighting.color = new Color(217f/255f, 197f / 255f, 150f / 255f);
            FlickerFlame();
        }
        else
        { 
                
        }
    }

    void FlickerFlame()
    {

    }
}
