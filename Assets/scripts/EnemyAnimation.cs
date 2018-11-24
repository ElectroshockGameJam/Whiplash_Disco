using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour {

    public Animator enemy_animator;
    [HideInInspector] public Transform player;

	// Use this for initialization
	void Start () {
		
	}

    void Update(){
        Vector3 direction = player.position - transform.position;
        if( direction.z > 0 ){
            enemy_animator.SetInteger("move", 2);
        }
        else {
            if( direction.x > 0 ){
                enemy_animator.SetInteger("move", 1);
                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            } 
            else{
                if ( direction.x < 0 ){
                    enemy_animator.SetInteger("move", 1);
                    transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate(){
		//Debug.Log( transform.InverseTransformDirection( GetComponent<Rigidbody>().velocity ));
        //Debug.Log( transform.InverseTransformDirection( GetComponent<NavMeshAgent>().velocity) );
	}

}
