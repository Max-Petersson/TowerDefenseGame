using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MenuLogic : MonoBehaviour
{
    private Animator animator;

    //StateMachine
    private enum MenuState {open, close};
    private MenuState state = MenuState.close;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void BuyUnit()
    {
        //Set Cursor logic or state to holding unit with the unit associated
        Debug.Log("Cursor now holding unit");
    }
    #region Open/Close Shop;
    public void OpenClose()
    {
        if (state == MenuState.close) 
        {
            state = MenuState.open;
            ShowBuyMenu();
        }
        else
        {
            state = MenuState.close;
            HideBuyMenu();
        }
    }
    public void ShowBuyMenu()
    {
        animator.Play("BuyMenuSlideIn");
    }
    public void HideBuyMenu()
    {
        animator.Play("BuyMenuSlideOut");
    }
    #endregion
}
