using UnityEngine;
using System.Collections;

public class ClickandDragScript : MonoBehaviour {
	//Programmer's Notes: Next step, use the edgecollider component to allow player to interact with the line!(you can ignore this timmy)
	
	/*Spawnable is a public object and as you can see its not linked to any real object within the script.
	Within the unity interface, when you attatch this script to a GameObject (Camera) it will allow you to assign
	Spawnable to any other GameObject hence the "public GameObject" (This stands true for any public variable) */
	public GameObject Spawnable;

	private GameObject lastSpawned; //tracks the last line we drew
	private Vector3 lastMousePos; // tracks the last place our line stopped
	private int vertexCount; // tracks the # of vertex

	void Start () 
	{
		//nothing yet!
	}

	void Update()
	{
		/*
		 * I need to clean up the Update function its bad practice to shove everything into it LOL
		 * WE SHOULD MAKE OTHER FUNCTIONS ILL FIX IT LATER NIGGGAHAHAAHAHA
		 */
		//Holds unity's vector for mouse position in mousePos
		Vector3 mousePos = Input.mousePosition;
		//Fixes the position based on the cameras veiw (NOT world position)
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		//Sets Z value to always be -2
		mousePos.z = -2;

		//When left click is initaly pushed
		if (Input.GetButtonDown("Fire1")){
			
			//Sets the vertexCount to 2 (Prep for new line)
			vertexCount = 2;
			//Instantiates new Spawnable object at mousePos and saves it under the vairable "lastSpawned"
			lastSpawned = (GameObject) Instantiate (Spawnable, mousePos, Quaternion.identity);
			//Sets the vertexCount of the Line object, in this case its 2, (See line 33)
			lastSpawned.GetComponent<LineRenderer> ().SetVertexCount (vertexCount);
			//Sets the very first positon in the Line's array(0) to mousePos
			lastSpawned.GetComponent<LineRenderer> ().SetPosition (0, mousePos);
			//Sets lastMousePos to mousePos (we need to keep track of how far our last point was)
			lastMousePos = mousePos;

		}
		if (Input.GetButton ("Fire1")) {
			
			//when the distance between our lastMousePose and current mousePos exceeds 0.5f
			if (Vector2.Distance (lastMousePos, mousePos) > 0.5f) {
				//add another vertex to our Line
				vertexCount++;
				lastSpawned.GetComponent<LineRenderer> ().SetVertexCount (vertexCount);

				//Set the end of our vertex to our current mousePos ("vertexCount-1" - This is because our list starts at 0 and vertexCount actaully counts the # of vertex)
				lastSpawned.GetComponent<LineRenderer> ().SetPosition (vertexCount - 1, mousePos);

			} else {
				
				lastSpawned.GetComponent<LineRenderer> ().SetPosition (vertexCount - 1, mousePos);

			}

		}

	}//Update

}//ClickandDragScript