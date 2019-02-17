using UnityEngine;


[RequireComponent(typeof(MissileLauncher), typeof(Rigidbody2D))]
public class Player : Ship //Player1
{
    
    public AudioClip explosion;
    public AudioClip mlaunch;
    public AudioClip killscore;
    
	/// How fast we accelerate
	public float ThrustStrength = 5f;
	/// How fast we turn
	public float Torque = 1f;
    
    public float TorqueCounter = 0;
    
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
		
        if (Input.GetKey(KeyCode.UpArrow)){
			rigidBody.AddRelativeForce(new Vector2(ThrustStrength, 0));
        }
        else if (Input.GetKey(KeyCode.DownArrow)){
			rigidBody.AddRelativeForce(new Vector2(-ThrustStrength, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            //TorqueCounter++;
			rigidBody.AddTorque(Torque);
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            //TorqueCounter--;
            rigidBody.AddTorque(-Torque);
        }
        
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rigidBody.velocity = Vector3.zero;
        }
        
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rigidBody.velocity = Vector3.zero;
        }

	    else
	    {
            //rigidBody.AddTorque(-TorqueCounter*0.10f);
            //rigidBody.velocity = Vector3.zero;

            rigidBody.angularVelocity = 0f;
            

	        //return;
	    }
	}


    internal void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            GetComponent<MissileLauncher>().FireMissile();
            GetComponent<AudioSource>().PlayOneShot(mlaunch, 0.7F);
        }
        
        /*
        if (Input.GetKeyDown(KeyCode.Shift)){
            GetComponent<EMPLauncher>().FireEMP();
            GetComponent<AudioSource>().PlayOneShot(mlaunch, 0.7F);
        }*/
        
        var mainCamera = Camera.main;
        if (mainCamera)
        {
            var worldPosition = transform.position;
            var screenPosition = mainCamera.WorldToScreenPoint(worldPosition);
            var screenMax = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            var screenMin = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

            if (screenPosition.x < -2
                || screenPosition.y < -2
                || screenPosition.y > Screen.height + 2
                || screenPosition.x > Screen.width + 2)
            {
                FindObjectOfType<ScoreKeeper>().P2ScoreIncrease(); //P2 wins

                //Destroy(gameObject); //destroy Player1 

            }

        }
    }
}
