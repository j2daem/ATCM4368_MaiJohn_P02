using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMeterShake : MonoBehaviour
{
    [SerializeField] Attraction _attraction = null;

    [SerializeField] float _duration;
    [SerializeField] float _magnitude;

    Coroutine _currentCoroutine = null;

    private void OnEnable()
    {
        _attraction.AttractionUpdated += Shake;
    }

    private void OnDisable()
    {
        _attraction.AttractionUpdated -= Shake;
    }

    public void Shake()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(StartShake());
    }

    public IEnumerator StartShake()
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            float x = Random.Range(-1f, 1f) * _magnitude + originalPosition.x;
            float y = Random.Range(-1f, 1f) * _magnitude + originalPosition.y;
            float z = Random.Range(-1f, 1f) * _magnitude + originalPosition.z;

            transform.localPosition = new Vector3(x, y, z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
