using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickUI : MonoBehaviour
{
    #region Singleton
    public static ClickUI instance;
    void Awake(){
        instance = this;
    }
    #endregion
    
    public GameObject click;
    BoxCollider2D col;
    
    Vector3 clickSpawn;
    
    void Start() {
        col = this.transform.GetComponent<BoxCollider2D>();
    }
    
    public void ClickAppear(){
        clickSpawn = ChooseSpawn();
        Instantiate(click, clickSpawn, Quaternion.identity);
    }
    
    Vector3 ChooseSpawn(){
        Vector3 spawn =
        new Vector3((Random.Range(col.bounds.min.x, col.bounds.max.x)),
                    (Random.Range(col.bounds.min.y, col.bounds.max.y)),
                    (this.transform.position.z));
        return spawn;
    }
}
