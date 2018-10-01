using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeChildPosition : MonoBehaviour
{

    public float xSpacing = 1.5f; // How much to space each hero on the X axis.
    public Vector2 rootPosition; // The offset of the rightmost hero. Other heroes will fall to the left.
    public bool growLeft = true; //whether to grow left or right
    public List<GameObject> heroes;

    System.Random random = new System.Random();

    void ShuffleList<E>(IList<E> list)
    {
        if (list.Count > 1)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                E tmp = list[i];
                int randomIndex = random.Next(i + 1);

                //Swap elements
                list[i] = list[randomIndex];
                list[randomIndex] = tmp;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        if (growLeft)
        {
            xSpacing *= -1;
        }

        foreach (Transform hero in transform) {
            heroes.Add(hero.gameObject);
        }

        ShuffleList(heroes);

        float startOffset = 0f;

        foreach (GameObject hero in heroes)
        {
            hero.transform.localPosition = new Vector3(rootPosition.x + startOffset, rootPosition.y, 0);
            startOffset += xSpacing;
        }
    }
}
