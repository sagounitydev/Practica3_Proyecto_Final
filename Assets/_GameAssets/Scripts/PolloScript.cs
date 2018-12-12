using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolloScript : MonoBehaviour {

    private Animator miAnimator;
    	
	void Start () {
        miAnimator = GetComponent<Animator>();
	}
	
    //Version con Bool
	void Update () {
        float y = Input.GetAxis("Vertical");
        miAnimator.SetFloat("Corriendo", y);
        if (Input.GetKeyDown(KeyCode.I)) {
            miAnimator.SetBool("EstaAndando", true);
        } else if (Input.GetKeyDown(KeyCode.K)) {
            miAnimator.SetBool("EstaAndando", false);
        }        
        if (Input.GetKeyDown(KeyCode.Space)) {
            miAnimator.SetTrigger("Punch");
        }
	}
    public void ReproducirSonidoPisada() {
        print("ESTA SONANDO UNA PISADA");
    }
}
