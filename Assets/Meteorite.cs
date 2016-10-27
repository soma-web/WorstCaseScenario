using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Meteorite : MonoBehaviour {

    public GameObject _plane;
    public float _speed;

	void Awake()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] verts = mesh.vertices;
        for(int i=0; i<verts.Length; i++)
        {
            verts[i] *= Random.Range(0.9f, 1.1f);
        }
        mesh.SetVertices(new List<Vector3>(verts));
    }

    void Update()
    {
        transform.LookAt(_plane.transform);
        transform.position += transform.forward * _speed;
    }

  
}
