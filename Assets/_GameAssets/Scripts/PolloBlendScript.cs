using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolloBlendScript : MonoBehaviour {

    Animator miAnimator;
    float corriendo = 0.1f;
    float haciaAtras = -0.1f;
    //float girarQuieto = 0.5f;
    //bool andando = false;

    int puntos = 0;
    float vidas = 3;
    float energia = 100;
    public Text textScore;
    public Text textVida;

    void Start() {
        miAnimator = GetComponent<Animator>();
    }

    void Update() {
        textScore.text = "Score: " + puntos.ToString();
        /*float x = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            miAnimator.SetBool("Andando", true);
            andando = true;
        } else if (Input.GetKeyUp(KeyCode.UpArrow)) {
            miAnimator.SetBool("Andando", false);
            andando = false;
        }
        if (andando) {
            transform.Rotate(0, x, 0);
        }*/

if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftShift)) {
            //Anda (si está corriendo decrece la velocidad)
            corriendo = corriendo - 0.05f;
            corriendo = Mathf.Max(0.11f, corriendo);
            miAnimator.SetFloat("Corriendo", corriendo);
        } else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift)) {
            //¡¡¡Corre gusano, CORREEEE!!!
            corriendo = corriendo + 0.05f;
            corriendo = Mathf.Min(1, corriendo);
            miAnimator.SetFloat("Corriendo", corriendo);
        } else if (!Input.GetKey(KeyCode.UpArrow)) {
            //Se para despacito
            corriendo = corriendo - 0.05f;
            corriendo = Mathf.Max(0f, corriendo);
            miAnimator.SetFloat("Corriendo", corriendo);
        }
        //HACIA ATRAS
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftShift)) {
            //Anda (si está corriendo decrece la velocidad)
            haciaAtras = haciaAtras - 0.05f;
            haciaAtras = Mathf.Max(0.11f, haciaAtras);
            miAnimator.SetFloat("HaciaAtras", haciaAtras);
        } else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift)) {
            //¡¡¡Corre gusano, CORREEEE!!!
            haciaAtras = haciaAtras + 0.05f;
            haciaAtras = Mathf.Min(1, haciaAtras);
            miAnimator.SetFloat("HaciaAtras", haciaAtras);
        } else if (!Input.GetKey(KeyCode.DownArrow)) {
            //Se para despacito
            haciaAtras = haciaAtras - 0.05f;
            haciaAtras = Mathf.Max(0f, haciaAtras);
            miAnimator.SetFloat("HaciaAtras", haciaAtras);
        }
        // FIN DE HACIA ATRAS

        if (corriendo > 0.1f) {
            miAnimator.SetBool("Girando", false);
            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        } else {
            float x = Input.GetAxis("Horizontal");
            if (Mathf.Abs(x) > 0.1) {
                miAnimator.SetBool("Girando", true);
                miAnimator.SetFloat("GirarQuieto", x);
            } else {
                miAnimator.SetBool("Girando", false);
            }
        }
        if (haciaAtras > 0.1f) {
            miAnimator.SetBool("Girando", false);
            transform.Rotate(0, -Input.GetAxis("Horizontal"), 0);
        } else {
            float x = Input.GetAxis("Horizontal");
            if (Mathf.Abs(x) > 0.1) {
                miAnimator.SetBool("Girando", true);
                miAnimator.SetFloat("GirarQuieto", x);
            } else {
                miAnimator.SetBool("Girando", false);
            }
        }
    }
}
