using Mono.Cecil.Cil;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class PlayerPuckAimingState : State
{
    private Vector3 startMousePosition;
    private Vector3 endMousePosition;

    private Vector2 CardinalXZStart;
    private Vector2 CardinalXZEnd;

    private Rigidbody puckToThrowRB;
    private Vector2 directionThrowXZ;

    private Vector3 tremblingOffset;

    private bool aiming;

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
        else if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
        if(aiming)
        {
            float distance = Vector3.Distance(_owner.puckToThrow.transform.position, _owner.lineRenderer.GetPosition(1));

            _owner.StationaryCamera.PullOut(distance);

            Debug.Log("distanzaaaa : " + distance);
            if (distance > _owner.tremblingThreshold)
            {
                float time = Time.time * _owner.tremblingSpeed;
                float angle = time % (2 * Mathf.PI);
                tremblingOffset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * _owner.tremblingAmplitude;

            }

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
            if (_owner.invertedAim)
                _owner.lineRenderer.SetPosition(1, new Vector3(puckToThrowRB.transform.position.x*2 - mousePos.x + tremblingOffset.x, 0,puckToThrowRB.transform.position.z*2 - mousePos.z + tremblingOffset.z));
            else
            _owner.lineRenderer.SetPosition(1, new Vector3(mousePos.x + tremblingOffset.x, 0, mousePos.z + tremblingOffset.z));
        }
    }

    public void Charge()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _owner.puckLayerMask))
        {
            PuckSelectable puckSelectable = hit.collider.gameObject.GetComponent<PuckSelectable>();
            if (puckSelectable != null && puckSelectable.placed == true && puckSelectable.throwed == false)
            {
                _owner.SelectablePuckTT = puckSelectable;
                _owner.puckToThrow = _owner.puckSelected;
                puckToThrowRB = _owner.puckToThrow.GetComponent<Rigidbody>();

                startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
                CardinalXZStart = new Vector2(startMousePosition.x, startMousePosition.z);

                _owner.lineRenderer.SetPosition(0, new Vector3(_owner.puckToThrow.transform.position.x, 0, _owner.puckToThrow.transform.position.z));
                //Debug.Log("puck line starting"+_owner.puckToThrow.transform.position);
                _owner.lineRenderer.enabled = true;

                aiming = true;
            }
        }
    }

    public void Shoot()
    {
        if (_owner.puckToThrow != null)
        {
            aiming = false;
            endMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
            CardinalXZEnd = new Vector2(endMousePosition.x, endMousePosition.z);

            _owner.lineRenderer.SetPosition(1, new Vector3(endMousePosition.x, 0, endMousePosition.z));
            _owner.lineRenderer.enabled = false;

            if (_owner.invertedThrow)
                directionThrowXZ = (CardinalXZStart - CardinalXZEnd);
            else
                directionThrowXZ = (CardinalXZEnd - CardinalXZStart);

            Debug.Log("Direzione di sparo: " + directionThrowXZ);

            _owner.StationaryCamera.StopPulling();
            _owner.FollowPuck.SetPuck(_owner.puckToThrow);

            if (puckToThrowRB != null)
            {
                //applica la forza al rb
                puckToThrowRB.AddForce(new Vector3(directionThrowXZ.x, 0, directionThrowXZ.y) * _owner.throwForce, ForceMode.Impulse);
                _owner.SelectablePuckTT.throwed = true;
                _owner.puckToThrow = null;
                _owner.SelectablePuckTT.GetComponent<Collider>().enabled = false;
                _owner.SelectablePuckTT = null;
                _owner.puckSelected = null;
                _owner.myPlacedPucks--;

                if (_owner.myPlacedPucks <= 0 || _owner.place1AtTime)
                    _owner.SetState(EPlayerState.PlayerWaiting);
            }
        }
    }
}
