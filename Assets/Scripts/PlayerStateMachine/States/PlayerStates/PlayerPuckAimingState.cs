using UnityEngine;

public class PlayerPuckAimingState : State
{
    private Vector3 startMousePosition;
    private Vector3 endMousePosition;

    private Vector2 CardinalXZStart;
    private Vector2 CardinalXZEnd;

    //private GameObject puckToThrow;
    private Rigidbody puckToThrowRB;
    private Vector2 directionThrowXZ;

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
            PuckSelectable puckSelectable = hit.collider.gameObject.GetComponent<PuckSelectable>();
            if (puckSelectable != null && puckSelectable.placed == true && puckSelectable.throwed == false)
            {
                _owner.puckToThrow = hit.collider.gameObject;

                Debug.Log("oggetto colpito: " + hit.collider.gameObject.name + " che � un puck da esser lanciato");

                //puckToThrow = puckSelectable.GetComponent<GameObject>();
                puckToThrowRB = _owner.puckToThrow.GetComponent<Rigidbody>();

                startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
                CardinalXZStart = new Vector2(startMousePosition.x, startMousePosition.z);
            }
        }
    }

    public void Shoot()
    {
        if (_owner.puckToThrow != null)
        {
            endMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
            CardinalXZEnd = new Vector2(endMousePosition.x, endMousePosition.z);

            if (_owner.invertedAim)
                directionThrowXZ = (CardinalXZStart - CardinalXZEnd);
            else
                directionThrowXZ = (CardinalXZEnd - CardinalXZStart);

            Debug.Log("Direzione di sparo: " + directionThrowXZ);

            if (puckToThrowRB != null)
            {
                //applica la forza al rb
                puckToThrowRB.AddForce(new Vector3(directionThrowXZ.x, 0, directionThrowXZ.y) * _owner.throwForce, ForceMode.Impulse);

                _owner.puckToThrow.GetComponent<PuckSelectable>().throwed = true;
                _owner.puckToThrow = null;
                _owner.placedPucks--;
                if (_owner.placedPucks <= 0)
                {
                    _owner.SetState(EPlayerState.PlayerWaiting);
                }
            }
        }
    }
}
