using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	Transform turret;
	Monster_AI enemy;
	float findEnemyIdleTime = 0.5f, findEnemyTimer = 0;
	float range = 150;

	// Use this for initialization
	void Start () {
		turret = transform.Find ("Turret");
		findEnemy();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemy == null) {
			findEnemyTimer += Time.deltaTime;
			if(findEnemyTimer >= findEnemyIdleTime) {
				findEnemyTimer = 0;
				findEnemy ();
			}
		}
		if(enemy != null) {
			float dist = Vector3.Distance(this.transform.position, enemy.transform.position);
			if (dist <= range) {
				Quaternion dir = Quaternion.LookRotation(enemy.transform.position - this.transform.position);
				turret.rotation = Quaternion.Euler (0, dir.eulerAngles.y + 90, 0);
			} else
				enemy = null;
		}
	}

	void findEnemy() {
		Monster_AI[] monsters = FindObjectsOfType<Monster_AI>();
		int nearest = -1;
		float distance = Mathf.Infinity;
		for(int i = 0; i < monsters.Length; i++) {
			float thisDist = Vector3.Distance(this.transform.position, monsters[i].transform.position);
			if(thisDist < distance && thisDist <= range) {
				nearest = i;
				distance = thisDist;
			}
		}
		if(nearest >= 0) {
			enemy = monsters [nearest];
		}
	}

}
