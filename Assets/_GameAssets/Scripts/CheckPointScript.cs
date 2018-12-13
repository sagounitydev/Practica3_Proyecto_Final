using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    public bool Activated = false;
    //Listado de CheckPoints en la escena
    public static GameObject[] CheckPointsList;

    [SerializeField] protected ParticleSystem psCheck;
    [SerializeField] Transform posGenPS;

    private Animator thisAnimator;

    public static Vector3 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector3 result = new Vector3(0, 0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckPointScript>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }

        return result;
    }

    private void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPointScript>().Activated = false;
            cp.GetComponent<Animator>().SetBool("CheckActive", false);
        }

        // We activated the current checkpoint
        Activated = true;
        thisAnimator.SetBool("CheckActive", true);
    }

    void Start()
    {
        thisAnimator = GetComponent<Animator>();

        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint");
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            ActivateCheckPoint();
            ParticleSystem ps = Instantiate(psCheck, posGenPS.position, Quaternion.identity);
            ps.Play();
            Destroy(ps, 1.4f);
        }
    }
}
