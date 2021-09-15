using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool{

        public string tag;
        public GameObject prefab;
        public int sizeOfPool;
        public int weight;
        
        [HideInInspector]
        public int rangeMin;
        [HideInInspector]
        public int rangeMax;
    }
    
    public static ObjectPooler instance;
    
    void Awake(){
        instance = this;
        poolDictionary = new Dictionary<string, List<GameObject>>();
        
        FillDictionary();
        SetChunkWeights();
    }
    
    public List<Pool> poolList;
    public Dictionary<string, List<GameObject>> poolDictionary;
    
    [HideInInspector]
    public int accumSum = 1;

    public GameObject SpawnFromPool(string tag) {
        
        if(poolDictionary == null) {
            Debug.LogWarning("pool dictionary is null");
        }

        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = new GameObject();

        foreach (GameObject chunk in poolDictionary[tag]) {
            if (!chunk.activeInHierarchy) {
                objectToSpawn = chunk;
            }
        }

        if(!objectToSpawn.activeInHierarchy){
            objectToSpawn.SetActive(true);
            return objectToSpawn;
        }
        
        return null;
    }
    
    void FillDictionary(){
        
        foreach (Pool pool in poolList){
            List<GameObject> objectPool = new List<GameObject>();

            for (int i = 0; i < pool.sizeOfPool; i++){
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Add(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    
    public void SetChunkWeights(){
        
        for(int i = 0; i < poolList.Count; i++){
            poolList[i].rangeMin = accumSum;
            accumSum += poolList[i].weight;
            poolList[i].rangeMax = accumSum;
        }
    }
}
