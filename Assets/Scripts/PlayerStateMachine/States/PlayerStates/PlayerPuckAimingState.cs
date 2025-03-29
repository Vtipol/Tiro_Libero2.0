using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.GridLayoutGroup;

public class PlayerPuckAimingState : GenericState
{
    public MyInputActions inputAction;
    private PlayerManager playerManager;
    private Vector3 startMousePosition;
    private Vector3 endMousePosition;

    private Vector2 CardinalXZStart;
    private Vector2 CardinalXZEnd;
    private Vector2 directionThrowXZ;

    //private Vector3 tremblingOffset;

    private bool aiming;

    private PlayerStateMachine stateMachine;
    private Player player;
    private PuckBase previousPuckShot;
    public PlayerPuckAimingState(PlayerStateMachine stateMachine, Player player)
    {
        this.player = player;
        this.stateMachine = stateMachine;

        playerManager = PlayerManager.Instance;

        inputAction = new MyInputActions();

        inputAction.Mouse.Charge.performed += Charge;
        inputAction.Mouse.Charge.canceled += Shoot;

        //playerManager.FallingCamera.OnPuckFallAnimationEnded += (go) => previousPuckShot.DestroyPuck();
    }

    public override void OnEnterState()
    {
        Debug.Log("Sto entrando in PlayerPuckAimingState");

        inputAction.Enable();

        playerManager.FallingCamera.CurrentFocusedPuck = playerManager.puckSelected.gameObject;
        playerManager.StationaryCamera.StartPull();
    }

    public override void OnExitState()
    {
        Debug.Log("Sto uscendo da PlayerPuckAimingState");

        inputAction.Disable();
    }

    public override void OnUpdate()
    {

        //controllo che muove la mira mentre sto caricando
        if (aiming)
        {
            

            //Debug.Log("distanzaaaa : " + distance);
            //if (distance > _owner.tremblingThreshold)
            //{
            //    float time = Time.time * _owner.tremblingSpeed;
            //    float angle = time % (2 * Mathf.PI);
            //    tremblingOffset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * _owner.tremblingAmplitude;

            //}

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
            if (playerManager.invertedAim)
                playerManager.lineRenderer.SetPosition(1, new Vector3(playerManager.puckToThrow.transform.position.x * 2 - mousePos.x , 0, playerManager.puckToThrow.transform.position.z * 2 - mousePos.z ));
            else
                playerManager.lineRenderer.SetPosition(1, new Vector3(mousePos.x , 0, mousePos.z ));

            float distance = Vector3.Distance(playerManager.puckToThrow.transform.position, playerManager.lineRenderer.GetPosition(1));

            playerManager.StationaryCamera.UpdatePullDistance(distance);
        }
    }

    //funzione fatta alla premuta del mouse che � il punto di inizio di mira
    public void Charge(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("CHARGENING");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerManager.puckLayerMask))
        {
            PuckBase puckSelectable = hit.collider.gameObject.GetComponent<PuckBase>();
            if (puckSelectable != null && puckSelectable.placed == true && puckSelectable.throwed == false)
            {
                playerManager.SelectablePuckTT = puckSelectable;
                playerManager.puckToThrow = playerManager.puckSelected;

                startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
                CardinalXZStart = new Vector2(startMousePosition.x, startMousePosition.z);

                playerManager.lineRenderer.SetPosition(0, new Vector3(playerManager.puckToThrow.transform.position.x, 0, playerManager.puckToThrow.transform.position.z));
                //Debug.Log("puck line starting"+_owner.puckToThrow.transform.position);
                playerManager.lineRenderer.enabled = true;

                aiming = true;
            }
        }
    }

    //funzione fatta al rilascio del mouse e che calcola la direzione dove lanciare il puck e applica la direzione di forza
    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Shoootening");

        if (playerManager.puckToThrow != null)
        {
            aiming = false;
            endMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10);
            CardinalXZEnd = new Vector2(endMousePosition.x, endMousePosition.z);

            playerManager.lineRenderer.SetPosition(1, new Vector3(endMousePosition.x, 0, endMousePosition.z));
            playerManager.lineRenderer.enabled = false;

            if (playerManager.invertedThrow)
                directionThrowXZ = (CardinalXZStart - CardinalXZEnd);
            else
                directionThrowXZ = (CardinalXZEnd - CardinalXZStart);

            Debug.Log("Direzione di sparo: " + directionThrowXZ);

            playerManager.FollowPuck.SetPuck(playerManager.puckToThrow.gameObject);

            var rb = playerManager.puckToThrow.GetComponent<Rigidbody>();
                //applica la forza al rb
            rb.AddForce(new Vector3(directionThrowXZ.x, 0, directionThrowXZ.y) * playerManager.throwForce, ForceMode.Impulse);

            previousPuckShot = playerManager.puckToThrow;
                // Adding the puck so we can make it fall when exiting the board
            playerManager.DisableColliders.AddRb(playerManager.puckToThrow.GetComponent<Rigidbody>());
            playerManager.SelectablePuckTT.throwed = true;
            playerManager.puckToThrow = null;
            playerManager.SelectablePuckTT = null;
            playerManager.puckSelected = null;
            playerManager.myPlacedPucks--;

            stateMachine.SetState(EPlayerState.PlayerIdle);
            playerManager.playerTurnEndSignal?.Invoke();
        }
    }
}
