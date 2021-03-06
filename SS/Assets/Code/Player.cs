using UnityEngine;


[RequireComponent(typeof(MissileLauncher), typeof(Rigidbody2D))]
public class Player : Ship //Player1
{
    public AudioClip explosion;
    public AudioClip mlaunch;
    public AudioClip killscore;
    
	/// How fast we accelerate
	public float ThrustStrength = 1;
	/// How fast we turn
	public float Torque = 1f;
    
	internal void FixedUpdate ()
	{

	    /*if (Input.GetKey(KeyCode.LeftArrow))
	        //rigidBody.velocity = rigidBody.velocity + new Vector2(-0.05f, 0);
	        rigidBody.AddTorque(Torque);
	    else if (Input.GetKey(KeyCode.RightArrow))
	        //rigidBody.velocity = rigidBody.velocity + new Vector2(0.05f, 0);
		    rigidBody.AddTorque(-Torque);
	    else if (Input.GetKey(KeyCode.UpArrow))
	        rigidBody.velocity = rigidBody.velocity + new Vector2(0, 0.05f);

	    else if (Input.GetKey(KeyCode.DownArrow))
	        rigidBody.velocity = rigidBody.velocity + new Vector2(0, -0.05f);*/
		
		if (Input.GetKey(KeyCode.UpArrow))
			rigidBody.AddRelativeForce(new Vector2(ThrustStrength, 0));
		if (Input.GetKey(KeyCode.DownArrow))
			rigidBody.AddRelativeForce(new Vector2(-ThrustStrength, 0));
		if (Input.GetKey(KeyCode.LeftArrow))
			rigidBody.AddTorque(Torque);
		else if (Input.GetKey(KeyCode.RightArrow))
			rigidBody.AddTorque(-Torque);
	

	    else
	    {
	        return;
	    }
	}


    internal void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            GetComponent<MissileLauncher>().FireMissile();
            GetComponent<AudioSource>().PlayOneShot(mlaunch, 0.7F);
        }
    }
}
