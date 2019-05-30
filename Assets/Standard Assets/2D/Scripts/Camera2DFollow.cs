using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float lookAheadFactor = 3;

        // Use this for initialization
        private void Start()
        {
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            //float xMoveDelta = (target.position - m_LastTargetPosition).x;

            //bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            /*            if (updateLookAheadTarget)
                        {
                            m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
                        }
                        else
                        {
                            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
                        }*/

            /*            m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Camera.main.ScreenToWorldPoint(Input.mousePosition), Time.deltaTime * lookAheadSpeed);

                        Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
                        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

                       transform.position = newPos;

                        m_LastTargetPosition = target.position;*/

            Vector3 heading = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 temp;

            temp = Vector3.MoveTowards(target.position, heading, lookAheadFactor);
            temp.z = transform.position.z;

            transform.position = temp;
        }
    }
}
