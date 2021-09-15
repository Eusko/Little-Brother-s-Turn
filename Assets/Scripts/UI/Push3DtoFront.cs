using UnityEngine;
using System.Collections;

public class Push3DtoFront : MonoBehaviour 
{
    public string layerToPushTo;

	void Start () 
    {
        GetComponent<Renderer>().sortingLayerName = layerToPushTo;
	}
}