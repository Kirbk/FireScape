using UnityEngine;
using System.Collections;

public class Fizzle : MonoBehaviour {

	[Range(0, 10)] [SerializeField] private float m_StartingStrength = 5.0f;
	[Range(0, 10)] [SerializeField] private float m_RechargeDelay = 5.0f;
	[Range(0, 1)] [SerializeField] private float m_RechargeRate = 0.5f;
	[SerializeField] private Light m_Light;

	private bool m_doused = false;
	private float m_strength;
	private float m_startingIntensity;
	private float m_rechargeTimer;

	// Use this for initialization
	void Awake () {
		m_strength = m_StartingStrength;
		m_startingIntensity = m_Light.intensity;
		m_rechargeTimer = m_RechargeDelay;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (m_doused) {
			m_rechargeTimer = m_RechargeDelay;
			m_doused = false;
		} else if (m_strength < m_StartingStrength) {
			m_rechargeTimer -= 0.02f;

			if (m_rechargeTimer < 0) {
				m_strength += m_RechargeRate;
			}
		}

	}

	void Update() {
		if (m_strength <= 0) {
			Destroy (gameObject);
		}

		m_Light.intensity = m_strength * 3.0f; 
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Water")) {
			Destroy (col.gameObject);
			m_doused = true;
			m_strength -= 0.002f;

		}
	}
}
