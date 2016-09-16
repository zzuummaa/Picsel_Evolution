using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//В методе eatReaction используется Ganeratescript.mapSize

public class AdultPicselBehaviourScript : BehaviourScript {
	//Объект, который преследуем
	protected GameObject pursuedObject ;
	//Таймеры
	private float timerEatReaction = 0;
	public float timeEatReaction = 2f;
	private float timerManyDangerObjects = 0f;
	public float timeManyDangerObjects = 1.5f;

	protected override void setSituation () {
		if (eatObjects.Count > 0) situation = Situation.eat;
		if (dangerObjects.Count > 0) situation = Situation.danger;
	}

	protected override void setDangerObjectsAngles () {
		foreach (GameObject c in dangerObjects) {
 			float vectorX = c.transform.position.x - transform.position.x;
			float vectorY = c.transform.position.y - transform.position.y;
			dangerObjectsAngles.Add(Mathf.Atan( vectorY / vectorX ));
			if (vectorX < 0) {
				dangerObjectsAngles[dangerObjectsAngles.Count-1] += 180 * Mathf.Deg2Rad; 
			}
		}
	}

	protected override void dangerReaction() {
		//Debug.Log (dangerObjectsAngles[0] * Mathf.Rad2Deg);
		if (dangerObjectsAngles.Count == 0) {
			//Debug.Log(timerAbsenceCollisions);
			//задержка перед переключением состояния
			timerDangerReaction -= Time.deltaTime;
			//меняем состояние объекта
			if (timerDangerReaction <= 0f) {
				situation = Situation.off;
				timerManyDangerObjects = 0f;
			} 

		}

		if (dangerObjectsAngles.Count == 1) {
			if (timerManyDangerObjects <= 0f) {
				timerManyDangerObjects = timeManyDangerObjects;
				float angle = dangerObjectsAngles[0];
				direction = new Vector2 (-Mathf.Cos(angle), -Mathf.Sin(angle));
				//Debug.Log(angle * Mathf.Rad2Deg);
			} else
				timerManyDangerObjects -= Time.deltaTime;

			//передаем тамеру время до смены состояния объекта
			timerDangerReaction = timeDangerReaction;
		}

		//Находим два смежных пикселя, угол между которыми наибольший и двигаемся между ними некоторое время
		if (dangerObjectsAngles.Count > 1) {
			if (timerManyDangerObjects <= 0f) {
				timerManyDangerObjects = timeManyDangerObjects;
				dangerObjectsAngles.Sort();
				
				float maxDifferenceAngles = 0f;
				int k = 0;
				
				for(int i = 0; i < dangerObjectsAngles.Count - 1; i++) {
					float angle = dangerObjectsAngles[i+1] - dangerObjectsAngles[i];
					if (maxDifferenceAngles < angle) {
						maxDifferenceAngles = angle;
						k = i;
					}
				}
				float ang = Mathf.PI * 2 - (dangerObjectsAngles[dangerObjectsAngles.Count - 1] - dangerObjectsAngles[0]);
				if (ang > maxDifferenceAngles) {
					maxDifferenceAngles = ang;
					k = dangerObjectsAngles.Count - 1;
				}
				
				float angleMovement = maxDifferenceAngles/2 + dangerObjectsAngles[k];
				direction = new Vector2(Mathf.Cos(angleMovement), Mathf.Sin(angleMovement));
				//			Debug.Log(angleBetweenPicsels * Mathf.Rad2Deg);
				//			Debug.Log(Mathf.Cos(angleBetweenPicsels));
				//			Debug.Log(Mathf.Sin(angleBetweenPicsels));
			} else {
				timerManyDangerObjects -= Time.deltaTime;
			}

			//передаем тамеру время до смены состояния объекта
			timerDangerReaction = timeDangerReaction;						
		} 
		//Debug.Log(dangerObjectsAngles.Count);
	}

	protected override void offReaction() {
		//Debug.Log ("off reaction work");
		if (dangerObjectsAngles.Count > 0) {
			dangerReaction();
		} else
			direction = Vector2.zero;

	}
	
	protected override void eatReaction () {
		if (timerEatReaction <= 0f) {
			searchNearestObject (eatObjects);
			timerEatReaction = timeEatReaction;
		}

		if (pursuedObject != null) 		
			direction = new Vector2 (pursuedObject.transform.position.x - transform.position.x,		                         
			                         pursuedObject.transform.position.y - transform.position.y).normalized;
		else {
			situation = Situation.off;
			timeEatReaction = 0f;
			//Debug.Log("Switch off");
		}

		//timerEatReaction -= Time.deltaTime;
		//Debug.Log ("Count = " + eatObjects.Count);
		//Debug.Log (direction);
		//if (pursuedObject != null) Debug.Log("pursuedObject is not null");
		//else                       Debug.Log("pursuedObject is null");
	}

	protected void searchNearestObject (List<GameObject> eatObjects) {
		//Debug.Log ("count in searchNearestObject = " + eatObjects.Count);
		float distanceToPicsel = GanerateScript.mapSize.sqrMagnitude;

		if (eatObjects.Count == 0){
			pursuedObject = null;
			return;
		}

		//Debug.Log ("serchNearestObject:");
		//Debug.Log (eatObjects.Count);
		for(int i = 0; eatObjects.Count > i; i++) {
			//Debug.Log (eatObjects[i]);
			if (!eatObjects[i]) continue;
			float v;
			v = new Vector2(eatObjects[i].transform.position.x - transform.position.x,
				            eatObjects[i].transform.position.y - transform.position.y).sqrMagnitude;

			if (v < distanceToPicsel){
				distanceToPicsel = v;
				pursuedObject = eatObjects[i];
			}
		}
	}
}
