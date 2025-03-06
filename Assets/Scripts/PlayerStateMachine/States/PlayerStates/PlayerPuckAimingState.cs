using UnityEngine;

public class PlayerPuckAimingState : State
{
    public Vector2 mousePos;
    public PlayerPuckAimingState(PlayerStateMachine player)
    {
        _owner = player;
    }
    public PlayerStateMachine _owner { get; }
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
        Debug.Log("Sto entrando in PlayerPuckAimingState");
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerPuckAimingState");
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
        Debug.Log("Sono nell'update di PlayerPuckAimingState");

        if (Input.GetMouseButtonDown(0))
        {
            Charge();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    public void Charge()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<IPuckInteractable>() != null)
            {
                Debug.Log("oggetto colpito: " + hit.collider.gameObject.name + " che è un puck da esser lanciato");
                _owner.puckToShoot = hit.collider.gameObject;
            }
        }


        _owner.placedPucks--;
        if (_owner.placedPucks <= 0)
            _owner.SetState(EPlayerState.PlayerWaiting);
        else
            _owner.SetState(EPlayerState.PlayerPuckPlacement);
    }

    public void Shoot()
    {
        //WIP
        if(_owner.puckToShoot != null)
        {
            //funzione per lanciare il puck
        }
    }
}
