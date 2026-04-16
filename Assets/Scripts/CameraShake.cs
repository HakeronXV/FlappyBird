using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    
	
    // How long the object should shake for.
    [SerializeField]private float shakeDuration = 0f;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    [SerializeField]private float shakeAmount = 0.7f;
    [SerializeField]private float decreaseFactor = 1.0f;

    private Vector3 originalPos;
    private Transform _camera;

    private void Awake()
    {
        _camera = Camera.main.transform;
        if (_camera == null)
        {
            _camera = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void OnEnable()
    {
        originalPos = _camera.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            _camera.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            _camera.localPosition = originalPos;
        }
    }
}