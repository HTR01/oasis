using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMiniMap : MonoBehaviour
{
    public GameObject fogPlane;
    public Transform Player;
    public LayerMask fogLayer;
    public float radius = 5f;
    public float radiusSqr { get { return radius * radius;  } }

    Mesh mesh;
    Vector3[] verts;
    Color[] colours;


    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, Player.position - transform.position);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit, 1000, fogLayer, QueryTriggerInteraction.Collide))
        {
            for (int i=0; i< verts.Length; i++)
            {
                Vector3 v = fogPlane.transform.TransformPoint(verts[i]);
                float dist = Vector3.SqrMagnitude(v - hit.point);
                if (dist < radiusSqr)
                {
                    float alpha = Mathf.Min(colours[i].a, dist / radiusSqr);
                    colours[i].a = alpha;
                }
            }
            UpdateColour();
        }
    }

    void Setup()
    {
        mesh = fogPlane.GetComponent<MeshFilter>().mesh;
        verts = mesh.vertices;
        colours = new Color[verts.Length];
        for (int i = 0; i < colours.Length; i++)
        {
            colours[i] = Color.black;
        }
        UpdateColour();
    }

    void UpdateColour()
    {
        mesh.colors = colours;
    }

}
