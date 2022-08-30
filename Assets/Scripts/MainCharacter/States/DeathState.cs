using System.Collections;
using System.Collections.Generic;
using Common.Menu;
using MainCharacter.States;
using UnityEngine;

public class DeathState : PlayerState
{
    private Transform _transform;
    private float _disableDelay;
   
    private MonoBehaviour _monoBehaviour;
    private Coroutine _deathCoroutine;
        
        
        
        
        
    public override void Initialize()
    {
        base.Initialize();
        _transform = player.transform;
        _disableDelay = player.DisableDelay;
        _monoBehaviour = _transform.GetComponent<MonoBehaviour>();

    }
   
    public override void Process()
    {
            
          
    }
        
        
        
    private void DisableSelf()
    {
        player.gameObject.SetActive(false);
    }
        
    public override void EnterState()
    {
        base.EnterState();
        _deathCoroutine = _monoBehaviour.StartCoroutine(Death());
        
        FinishState();
            
            
    }
    
    IEnumerator Death()
    {
        player.animator.Play("Died");
        yield return  new  WaitForSeconds(_disableDelay);
        DisableSelf();
        //Time.timeScale = 0;
        GameStatusWindow.Instance.EnableLoseScreen();
        
        //Отключить всю графику?и как это сделать?

    }
        
       
}
