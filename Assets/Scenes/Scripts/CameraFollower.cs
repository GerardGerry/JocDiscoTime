using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    [SerializeField]
    Vector3 _offset;

    public Transform Player;

    [SerializeField]
    float _smoothing = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector2 targetPosition = Player.position + _offset;
        Vector3 actualPosition = Vector3.Lerp(transform.position, targetPosition, _smoothing);

        transform.position = actualPosition;
    }
}
