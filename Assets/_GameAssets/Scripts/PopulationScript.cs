using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationScript : MonoBehaviour {

    public GameObject prefabArbol;
    public GameObject prefabRoca;

    public int numArboles;
    public int numRocas;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < numArboles; i++) {
            float x = Random.Range(-50, 50);
            float z = Random.Range(-50, 50);
            Instantiate(prefabArbol, new Vector3(x, 0, z), Quaternion.identity);
        }
        for (int i = 0; i < numRocas; i++) {
            float x = Random.Range(-50, 50);
            float z = Random.Range(-50, 50);
            Instantiate(prefabRoca, new Vector3(x, 0, z), Quaternion.identity);
        }
    }	
}
