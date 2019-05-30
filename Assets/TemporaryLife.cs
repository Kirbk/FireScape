using UnityEngine;
using System.Collections;

public class TemporaryLife : MonoBehaviour {

	[Range(0,25)] [SerializeField] private float m_lifeTime = 10.0f;

	void FixedUpdate () {
		m_lifeTime -= 0.02f;
		if (m_lifeTime <= 0.0f) {
			Destroy (this.gameObject);
		}
	}
}
