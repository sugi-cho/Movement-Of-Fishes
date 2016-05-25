using UnityEngine;
using System.Collections;

public class FishCreater : MonoBehaviour
{
    public int numFishes = 100;
    public Vector2 rotateAngleRange;
    public Vector2 speedRange;

    // Use this for initialization
    void Start()
    {
        for (var i = 0; i < numFishes; i++)
        {
            var fish = new GameObject("fish");
            fish.AddComponent<ModelOfFish>();
            var movement = fish.AddComponent<MovementOfFish>();
            movement.maxRotateAngle = Random.Range(rotateAngleRange.x, rotateAngleRange.y);
            movement.speed = Random.Range(speedRange.x, speedRange.y);
            fish.transform.position = transform.position + Random.insideUnitSphere;
            fish.transform.rotation = Random.rotation;
            fish.transform.parent = transform;
        }
    }
}
