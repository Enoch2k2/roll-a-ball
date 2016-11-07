using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	private int count;

	public Text countText;
	public Text winText;
	public int speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		updateCounter ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 addMovement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (addMovement * speed);
	}

	void OnTriggerEnter(Collider other) {
		count = count + 1;
		updateCounter ();
		other.gameObject.SetActive(false);
	}

	void updateCounter()
	{
		countText.text = "Count: " + count;
		if (count >= 12) 
		{
			winText.text = "YOU WIN!";
		}
	}
}
