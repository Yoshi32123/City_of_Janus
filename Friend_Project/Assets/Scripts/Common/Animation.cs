using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {

    private DirectionFacing direction;
    public DirectionFacing prevDirection;
    [SerializeField]
    private Sprite currentSprite;
    [SerializeField]
    private List<Sprite> allSpritesReference; 
    private Dictionary<string, Sprite> allSprites;
    [SerializeField]
    private int counter;
    [SerializeField]
    private int COUNTER_MAX;
    private bool isMoving; 
    private int spriteIndex;

    public int Counter
    {
        get { return counter; }
        set { counter = value; }
    }

    public DirectionFacing Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

	// Use this for initialization
	void Start () {
        isMoving = false; 
        direction = DirectionFacing.Front;
        currentSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        allSprites = new Dictionary<string, Sprite>(12);
        spriteIndex = 0; 

        for (int i = 0; i < allSpritesReference.Count; i++)
        {
            allSprites.Add(allSpritesReference[i].name, allSpritesReference[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!isMoving)
        {
            return; 
        }

        counter++;

        bool newDirection = false; 
        if (prevDirection != direction)
        {
            newDirection = true;
        }

        //switch (direction)
        //{
        //    case DirectionFacing.Back:
        //        IncrementSprite(newDirection);
        //        break;
        //    case DirectionFacing.Front:
        //        IncrementSprite(newDirection);
        //        break;
        //    case DirectionFacing.Left:
        //        IncrementSprite(newDirection);
        //        break;
        //    case DirectionFacing.Right:
        //        IncrementSprite(newDirection);
        //        break;
        //    default:
        //        break;
        //}

        IncrementSprite(newDirection);

        isMoving = false;

        prevDirection = direction;

        gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
	}

    private void IncrementSprite(bool newDirection)
    {
        if (newDirection)
        {
            allSprites.TryGetValue("mc_" + direction.ToString().ToLower().Substring(0, 2) + "_0", out currentSprite);
            return;
        }
        if (counter >= COUNTER_MAX)
        {
            if (spriteIndex != 2)
            {
                string sample = string.Concat(currentSprite.name.Substring(0, 6), spriteIndex++);
                allSprites.TryGetValue(sample, out currentSprite);
                //spriteIndex++;
            }
            else
            {
                string sample = string.Concat(currentSprite.name.Substring(0, 6), 0);
                allSprites.TryGetValue(sample, out currentSprite);
                spriteIndex = 0; 
            }

            counter = 0;
        }
    }
}
