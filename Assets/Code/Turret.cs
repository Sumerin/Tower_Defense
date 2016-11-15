using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public GameObject bulletPrefab;
	Transform turret;
	Monster_AI enemy;

	float findEnemyIdleTime = 0.5f, findEnemyTimer = 0;
	float shootCooldown = 1f, shootCooldownTimer = 0;
	public float range = 150;

	// Use this for initialization
	void Start() {
		turret = transform.Find("Turret");
		findEnemy();
	}
	
	// Update is called once per frame
	void Update() {
		if (enemy == null) {
			findEnemyTimer += Time.deltaTime;
			if (findEnemyTimer >= findEnemyIdleTime) {
				findEnemyTimer = 0;
				findEnemy();
			}
		}
		if (enemy != null) {
			float dist = Vector3.Distance(this.transform.position, enemy.transform.position);
			if (dist <= range) {
				Quaternion dir = Quaternion.LookRotation(enemy.transform.position - this.transform.position);
				turret.localRotation = Quaternion.Euler(0, dir.eulerAngles.y, 0);
				shootCooldownTimer += Time.deltaTime;
				if (shootCooldownTimer >= shootCooldown) {
					shootCooldownTimer = 0;
					shoot();
				}
			} else
				enemy = null;
		}
	}

	void shoot() {
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
		bulletGO.transform.SetParent(this.transform);
		Bullet bullet = bulletGO.GetComponent<Bullet>();
		bullet.target = enemy.transform;
	}

	void findEnemy() {
		Monster_AI[] monsters = FindObjectsOfType<Monster_AI>();
		int nearest = -1;
		float distance = Mathf.Infinity;
		for (int i = 0; i < monsters.Length; i++) {
			float thisDist = Vector3.Distance(this.transform.position, monsters[i].transform.position);
			if (thisDist < distance && thisDist <= range) {
				nearest = i;
				distance = thisDist;
			}
		}
		if (nearest >= 0) {
			enemy = monsters[nearest];
		}
	}

}
