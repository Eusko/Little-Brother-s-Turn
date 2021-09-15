using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public List<Pool> poolList = new List<Pool>();
    [HideInInspector]
    public int accumSum = 1;
    
    [System.Serializable]
    public class Pool{
        public string prefabName;
        public GameObject prefab;
        public int pooledAmount;
        public int weight;
        [HideInInspector]
        public List<GameObject> pooledObjs = new List<GameObject>();
        [HideInInspector]
        public int rangeMin;
        [HideInInspector]
        public int rangeMax;
    }
    
    public static Pooler instance;
    void Awake(){
        instance = this;
        Init();
        SetChunkWeights();
    }
    
    void Init(){
        foreach(Pool pool in poolList){
            for(int i = 0; i < pool.pooledAmount; i++){
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                pool.pooledObjs.Add(obj);
            }
        }
    }
    
    public GameObject GetObj(string name){
        foreach(Pool pool in poolList){
            if(name == pool.prefabName){
                foreach(GameObject obj in pool.pooledObjs){
                    if(!obj.activeInHierarchy){
                        return obj;
                    }
                }
                GameObject newObj = Instantiate(pool.prefab);
                pool.pooledObjs.Add(newObj);
                return newObj;
            }
        }
        return null;
    }
    
    // for setting the probability for each chunk spawning, 
    // there's probably a better way but this way works
    public void SetChunkWeights() {
        
        for(int i = 0; i < poolList.Count; i++){
            poolList[i].rangeMin = accumSum;
            accumSum += poolList[i].weight;
            poolList[i].rangeMax = accumSum;
        }
    }
    
}
