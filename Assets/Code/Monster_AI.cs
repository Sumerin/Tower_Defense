using UnityEngine;
using System.Collections;

public class Monster_AI : MonoBehaviour {


	public float Speed = 40.0F;
	public float health = 3;

	private GameObject Path;
	private Transform nxt_Node;
	private Vector3 kurs;
	private int node_number;


	#region Function

	bool find_nxt_node() {
		nxt_Node = null;
		try {
			nxt_Node = Path.transform.GetChild(node_number);
		} catch (UnityException e) {// wyrzuca wyjatek jesli nie znaleziono kolejnej kropki
			Debug.Log("Catch: " + e);
			endOfWay();
			return false;
		}
		node_number++;

		return true;

	}



	void SetMvDirection() {
		kurs = nxt_Node.transform.position - this.transform.position;

		float magni = Speed / kurs.magnitude;//regulowanie dlugosci vektora na 40
		kurs = Vector3.Scale(kurs, new Vector3(magni, magni, magni));
		//this.transform.rotation = Quaternion.LookRotation(kurs);
	}



	public void doDamage(float damage = 1) {
		health -= damage;
		if (health <= 0) {
			Debug.Log("Killed");
            GameManager.instance.score = 20;
            GameManager.instance.money = 20;
			Destroy(gameObject);
		}
	}

	void endOfWay() {
		Debug.Log("Koniec sciezki");
        GameManager.instance.health = -10;//odejmowanie zycia
		Destroy(gameObject);
		//TODO: co sie dzieje po dojsciu do końca. 
	}

	#region BIN

	bool around_node() {
		Vector3[] tolerence = new Vector3[2];
		tolerence[0] = nxt_Node.position - new Vector3(5, 5, 5);
		tolerence[1] = nxt_Node.position + new Vector3(5, 5, 5);
		if (this.transform.position.x > tolerence[0].x && this.transform.position.y > tolerence[0].y && this.transform.position.z > tolerence[0].z
		         && this.transform.position.x < tolerence[1].x && this.transform.position.y < tolerence[1].y && this.transform.position.z < tolerence[1].z) {
			return true;
		}
		return false;

	}

	#endregion




	#endregion


	void Start() {

		Path = GameObject.Find("Path");
		node_number = 0;
		find_nxt_node();
		SetMvDirection();
	}

	void Update() {

		Vector3 direction = nxt_Node.transform.position - this.transform.position;// sprawdza ile jeszcze zostalo do przebycia
        
		if (direction.magnitude >= kurs.magnitude * Time.deltaTime) {
			this.transform.Translate(kurs * Time.deltaTime, Space.World);// przesuwamy sie panowie
            
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(kurs), Time.deltaTime * 4);
		} else {
			if (find_nxt_node()) {
				SetMvDirection();
			}
		}
	}

}
