using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trajectory : MonoBehaviour
{
	// TrajectoryPoint and Ball will be instantiated
	public GameObject TrajectoryPointPrefeb;
	public GameObject BallPrefb;
	private GameObject character;
	
	private GameObject ball;
	private bool isPressed, isBallThrown;
	private float power = 5;
	private int numOfTrajectoryPoints = 30;
	private List<GameObject> trajectoryPoints;
	private Vector3 tempMousePos;
	//---------------------------------------    
	void Start ()
	{
		trajectoryPoints = new List<GameObject>();
		character = Controller.instance.activeChar; //GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(character);
		isPressed = isBallThrown =false;
		//   TrajectoryPoints are instatiated
		for(int i=0;i<numOfTrajectoryPoints;i++)
		{
			GameObject dot= (GameObject) Instantiate(TrajectoryPointPrefeb);
			dot.GetComponent<Renderer>().enabled = false;
			trajectoryPoints.Insert(i,dot);
		}
	}
	//---------------------------------------    
	void Update ()
	{
		if(isBallThrown)
			return;
		if(Input.GetMouseButtonDown(0))
		{
			isPressed = true;
			if(!ball)
				createBall();
		}
		else if(Input.GetMouseButtonUp(0) && isPressed)
		{
			isPressed = false;
			if(!isBallThrown)
			{
				tempMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				character = Controller.instance.activeChar;
				character.SendMessage("AnimateThrow");
				for (int i = 0; i < numOfTrajectoryPoints; i++) {
					Destroy (trajectoryPoints [i]);
				}
				//throwBall();
			}
		}
		// when mouse button is pressed, cannon is rotated as per mouse movement and projectile trajectory path is displayed.
		if(isPressed)
		{
			Vector3 vel = GetForceFrom(ball.transform.position,Camera.main.ScreenToWorldPoint(Input.mousePosition));
			float angle = Mathf.Atan2(vel.y,vel.x)* Mathf.Rad2Deg;

			transform.eulerAngles = new Vector3(0,0,angle);
			setTrajectoryPoints(transform.position, vel/ball.GetComponent<Rigidbody2D>().mass);
		}
	}
	//---------------------------------------    
	// Following method creates new ball
	//---------------------------------------    
	private void createBall()
	{
		ball = (GameObject) Instantiate(BallPrefb);
		Vector3 pos = transform.position;
		pos.z=1;
		ball.transform.position = pos;
		ball.SetActive(false);
	}
	//---------------------------------------    
	// Following method gives force to the ball
	//---------------------------------------    
	public void throwBall()
	{
		ball.SetActive(true);    
		//ball.GetComponent<Rigidbody2D>().useGravity = true;
		ball.GetComponent<Rigidbody2D>().AddForce(GetForceFrom(ball.transform.position,tempMousePos),ForceMode2D.Impulse);
		isBallThrown = true;
	}
	//---------------------------------------    
	// Following method returns force by calculating distance between given two points
	//---------------------------------------    
	private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
	{
		return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y))*power;
	}
	//---------------------------------------    
	// Following method displays projectile trajectory path. It takes two arguments, start position of object(ball) and initial velocity of object(ball).
	//---------------------------------------    
	void setTrajectoryPoints(Vector3 pStartPosition , Vector3 pVelocity )
	{
		float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
		float angle = Mathf.Rad2Deg*(Mathf.Atan2(pVelocity.y , pVelocity.x));
		float fTime = 0;
		//angle = Mathf.Clamp(angle, 10, 80);
		fTime += 0.05f; //IMPORTANT

		//Reverse Points #Teja
		float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
		float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
		//Vector3 pos = new Vector3(pStartPosition.x - dx , pStartPosition.y - dy ,2);
		//trajectoryPoints[0].transform.position = pos;
		//trajectoryPoints[0].GetComponent<Renderer>().enabled = true;
		//trajectoryPoints[0].transform.eulerAngles = new Vector3(0,0,Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude)*fTime,pVelocity.x)*Mathf.Rad2Deg);
		//fTime += 0.1f;
		Vector3 pos = new Vector3(pStartPosition.x , pStartPosition.y ,2);
		trajectoryPoints[1].transform.position = pos;
		trajectoryPoints[1].GetComponent<Renderer>().enabled = true;
		trajectoryPoints[1].transform.eulerAngles = new Vector3(0,0,Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude)*fTime,pVelocity.x)*Mathf.Rad2Deg);

		for (int i = 1 ; i < numOfTrajectoryPoints-1 ; i++)
		{
			dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
			dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
			pos = new Vector3(pStartPosition.x + dx , pStartPosition.y + dy ,2);
			trajectoryPoints[i].transform.position = pos;
			trajectoryPoints[i].GetComponent<Renderer>().enabled = true;
			trajectoryPoints[i].transform.eulerAngles = new Vector3(0,0,Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude)*fTime,pVelocity.x)*Mathf.Rad2Deg);
			fTime += 0.05f;
		}
	}
}