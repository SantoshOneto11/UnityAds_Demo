using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Shake(.15f, .2f));
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = originalPos;
    }
}
