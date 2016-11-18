using UnityEngine;
using System.Collections;

public class mouse : MonoBehaviour {

    public GameObject Pturret;

    private RaycastHit Hit;
    private Ray ray;




    void BuildTurret()
    {
        if (GameManager.instance.money >= 20)
        {
            GameManager.instance.money = -20;
            Instantiate(Pturret, Hit.point, Pturret.transform.rotation, GameObject.FindGameObjectWithTag("Turrets").transform);
        }
    }
    
    
    // Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}


	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);// działa tylko przy wyłaczonej 1 kamerze
            
            if (Physics.Raycast(ray,out Hit))
                if (Hit.transform.tag == "Stand")
                {
                    BuildTurret();
                   
                }
        }
	
	}
}
