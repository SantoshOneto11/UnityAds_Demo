using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 50f;

    // Speed multiplier when tapped
    public float tapMultiplier = 2f;

    // Duration of speed increase
    public float tapDuration = 1f;

    private float currentRotationSpeed;
    private bool isTapped = false;

    void Start()
    {
        currentRotationSpeed = rotationSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTapped || Input.GetMouseButtonDown(0)) // Change KeyCode.Space to the desired input key
        {
            isTapped = true;
            StartCoroutine(IncreaseRotationSpeed());
        }

        // Rotate the object around its local Z axis at the current speed
        transform.Rotate(Vector3.forward, -currentRotationSpeed * Time.deltaTime);
    }

    IEnumerator IncreaseRotationSpeed()
    {
        currentRotationSpeed *= tapMultiplier;

        yield return new WaitForSeconds(tapDuration);

        while (currentRotationSpeed > rotationSpeed)
        {
            currentRotationSpeed -= (tapMultiplier - .5f) * rotationSpeed * Time.deltaTime;
            yield return null;
        }

        currentRotationSpeed = rotationSpeed;
        isTapped = false;
    }

}
