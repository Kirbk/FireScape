using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ablaze : MonoBehaviour
{
    /*
     * Global TODOs:
     * Random fire locations
     * Start fire strengths low and grow as time passes 
     */

    [SerializeField] private GameObject m_fireObject;
    [Tooltip("DO NOT ADD MORE FIRE THAN LOCATIONS, IT WILL FREEZE!")] [SerializeField] private int m_spawnAmount;
    [SerializeField] private int m_startingIntensity;

    void spawnFire(Vector3 position)
    {
        GameObject clone;
        clone = (GameObject) Instantiate(m_fireObject, position, m_fireObject.transform.rotation);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 range = transform.localScale / 2.0f;
        List<Vector3> used = new List<Vector3>();
        int area = (int) (transform.localScale.x * transform.localScale.y) - 1;

        for (int i = 0; i < ((area < m_spawnAmount) ? (area) : (m_spawnAmount)); i++)
        {
            Vector3 position;
            while (true)
            {
                position = new Vector3((float)((int)Random.Range(-range.x, range.x)) + 0.5f,
                                       (float)((int)Random.Range(-range.y, range.y)) + 0.5f,
                                       0);
                if (!used.Contains(position))
                {
                    used.Add(position);
                    break;
                }
            }
            spawnFire(position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
