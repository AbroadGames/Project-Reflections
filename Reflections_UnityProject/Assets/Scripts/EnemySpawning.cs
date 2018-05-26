using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    //varribles
    private float localScore;
    [SerializeField]private float respawnTime = 1.5f;

   
    
    [System.Serializable]
    public class Spawns
    {
        public string name;
        public GameObject spawnObj;
        public int spawnRarity;
        public int DistanceFromPlayer;
        public int DecayRate;
    }

    public List<Spawns> spawns = new List<Spawns>();
    public int spawnChance;

    void CalculateSpawn()
    {
        int calc_spawnChance = Random.Range(0, 101);

        if(calc_spawnChance > spawnChance)
        {
            return;
        }

        if (calc_spawnChance <= spawnChance)
        {
            int spawnWeight = 0;

            for(int i = 0; i < spawns.Count; i++)
            {
                spawnWeight += spawns[i].spawnRarity;
            }

            int randomValue = Random.Range(0, spawnWeight);

            for (int j = 0; j < spawns.Count; j++)
            {
                if(randomValue <= spawns[j].spawnRarity)
                {
                    Vector2 pos = Random.insideUnitCircle.normalized * spawns[j].DistanceFromPlayer;
                    GameObject Instance = Instantiate(spawns[j].spawnObj, pos, Quaternion.identity);
                    

                    if (spawns[j].DecayRate > 0)
                    {
                        Destroy(Instance, spawns[j].DecayRate);
                    }
                    return;
                }
                randomValue -= spawns[j].spawnRarity;
            }
        }
    }

    IEnumerator SpawnCoroutine()
    {
        while (GameManager.Instance.PlayerisDead == false)
        {
            
            CalculateSpawn();
            yield return new WaitForSeconds(respawnTime);
        }
        yield return null;
    }


    // Use this for initialization
    void Start ()
    {
  
        respawnTime = 1.5f;

        StartCoroutine(SpawnCoroutine());
    }

    

    // Update is called once per frame
    void Update ()
    {
        //Difficulty
        if (GameManager.Instance.PlayerisDead == false)
        {
            if (respawnTime > 0.4f)
            {
                respawnTime -= localScore / 10000 * Time.deltaTime;
            }
                 
            
        }
           
        localScore = GameManager.Instance.Score;
 

    }

    
   


  

}
