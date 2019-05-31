using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private double m_likelihoodToSpread = 0.5;
    [SerializeField] private float m_spreadInterval = 2;
    [SerializeField] private bool m_randomize = false;
    private List<GameObject> neighbors;

    // Start is called before the first frame update
    void Start()
    {
        neighbors = new List<GameObject>();
        int layerMask = 1 << 8;

        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, 1f, layerMask);
        if (left)
        {
            Debug.Log("ASDF");
        }
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
