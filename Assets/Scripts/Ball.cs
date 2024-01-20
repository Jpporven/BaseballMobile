using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Animator anim;

    public bool slider;
    public bool sinker;
    public bool knuckleball;
    public bool fastball;


    // Start is called before the first frame update
    void Awake()
    {
        anim.SetBool("slider", slider);
        anim.SetBool("sinker", sinker);
        anim.SetBool("knuckleball", knuckleball);
        anim.SetBool("fastball", fastball);

        StartCoroutine(resetBools());
    }

    IEnumerator resetBools()
    {
        yield return new WaitForSeconds(0.01f);

        anim.SetBool("slider", false);
        anim.SetBool("sinker", false);
        anim.SetBool("knuckleball", false);
        anim.SetBool("fastball", false);
    }
    
}
