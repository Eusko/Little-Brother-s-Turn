 using UnityEngine;
 using System.Collections;
 
 public class DepthHandler : MonoBehaviour {
        public string SortingLayerName = "Default";
        public int SortingOrder = 0;

        void Awake () {
        GameEvents.instance.onRestartLevel += Sort;
        Sort();
        }       

void Sort() {
        gameObject.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
        gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
}
         
}