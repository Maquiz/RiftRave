using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class particle_controller : MonoBehaviour {

	public Transform startpos;		//starting position
	public Transform target1;		//explosion point1 position
	public Transform target2;		//explosion point2 position
	public Transform target3;		//explosion point3 position
	public GameObject preftracer;	//prefab of a tracer
	public List<GameObject> PrefOfExpl = new List<GameObject>();	//list of prefabs for explosions
	public float speed=0.1f;		//tracer's speed
	public int rangeOfRandom=0;		//range of random explosion's expansion from target points. If = 0, then all the explosions will be in target points.
	GameObject tracer;				//object for instantiating tracer		
	float timeLerped = 0.0f;		//variables for lerp moving of a tracer
	float timeToLerp = 2; 			//lerp for two seconds.
    Vector3 startingPosition;		//temp variable for starting position
	private Vector3[] arrayOfTarget;	//array of a target points
	private GameObject[] arrayOfTracers;	//array of a tracers
	private GameObject[] arrayOfExplos;		//array of explosions
	private byte[] played;					//flag for knowing was the explosion completed
	bool flagOfTracers=false;				//flag for creating the tracer
	float timer=0;							//timer after explosion
	int currentexp;							//current type of explosion
	

   	void GenerTargets()
	{
		arrayOfTarget[0]=target1.transform.position;		//generating array of a target points
		arrayOfTarget[1]=target2.transform.position;
		arrayOfTarget[2]=target3.transform.position;	
		for (int i=0; i<=2; i++)							//randoming target positions with a rangeOfRandom variable
		{
		arrayOfTarget[i]=new Vector3(arrayOfTarget[i].x+Random.Range(-(rangeOfRandom),(rangeOfRandom)),arrayOfTarget[i].y+Random.Range((rangeOfRandom),(rangeOfRandom)),arrayOfTarget[i].z+Random.Range((rangeOfRandom),(rangeOfRandom)));	
		}
	}  
     
    void Start()
	{
		played=new byte[3];									
		arrayOfExplos=new GameObject[3];
		arrayOfTracers=new GameObject[3];
		arrayOfTarget=new Vector3[3];
    	startingPosition = startpos.position;
		GenerTargets();
			
		
   }
    
	
	void Update()
	{
	if (flagOfTracers==false)
		{
		
		for (int i=0; i<=2;i++)			//creating 3 tracers for each of a firework in starting positions
			{
				arrayOfTracers[i] = Instantiate(preftracer,startpos.position,startpos.rotation) as GameObject;
				played[i]=1;
				flagOfTracers=true;
			}	
		}
		for (int j=0; j<=2; j++)
		{
			if (arrayOfTracers[j].transform.position.y<arrayOfTarget[j].y)							//if tracer didn't reach the target point (the y variable is the main) You can't move the firework from top point to low. Fireworks always raise up! :)
			{
				Vector3 relativePos = arrayOfTarget[j] - arrayOfTracers[j].transform.position;		//generating, rotating and moving tracer to target
			    Quaternion rotation = Quaternion.LookRotation(relativePos);
			    arrayOfTracers[j].transform.rotation = rotation;
				timeLerped += Time.deltaTime*speed;
			    arrayOfTracers[j].transform.position = Vector3.Lerp(startingPosition, arrayOfTarget[j], timeLerped / timeToLerp);  
			}
				else 		//if tracers reached the point
				{
						arrayOfTracers[j].particleSystem.Stop();		//stop emitting tracer's particles
						if (played[j]==1)								//instantiating explosion only 1 time
						{
							arrayOfExplos[j] = (GameObject)Instantiate(PrefOfExpl[currentexp],arrayOfTarget[j],target1.rotation);
							played[j]=0;
					 	}
				}
		}
		if (played[2]==0)			//if all the explosions were made (there are 0,1 and 2nd explosions)
		{
		timer+=Time.deltaTime;		//start to count the timer
			if (timer>=4)
			{
			startingPosition=startpos.position;				//all the variables to the starting values
			for (int k=0;k<=2;k++)
			{
				arrayOfTracers[k].transform.position=startpos.position;		
				arrayOfTracers[k].particleSystem.Play();
				played[k]=1;
				Destroy(arrayOfExplos[k]);					//destroing emitted explosion particles
				
			}
			timeLerped = 0.0f;
			timeToLerp = 2;	
			timer=0;
			GenerTargets();
			currentexp+=1;
			if (currentexp==PrefOfExpl.Count)
				{
				currentexp=0;
				}
			}
		}
		
				
	}
}
