using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {
    
    public GameObject chunk;
    private float chunkWidth;

    // prevent infinite while loop crash
    int loopBreaker = 250;

    Vector3 spawnPoint;
    public Transform createTransform;
    public Transform initSpawn;
    
    string poolName;

    #region Singleton
    public static GroundGenerator instance;

    void Awake() {
        instance = this;
    }
    #endregion

    void Start() {
        Initialize();
        
        GameEvents.instance.onRestartLevel += Initialize;
    }

    void Update() {
        if(chunk.transform.position.x < createTransform.position.x) {
           SpawnGround();
        }
    }

    void SpawnGround() {
        spawnPoint = chunk.transform.GetChild(0).transform.position;
        
        do {
            ChooseName();
            chunk = Pooler.instance.GetObj(poolName);
            loopBreaker -= 1;
            if (loopBreaker < 0) {
                Debug.LogWarning("Infinite loop!");
                break;
            }
        } while(chunk == null);
        
        chunk.transform.position = spawnPoint;
        chunk.SetActive(true);
    }
    
    void ChooseName(){
        int randChunk = Random.Range(1, Pooler.instance.accumSum + 1);
        for(int i = 0; i < Pooler.instance.poolList.Count; i++){
            if(randChunk >= Pooler.instance.poolList[i].rangeMin && randChunk <= Pooler.instance.poolList[i].rangeMax){
                poolName = Pooler.instance.poolList[i].prefabName;
                break;
            }
        }
    }
    
    void Initialize() {
        spawnPoint = initSpawn.position;
        chunk = Pooler.instance.GetObj("chunk3");
        chunk.transform.position = spawnPoint;
        chunk.SetActive(true);
    }
    
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(spawnPoint, 0.5f);
    }
}
