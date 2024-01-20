using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Animator anim;
    public Camera mainCam;

    [Tooltip("Based on collision distance; the higher the value, the more homeruns that will be made on contact.")]
    public float HomeRunAccuracy;
    public float ClickAccuracy;


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            GameObject ball = GameObject.FindWithTag("Ball");

            if (ball != null)
            {
                anim.SetBool("swing", true);

                StartCoroutine(resetAnimBool());
                Debug.Log("Swinging...");
            }
            else
            {
                StopAllCoroutines();
                Debug.Log("No balls were found.");
            }
        }


        if(anim.GetBool("swing"))
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    // When the bat collides with the ball, check to see if it qualifies as a homerun
    // based on the distance the ball was from the barrel (pivot of the object)
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            GameObject ball = GameObject.FindWithTag("Ball");

            if (Vector3.Distance(other.transform.position, ball.transform.position) < HomeRunAccuracy)
            {
                Debug.Log("You hit a homerun!");

                ball.GetComponent<Animator>().enabled = false;
                Vector3 ballGravity = transform.position + new Vector3(0f, -1f, 0f);
                ball.GetComponent<Rigidbody>().AddForce(ballGravity * 10, ForceMode.Impulse);
            }
            else if (Vector3.Distance(other.transform.position, ball.transform.position) > HomeRunAccuracy)
            {
                Debug.Log("You missed the homerun.");
            }
        }
        
    }

    IEnumerator resetAnimBool()
    {
        yield return new WaitForSeconds(0.8f);

        anim.SetBool("swing", false);
    }
}
