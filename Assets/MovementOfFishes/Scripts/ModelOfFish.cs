using UnityEngine;
using System.Collections;
using System.Linq;

public class ModelOfFish : MonoBehaviour
{
    static Mesh FishMesh
    {
        get
        {
            if (_mesh == null)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                _mesh = Instantiate(go.GetComponent<MeshFilter>().sharedMesh);
                var vertices = _mesh.vertices;
                var vList = vertices.Select(v =>
                {
                    v.x *= 0.6f - v.z;
                    v.y *= 0.5f * (0.6f - v.z);
                    return v;
                }).ToList();
                _mesh.SetVertices(vList);
                _mesh.name = "fish";
                _mesh.hideFlags = HideFlags.HideAndDontSave;
                Destroy(go);
            }
            return _mesh;
        }
    }
    static Mesh _mesh;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>().sharedMesh = FishMesh;
        var mat = gameObject.AddComponent<MeshRenderer>().material;
        var trail = gameObject.AddComponent<TrailRenderer>();
        trail.time = 1f;
        trail.startWidth = 0.1f;
        trail.endWidth = 0f;
        trail.material = mat;

        mat.color = Color.blue;
    }
}
