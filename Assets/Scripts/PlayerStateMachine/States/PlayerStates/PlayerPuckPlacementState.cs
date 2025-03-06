using UnityEngine;

public class PlayerPuckPlacementState : State
{
    public PlayerPuckPlacementState(PlayerStateMachine player)
    {
        _owner = player;
    }
    public PlayerStateMachine _owner { get;}
    public override void OnCollisionEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnEnterState()
    {
        Debug.Log("Sto entrando in PlayerPuckPlacementState");
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerPuckPlacementState");
    }

    public override void OnFixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerEnter()
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        Debug.Log("Sono nell'update di PlayerPuckPlacementState");
        //al posto di questo if la funzione sarà aggiunta alla
        if (Input.GetMouseButtonDown(0))
        {
            PlacementPuck();
        }
    }
    public void PlacementPuck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<PlanePivotPuck>() != null)
            {
                Debug.Log("oggetto colpito: " + hit.collider.gameObject.name + " che è un piano");

                if(_owner.puckSelected != null)
                {
                    _owner.puckSelected.transform.position = hit.collider.gameObject.GetComponent<PlanePivotPuck>().puckPos.transform.position;
                    _owner.puckSelected = null;
                    _owner.placedPucks++;
                    if (_owner.placedPucks >= _owner.maxPucks)
                        _owner.SetState(EPlayerState.PlayerPuckAiming);
                    else
                        _owner.SetState(EPlayerState.PlayerPuckSelection);
                }
            }
        }
    }

}
