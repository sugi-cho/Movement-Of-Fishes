using UnityEngine;
using System.Collections;

public class MovementOfTarget : MonoBehaviour
{

    public float valA = 1f;
    public float valB = 1f;
    public float valC = 1f;
    public float valD = 5f;
    public float speed = 0.2f;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        transform.position = GetPosition(Time.time * speed);
    }

    Vector3 GetPosition(float t)
    {
        var pos = Vector3.zero;
        pos.x = valA * Mathf.Sin(t);
        pos.y = valB * Mathf.PerlinNoise(pos.x, t);
        pos.z = valC * Mathf.Cos(pos.x / valC + t);
        return pos * valD * (0.5f + Mathf.Sin(t * 0.1f) * 0.5f);
    }
    Material mat { get { if (_mat == null) _mat = new Material(Shader.Find("Unlit/Color")); _mat.color = Color.red; return _mat; } }
    Material _mat;
    void OnRenderObject()
    {
        mat.SetPass(0);
        GL.Begin(GL.LINES);
        var time = Time.time * speed;
        var dt = 0.2f * speed;
        for (var t = 0f; t < 10f; t += dt)
        {
            GL.Vertex(GetPosition(time + t));
            GL.Vertex(GetPosition(time + t + dt));
        }
        GL.End();
    }
}
