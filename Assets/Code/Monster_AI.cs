using UnityEngine;
using System.Collections;

public class Monster_AI : MonoBehaviour {


    public float Speed = 40.0F;

    private GameObject Path;
    private Transform nxt_Node;
    private Vector3 kurs;
    private int node_number;
	

    #region Function

    void find_nxt_node()
    {
        nxt_Node = null;
        nxt_Node = Path.transform.GetChild(node_number);
        node_number++;
        if(nxt_Node==null)//to nie dziala
        {
            Debug.Log("czy to zadziała?");
            endOfWay();
        }

        kurs = nxt_Node.transform.position - this.transform.position;


        float magni = Speed/kurs.magnitude;//regulowanie dlugosci vektora na 40
        kurs= Vector3.Scale(kurs,new Vector3(magni,magni,magni));


        this.transform.rotation = Quaternion.LookRotation(kurs);
       

    }

    void endOfWay()
    {
        Debug.Log("Koniec sciezki");
        Destroy(gameObject);
        //TODO: co sie dzieje po dojsciu do końca. 
    }

    #region BIN
    bool around_node()
    {
        Vector3[] tolerence=new Vector3[2];
        tolerence[0]=nxt_Node.position-new Vector3(5,5,5);
        tolerence[1]=nxt_Node.position+new Vector3(5,5,5);
        if(
            this.transform.position.x>tolerence[0].x && this.transform.position.y>tolerence[0].y && this.transform.position.z>tolerence[0].z &&this.transform.position.x<tolerence[1].x &&this.transform.position.y<tolerence[1].y &&this.transform.position.z<tolerence[1].z
            )
        {
            return true;
        }
        return false;

    }
    #endregion




#endregion


    void Start () {

        Path = GameObject.Find("Path");
        node_number = 0;
        find_nxt_node();
	}
	
	void Update () {

        
        if( (nxt_Node.transform.position - this.transform.position).magnitude > kurs.magnitude*Time.deltaTime)
        {
            this.transform.Translate(kurs *Time.deltaTime, Space.World);
            
        }
        else
        {
            find_nxt_node();
        }
	}
}
