using UnityEngine;
using System.Collections;

public class MovementOfFish : MonoBehaviour
{
    static Transform FishTarget { get { if (_target == null) _target = FindObjectOfType<MovementOfTarget>().transform; return _target; } }
    static Transform _target;

    public float maxRotateAngle = 45f;
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var toVec = FishTarget.position - pos;
        var toRot = Quaternion.FromToRotation(Vector3.forward, toVec);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, maxRotateAngle * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
