using UnityEngine;
using System.Collections;

public class Character2D : MonoBehaviour {

	[SerializeField] private float m_MaxSpeed = 10.0f; 	// Max speed of the character

	[SerializeField] GameObject waterProjectile;

	// private Animator m_Anim;            // Reference to the player's animator component.
	private Rigidbody2D m_Rigidbody2D;

	// Use this for initialization
	void Awake () {
		// m_Anim = GetComponent<Animator>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 5.23f;
		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;
		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
	}

	public void move (float horiz, float vert) {
		m_Rigidbody2D.velocity = new Vector2(horiz*m_MaxSpeed, vert*m_MaxSpeed);
	}

	public void fire () {
		for (int i = 0; i < 5; i++) {
			GameObject clone;
			clone = (GameObject) Instantiate (waterProjectile, transform.position, transform.rotation);
			clone.transform.Rotate(0, 0, Random.Range (-10.0f, 10.0f));
			clone.GetComponent<Rigidbody2D> ().velocity = clone.transform.TransformDirection (Vector3.right * 10);
			Vector3 temp = clone.GetComponent<Rigidbody2D> ().velocity;
			temp.x = clone.GetComponent<Rigidbody2D> ().velocity.x + GetComponent<Rigidbody2D> ().velocity.x;
			temp.y = clone.GetComponent<Rigidbody2D> ().velocity.y + GetComponent<Rigidbody2D> ().velocity.y;
			clone.GetComponent<Rigidbody2D> ().velocity = temp;
		}
	}
}
