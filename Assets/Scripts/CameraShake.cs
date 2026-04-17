using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    
	
    // How long the object should shake for.
    [SerializeField] private float shakeDuration = 1f;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    [SerializeField]private float shakeAmount = 0.7f;
    [SerializeField]private float decreaseFactor = 1.0f;
    [HideInInspector] public BirdController bird;

    private Vector3 _originalPos;
    private Transform _camera;

    private void Awake()
    {
        _camera = Camera.main?.transform;
        if (_camera == null)
        {
            _camera = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void OnEnable()
    {
        _originalPos = _camera.localPosition;
    }

    private void Shaking()
    {
        _camera.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;
        
    }
    private void Update()
    {
        if (shakeDuration > 0)
        {
            _camera.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;
			
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            _camera.localPosition = _originalPos;
        }
    }
}