using UnityEngine;
using System.Collections;

public class SkeletonMovementScript : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	Rigidbody m_position;
	NavMeshAgent nav;               // Reference to the nav mesh agent.
	Animator anim; 

	bool death;
	int mAnimation;
	float distanceWithTarget;

	void Awake ()
	{
		m_position = GetComponent <Rigidbody> ();
		nav = GetComponent <NavMeshAgent> ();
		anim = GetComponent <Animator> ();

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		death = false;
		mAnimation = 0;
	}


	void Update ()
	{
		changeAnimation ();

		anim.SetInteger ("mAnimation" , mAnimation);
	}

	void changeAnimation()
	{
		if (!death) {
			distanceWithTarget = Vector3.Distance (player.position, m_position.position);

			if (distanceWithTarget < 20) {
				if (distanceWithTarget > 3) {
					mAnimation = 1;
					nav.SetDestination (player.position);
				} else {
					mAnimation = 2;
				}
			} else {
				mAnimation = 0;
			}
		} else
			mAnimation = 3;
	}
}