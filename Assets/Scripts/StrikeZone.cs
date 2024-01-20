using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeZone : MonoBehaviour
{
    
    public GameObject strikeDisplay;

    public float strikeResetDelay;

    GameObject currentStrike;
    Transform lastStrikePos;
    Transform currentStrikePos = null;

    // If a strike is thrown through the strikezone, stop all coroutines to avoid duplicate strike displays 
    void FixedUpdate()
    {
        if (currentStrike = null)
        {
            StopAllCoroutines();
        }
    }

    // If the ball goes through the strikezone, record the position it made contact with the ball at for when we
    // instantiate it. Then, start the coroutine of instantiating the strike display.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            currentStrikePos = other.transform;

            StartCoroutine(displayStrike(strikeResetDelay, strikeDisplay));

            Debug.Log("Ball collided");
        }
    }

    // Display the strike in the position recorded previously, then update it to be the lastStrikePos
	// (last position of strike thrown)
    IEnumerator displayStrike(float resetStrikeDelay, GameObject display)
    {
        Instantiate(display, currentStrikePos.transform.position, Quaternion.identity);

        currentStrike = null;

        yield return new WaitForSeconds(resetStrikeDelay);

        GameObject indicator = GameObject.FindWithTag("Indicator");

        Destroy(indicator);

        lastStrikePos = currentStrikePos;
        currentStrikePos = lastStrikePos;
    }
}
