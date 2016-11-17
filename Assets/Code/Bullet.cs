using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Transform target;

	public float speed = 150f;
	public float damage = 1f;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		if(target != null) {
			Vector3 dir = target.position - this.transform.position;
			float dist = speed * Time.deltaTime;
			if (dir.magnitude > dist) {
				transform.Translate(dir.normalized * dist, Space.World);
			} else {
				hitTarget();
			}
		} else {
			Destroy(gameObject);
		}

	}

	void hitTarget() {
		//Debug.Log("bullet destroy");
		target.gameObject.GetComponent<Monster_AI>().doDamage(damage);
		Destroy(gameObject);
	}

}
