using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    //Holding unit gameobject or image

    //Should maybe tell everyone that is interested that im currently in this state
    private enum CursorState {idle, holdingUnit, focusedOnUnit}
    private CursorState myState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StateBasedClick();
        }
        
        var focusedTile = FocusTile();
        if (focusedTile.HasValue)
        {
            GameObject hitObject = focusedTile.Value.collider.gameObject;
            transform.position = hitObject.transform.position;
        }
    }
    public RaycastHit2D? FocusTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y );

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (hits.Length > 0)
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();

            return null;
    }
    #region State and interaction
    public void SetToIdle()
    {
        myState = CursorState.idle;
    }
    public void SetToHoldingUnit(GameObject heldUnit)
    {
        myState= CursorState.holdingUnit;
        // change cursor to the held unit
    }
    private void StateBasedClick()
    {
        if (myState == CursorState.idle)
        {
            // maybe some feedback
        }
        else if (myState == CursorState.holdingUnit)
        {

            //check if you can place it there and place it
            //if successful change back to idle

        }
        else if (myState == CursorState.focusedOnUnit) //maybe should shoot a raycast before to check if im hoovering a unit 
        {
            
        }
    }
    #endregion
}
