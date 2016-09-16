using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviourScript : MonoBehaviour {
	public static Vector2 mapDistanceReaction; 
	public static float distanceReaction = 4f;
	protected Vector2 movement;
	protected Vector2 direction = new Vector2 (0, 0);
	public float speed = 4f;

	protected float timerDangerReaction = 0.5f;
	public float timeDangerReaction = 0.5f;

	//Реализация dangerReaction
	protected List<GameObject> dangerObjects = new List<GameObject>();
	protected List<float> dangerObjectsAngles = new List<float> ();
	//Реализация eatReaction
	protected List<GameObject> eatObjects = new List<GameObject>();
	protected GameObject[] objectsMovingBetweenThem = new GameObject[2];
	protected float angleMovement = 0f;

	protected enum Situation {off, danger, eat, wall};
	protected Situation situation = Situation.off;

	protected virtual void dangerReaction () {}

	protected virtual void eatReaction () {}

	protected virtual void offReaction () {}

	protected virtual void setSituation() {}

	protected virtual void setDangerObjectsAngles () {}

	protected virtual void wallReaction () {}
	
	protected void setDirection () {

		//выполняем действия в зависимости от состояния
		switch (situation) {
		case Situation.off:
			offReaction();
			break;
		case Situation.danger:
			dangerReaction(); 
			break;
		case Situation.eat:
			eatReaction();
			break;
		case Situation.wall:
			wallReaction();
			break;
		}

		//Debug.Log ("Situation is " + situation);
	}

	void FixedUpdate() {

		removeDestroyedObjects (dangerObjects);
		checkWall ();
		setDangerObjectsAngles ();
		setSituation ();
		setDirection ();
		
		rigidbody2D.velocity = new Vector3 (direction.x * speed,
		                                    direction.y * speed) ; 

		dangerObjectsAngles.Clear();
		eatObjects.Clear ();
		dangerObjects.Clear ();
		//Debug.Log(dangerObjects.Count);
		//Debug.Log(direction.magnitude);
	}



	void OnTriggerStay2D(Collider2D c) {
		if (!c.isTrigger & c.tag == "Picsel") {
			bool b = c.transform.lossyScale.x > transform.localScale.x;
			if (b) 
				dangerObjects.Add(c.gameObject);
			else			
				if (c.transform.localScale.x < 0.5f)				
					eatObjects.Add(c.gameObject);
		}
	}
	
//	void OnTriggerExit2D(Collider2D c) {
//		dangerObjects.Remove (c.gameObject);
//		eatObjects.Remove(c.gameObject);
//	}

	//Проверяем близко ли мы к стене и записываем -угол направления 
	protected void checkWall () {
		Vector2 vector = Vector2.zero;
		
		if (transform.position.x > mapDistanceReaction.x) {
			vector.x = 1;
		}
		if (transform.position.x < -mapDistanceReaction.x) {
			vector.x = -1;
		} 
		if (transform.position.y > mapDistanceReaction.y) {
			vector.y = 1;  
		}
		if (transform.position.y < -mapDistanceReaction.y) {
			vector.y = -1;
		}
		//Debug.Log (mapDistanceReaction.x + "  " + mapDistanceReaction.y);
		//Debug.Log (vector.x + "  " + vector.y);
		if (vector != Vector2.zero)	{

			dangerObjectsAngles.Add(Mathf.Atan (vector.y / vector.x));
			if (vector.x < 0) dangerObjectsAngles [0] += 180 * Mathf.Rad2Deg;
			//Debug.Log (dangerObjectsAngles [0] * Mathf.Rad2Deg);
		}	

	}

	//Временное решение для отбрасывания уничтоженных объектов при рассчетах
	protected void removeDestroyedObjects (List<GameObject> list) {
		//Debug.Log ("removeDestroyObjects:");
		for (int i = 0; list.Count > i;i++) {
			if (!list[i]) list.RemoveAt(i);
		}
		//Debug.Log (list.Count);
	}

}
