using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (Character2D))]
public class UserControl : MonoBehaviour {

	private Character2D m_Character;
	private bool m_fire;

	// Use this for initialization
	void Awake () {
		m_Character = GetComponent<Character2D>();
	}

	void Update () {
		if (!m_fire) {
			m_fire = Input.GetMouseButton (0);
		}
	}

	void FixedUpdate () {
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		m_Character.move (h, v);
		if (m_fire) {
			m_Character.fire ();
			m_fire = false;
		}
	}
}
