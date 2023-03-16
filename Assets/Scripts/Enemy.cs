using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    [SerializeField] private LayerMask player;

    protected override void Start() {
        maxHealth = 3;
        base.Start();
    }

    protected override void Update() {
        base.Update();

        //if (CanTakeDamage()) {
        //    if (Physics2D.OverlapArea(recieveDamageCheckP1.position, recieveDamageCheckP2.position, player)) {
        //        TakeDamage(1);
        //        Debug.Log("Enemy taking damage");
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //if(collision.layer)
    }

    void OnTriggerStay(Collider other) {
        if (other.TryGetComponent(out Player player)) {
            if (CanTakeDamage()) {
                TakeDamage(1);
            }
        }
    }
}
