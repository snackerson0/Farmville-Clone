using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{

    public GridElement CurSelectedGridElement, curHoveredGridElement, lastHoveredGridElement;

    public GridElement[] grid; 
    [Header("Color")]
    public Color colorOnHover = Color.white;
    public Color colorOnOccupied = Color.red;

    private RaycastHit mouseHit;
    private Color colorOnNormal;


	// Use this for initialization
	void Awake ()
	{
	    colorOnNormal = grid[0].GetComponentInChildren<MeshRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    if (Physics.Raycast(ray,out mouseHit))
	    {
	        GridElement g = mouseHit.transform.GetComponent<GridElement>();
	        if (!g)
	        {
	            if (curHoveredGridElement)
	            {
	                curHoveredGridElement.GetComponent<MeshRenderer>().material.color = colorOnNormal;
                    return;
	                
	            }
	        }            
	        if (Input.GetMouseButtonDown(0))
	        {
	            CurSelectedGridElement = g;
	        }

	        if (g)
	        {
	            curHoveredGridElement = g;
	        }

	        if (g = curHoveredGridElement)
	        {
	            if (!g.isOccupied) mouseHit.transform.GetComponent<MeshRenderer>().material.color = colorOnHover;
	            else mouseHit.transform.GetComponent<MeshRenderer>().material.color = colorOnOccupied;

	        }

            if (g != curHoveredGridElement)
            {
                
                curHoveredGridElement = g;
            }

            if (!lastHoveredGridElement)
	        {
	            lastHoveredGridElement = curHoveredGridElement;
	        }

	        if (lastHoveredGridElement != curHoveredGridElement)
	        {
	            lastHoveredGridElement.GetComponent<MeshRenderer>().material.color = colorOnNormal;
	            lastHoveredGridElement = curHoveredGridElement;
	        }
	    }
	}
}
