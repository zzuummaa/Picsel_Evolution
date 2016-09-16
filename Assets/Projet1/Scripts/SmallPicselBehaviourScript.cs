using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmallPicselBehaviourScript : BehaviourScript {

	private Vector2 awakePosition;
	
	private GameObject nearestObject;
	
	private float timerOffReaction = 0f;
	public float timeOffReaction = 2f;

	void Awake () {
		awakePosition = new Vector2 (transform.position.x - 0.5f, transform.position.y - 0.5f);
	}

	protected override void setSituation () {
		if (dangerObjects.Count > 0) situation = Situation.danger;
		else {
			if (dangerObjectsAngles.Count == 1) situation = Situation.wall;
		}

	}
	
	protected override void dangerReaction () {
		//Debug.Log ("Small picsel");
		//Проверяем, есть ли опасность неподалеку
		if (dangerObjects.Count > 0)		
			setNearestObject ();
		else {
			timerDangerReaction -= Time.deltaTime;
			if (timerDangerReaction <= 0) situation = Situation.off;
			return;
		}
		
		if (nearestObject.transform.position.x < transform.position.x)
		{direction.x = 1;}
		else
		{direction.x = -1;}
		
		if (nearestObject.transform.position.y < transform.position.y)
		{direction.y = 1;}
		else
		{direction.y = -1;};

		timerDangerReaction = timeDangerReaction;
	}

	//Находим ближайший объект
	private void setNearestObject () {
		int k = 0;
		float v = 128f;
		
		for (int i = 0; dangerObjects.Count > i; i++) {
			if (!dangerObjects[i]) continue;
			float chekedObject = new Vector2(dangerObjects[i].transform.position.x - transform.position.x,
			                                 dangerObjects[i].transform.position.y - transform.position.y).sqrMagnitude ;
			if (v > chekedObject) {
				v = chekedObject;
				k = i;
			}
		}

		nearestObject = dangerObjects [k];
	}

	protected override void offReaction () {
		timerOffReaction -= Time.deltaTime;

		if (timerOffReaction <= 0) {
			if (Random.Range(0, 2) == 0)
				direction = Vector2.zero;
			else {
				if ((int)Random.Range(0, 3) == 1)
					direction = new Vector2(awakePosition.x - transform.position.x,
					                        awakePosition.y - transform.position.y).normalized;
				else
					direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
			}

			timerOffReaction = timeOffReaction;
			//Debug.Log(direction);
			//Debug.Log(direction.magnitude);
			
		}
	}

	protected override void wallReaction () {
		if (dangerObjectsAngles.Count == 0) {
			situation = Situation.off;
			return;
		}
		direction = new Vector2 (-Mathf.Cos(dangerObjectsAngles[0]), -Mathf.Sin(dangerObjectsAngles[0]));
	}
}
