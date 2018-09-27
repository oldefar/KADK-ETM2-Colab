using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenter : MonoBehaviour {

    public GameObject target;
    public float zPosition = -10;
    public Vector2 partyCentroid;
    public Vector2 previousPos;

	Vector2 CalculateCentroid () {
        int numberOfHeroes = target.transform.childCount;
        if (numberOfHeroes > 0)
        {
            Vector2 centroid = Vector2.zero;
            foreach (Transform hero in target.transform)
            {
                Vector2 heroPos = hero.transform.position;
                centroid += heroPos;
            }
            centroid /= numberOfHeroes;
            return centroid;
        }
        else { return previousPos; }
	}
	
	// Update is called once per frame
	void LateUpdate () {
        previousPos = transform.position;
		partyCentroid = CalculateCentroid();
        transform.position = new Vector3(partyCentroid.x, partyCentroid.y, zPosition);
	}
}
