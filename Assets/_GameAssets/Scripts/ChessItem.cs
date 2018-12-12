using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessItem : MonoBehaviour {

    public bool abrirCofre;
    [SerializeField] GameObject Item;
    [SerializeField] GameObject GenItem;

    private BoxCollider bc;
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();
    }

    void Update() {
        anim.SetBool("AbrirCofre", abrirCofre);
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Player") {
            abrirCofre = true;
            destruirItem();
            Destroy(this.bc);
        }
    }

    void destruirItem() {
        if (gameObject.name == "Item") {
            transform.position = Item.transform.position - Vector3.up * 10f;
            Destroy(this.gameObject, 0.7f);
        }
    }
}
