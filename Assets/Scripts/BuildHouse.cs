using UnityEngine;
using System.Collections.Generic;

public class BuildHouse : MonoBehaviour {

    [Range(5.0f, 14.0f)]
    public int nBricks = 10;
    [Range (4.0f, 8.0f)]
    public int nBricksHeight = 6;
    public GameObject brick;
    public GameObject beam;
    public GameObject roofPanel;

    private List<GameObject> constructedObjects = new List<GameObject>();
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Construct();
	}

    void Construct()
    {
        Clean();
        BuildWalls();
        BuildBeams();
        BuildRoof();
    }

    void Clean()
    {
        constructedObjects.ForEach(x => GameObject.DestroyObject(x));
        constructedObjects.Clear();
    }

    void BuildWalls()
    {
        var bLength = brick.transform.localScale.x;
        var bWidth = brick.transform.localScale.z;
        var bHeight = brick.transform.localScale.y;
        var midPoint = nBricks * bLength * 0.5f;
        GameObject newBrick;
        for(var j = 0; j < nBricksHeight; j++){
            // North
            for (var i = 0; i < nBricks; i++)
            {
                newBrick = GameObject.Instantiate(brick);
                newBrick.transform.position = new Vector3(bLength * i - midPoint + bLength * 0.5f, bHeight * j + bHeight / 2.0f, -midPoint - bWidth * 0.5f);
                newBrick.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                constructedObjects.Add(newBrick);
            }
            // East
            for (var i = 0; i < nBricks; i++)
            {
                newBrick = GameObject.Instantiate(brick);
                newBrick.transform.position = new Vector3(midPoint + bWidth * 0.5f, bHeight * j + bHeight / 2.0f, bLength * i - midPoint + bLength * 0.5f);
                newBrick.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                constructedObjects.Add(newBrick);
            }
            // South
            for (var i = 0; i < nBricks; i++)
            {
                newBrick = GameObject.Instantiate(brick);
                newBrick.transform.position = new Vector3(bLength * i - midPoint + bLength * 0.5f, bHeight * j + bHeight / 2.0f, midPoint + bWidth * 0.5f);
                newBrick.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                constructedObjects.Add(newBrick);
            }
            // West
            for (var i = 0; i < nBricks; i++)
            {
                newBrick = GameObject.Instantiate(brick);
                newBrick.transform.position = new Vector3(-midPoint - bWidth * 0.5f, bHeight * j + bHeight / 2.0f, bLength * i - midPoint + bLength * 0.5f);
                newBrick.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                constructedObjects.Add(newBrick);
            }
        }
    }

    void BuildBeams()
    {
        var offsety = beam.transform.localScale.y * 0.5f + nBricksHeight * brick.transform.localScale.y + brick.transform.localScale.y * 0.5f;
        var offsetz = (nBricks + 0.5f) * brick.transform.localScale.x * 0.5f;
        beam.transform.localScale = new Vector3(beam.transform.localScale.x, beam.transform.localScale.y, offsetz * 2.0f + brick.transform.localScale.z);

        GameObject newBeam;
        for(var i = -offsetz; i <= offsetz; i += 3.0f)
        {
            newBeam = GameObject.Instantiate(beam);
            newBeam.transform.position = new Vector3(0.0f, offsety, i);
            newBeam.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
            constructedObjects.Add(newBeam);
        }
    }

    void BuildRoof()
    {
        roofPanel.transform.localScale = new Vector3(brick.transform.localScale.x, 0.1f, 3.0f);

        var offsety = roofPanel.transform.localScale.y * 0.5f;
        offsety += beam.transform.localScale.y;
        offsety += nBricksHeight * brick.transform.localScale.y + brick.transform.localScale.y * 0.5f;
        var offsetz = (nBricks + 0.5f) * brick.transform.localScale.x * 0.5f - roofPanel.transform.localScale.z * 0.5f;

        GameObject newPanel;
        for (var i = -offsetz; i <= offsetz; i += 3.0f)
        {
            for(var j = -offsetz; j <= offsetz; j += roofPanel.transform.localScale.x)
            {
                newPanel = GameObject.Instantiate(roofPanel);
                newPanel.transform.position = new Vector3(j, offsety, i);
                newPanel.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                constructedObjects.Add(newPanel);
            }
        }
    }
}
