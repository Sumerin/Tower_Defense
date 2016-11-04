using UnityEngine;
using System.Collections;


public class Monster : MonoBehaviour {

	public float hp;
	private GameObject Glass;
	private GameObject Body;
	private GameObject hands_pivot;
	private GameObject Monster_pivot;
	private float angel=20.0F;
	private float rotation=0.5F;


	// Use this for initialization
	void Start () {
		//Glass = transform.Find ("Glass").gameObject;
		//Body = transform.Find ("Body").gameObject;
		hands_pivot = transform.Find ("Hands_pivot").gameObject;
		Monster_pivot= transform.parent.gameObject;

	}
	
	// Update is called once per frame
	void Update () {

		if (Monster_pivot.transform.eulerAngles.z > angel && Monster_pivot.transform.eulerAngles.z < 360-angel ) {
			rotation=-rotation;
		}

		Monster_pivot.transform.Rotate (0, rotation, rotation);
		hands_pivot.transform.Rotate (-rotation*2, 0, 0);
		//Monster_pivot.transform.Translate(new Vector3(0,0,1)*Time.deltaTime,Space.World);

	}

}
