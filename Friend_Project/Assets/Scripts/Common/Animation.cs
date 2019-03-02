using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour {

    #region Fields
    private DirectionFacing direction;
    private DirectionFacing prevDirection;
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
    [SerializeField]
    private string prefix;
    #endregion

    #region Properties
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

    public DirectionFacing PrevDirection
    {
        get { return prevDirection; }
        set { prevDirection = value; }
    }

    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }
    #endregion

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

        IncrementSprite(newDirection);

        isMoving = false;

        prevDirection = direction;

        gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
	}

    /// <summary>
    /// Helper method to assist with incremementing the sprite
    /// without cluttering the Update method
    /// </summary>
    /// <param name="newDirection">A boolean indicating whether there is a different direction from the previous direction</param>
    private void IncrementSprite(bool newDirection)
    {
        if (newDirection)
        {
            allSprites.TryGetValue(prefix + "_" + direction.ToString().ToLower().Substring(0, 2) + "_0", out currentSprite);
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
