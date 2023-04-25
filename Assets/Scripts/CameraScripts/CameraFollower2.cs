using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower2 : MonoBehaviour
{
    [SerializeField]
    Transform _player;
    [SerializeField]
    float _smoothing = 0.1f;
    [SerializeField]
    Vector3 _offset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector3 targetPosition = _player.position + _offset;
        Vector3 actualPosition = Vector3.Lerp(transform.position, targetPosition, _smoothing);

        transform.position = actualPosition;
    }
}
