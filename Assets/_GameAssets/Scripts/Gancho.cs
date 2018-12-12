using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gancho : MonoBehaviour {

    public float velLanzamiento;
    public float tamanoCuerda;
    public float fuerzaCuerda;
    public float peso;

    private GameObject player;
    private Rigidbody cuerpoRigido;
    private SpringJoint efectoCuerda;

    private float distaciaPlayer;

    private bool hasTiradoCuerda;
    public static bool haEnganchado;
    
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cuerpoRigido = GetComponent<Rigidbody>();
        efectoCuerda = player.GetComponent<SpringJoint>();

        hasTiradoCuerda = true;
        haEnganchado = false;
	}
	
	// Update is called once per frame
	void Update () {

        distaciaPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (Input.GetMouseButtonDown(0)) {
            hasTiradoCuerda = false;
        }

        if (hasTiradoCuerda) {
            //Lanza la cuerda
            hasTiradoGancho();
        } else {
            //recoge la cuerda
            hasRecogidoGancho();
            //Linea Cuerda
            GetComponent<LineRenderer>().SetPosition(0, player.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position);
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.tag != "Player") {
            haEnganchado = true;
        }
    }

    public void hasTiradoGancho() {
        if(distaciaPlayer <= tamanoCuerda) {
            if (!haEnganchado) {
                transform.Translate(0, 0, velLanzamiento * Time.deltaTime);
            } else {
                efectoCuerda.connectedBody = cuerpoRigido;
                efectoCuerda.spring = fuerzaCuerda;
                efectoCuerda.damper = peso;
            }
        }
        if(distaciaPlayer > tamanoCuerda) {
            hasTiradoCuerda = false;
        }
    }

    public void hasRecogidoGancho() {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 25 * Time.deltaTime);
        haEnganchado = false;


    if(distaciaPlayer <= 2) {
            Destroy(gameObject);
        }
    }

}
