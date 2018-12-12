using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirolina : MonoBehaviour {

    public GameObject gancho;
    private GameObject punteroMouse;

    public Camera m_camera;

    public Transform dirGancho;
    private Transform dirPunteroGancho;

    private Vector3 sitioDondeClickas;
    private Vector3 posMouse;
    private Quaternion mirarAlGancho;

    private void Update() {
        posMouse = Input.mousePosition;
        posMouse.z = Vector3.Distance(m_camera.transform.position, transform.position);
        posMouse = m_camera.ScreenToWorldPoint(posMouse);

        if(punteroMouse == null) {
            if (Input.GetMouseButtonDown(0)) {
                dirPunteroGancho = Instantiate(dirGancho, posMouse, Quaternion.identity) as Transform;
                sitioDondeClickas = (dirPunteroGancho.transform.position - transform.position).normalized;
                mirarAlGancho = Quaternion.LookRotation(sitioDondeClickas);

                punteroMouse = Instantiate(gancho, transform.position, mirarAlGancho) as GameObject;
                Destroy(dirPunteroGancho.gameObject);
            }
        }
    }


}
