using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    #region regulacja
    public double timeToNextWave;
    public double timeBeetwenSpawn;
    public int monsterPerSpawn;



    public GameObject monster;
    #endregion

    #region Private_variable
    private int _monsterPerSpawn;
    private double _timeLeftToWave;
    private double _timePastSinceLastSpawn;
    #endregion

    #region Get_Set

    public double timeLeftToWave //TODO: GUI
    {
        get
        {
            return _timeLeftToWave;
        }
    }

    public int monsterSpawn// Event np spawn wiekszej ilosci mobów
    {
        set
        {
            monsterPerSpawn = value;
        }

    }

    #endregion


    #region Funkcje

    void spawn(GameObject mob) // Spawnuje Moba +++ reguluje ilosc mobów na fale +++ mozliwosc fal mieszanych
    {
        if (_monsterPerSpawn-- > 0)
        {
            Instantiate(monster, this.transform.position, this.transform.rotation, this.transform);
        }
    }

    void reset()
    {
        _monsterPerSpawn = monsterPerSpawn;
        _timeLeftToWave = timeToNextWave;

    }
    #endregion







    // Use this for initialization
	void Start () {

        _timeLeftToWave = timeToNextWave;
	}
	
	// Update is called once per frame
	void Update () {

        _timePastSinceLastSpawn += Time.deltaTime;
        _timeLeftToWave -= Time.deltaTime;

        if(_timePastSinceLastSpawn>=timeBeetwenSpawn)
        {
            spawn(monster);
            _timePastSinceLastSpawn = 0;
        }
        if (_timeLeftToWave <= 0)
        {
            reset();
        }
	}

    
}
