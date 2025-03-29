using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePuckBuilder : Singleton<GamePuckBuilder>
{
    public Player puckBuildingPlayer;
    private int normalPucksSelected = 1;
    private int weightPucksSelected = 1;
    private int bigPucksSelected = 1;
    [SerializeField] private GameObject puckBuilderUI;
    [Header("Buttons")]
    [SerializeField] private Button addNormalPuck;
    [SerializeField] private Button removeNormalPuck;
    [SerializeField] private Button addWeightPuck;
    [SerializeField] private Button removeWeightPuck;
    [SerializeField] private Button addBigPuck;
    [SerializeField] private Button removeBigPuck;

    [SerializeField] private Button confirmButton;
    [Header("TMP_Text")]
    [SerializeField] private TMP_Text normalPucksText;
    [SerializeField] private TMP_Text weightPucksText;
    [SerializeField] private TMP_Text bigPucksText;
    [Space]
    public int maxPucks = 7;
    public UnityEvent puckBuilt;
    void Awake()
    {
        //puckSpawnPoints = new Transform[maxPucks];

        addNormalPuck.onClick.AddListener(AddNormalPuck);
        removeNormalPuck.onClick.AddListener(RemoveNormalPuck);

        addWeightPuck.onClick.AddListener(AddWeightPuck);
        removeWeightPuck.onClick.AddListener(RemoveWeightPuck);

        addBigPuck.onClick.AddListener(AddBigPuck);
        removeBigPuck.onClick.AddListener(RemoveBigPuck);

        confirmButton.onClick.AddListener(Confirm);

        puckBuilderUI.SetActive(false);


        UpdateConfirmButton();
    }

    private void AddNormalPuck()
    {
        AddRemovePuckType(PuckType.NORMAL, true);
    }
    private void RemoveNormalPuck()
    {
        AddRemovePuckType(PuckType.NORMAL, false);
    }
    private void AddWeightPuck()
    {
        AddRemovePuckType(PuckType.WEIGHT, true);
    }
    private void RemoveWeightPuck()
    {
        AddRemovePuckType(PuckType.WEIGHT, false);
    }
    private void AddBigPuck()
    {
        AddRemovePuckType(PuckType.BIG, true);
    }
    private void RemoveBigPuck()
    {
        AddRemovePuckType(PuckType.BIG, false);
    }
    public void StartBuild(){
        normalPucksSelected = 1;
        weightPucksSelected = 1;
        bigPucksSelected = 1;
        puckBuilderUI.SetActive(true);
        UpdateConfirmButton();
    }
    public void Confirm()
    {
        puckBuildingPlayer.normalPucks = normalPucksSelected;
        normalPucksText.text = "1";
        puckBuildingPlayer.weightPucks = weightPucksSelected;
        weightPucksText.text = "1";
        puckBuildingPlayer.bigPucks = bigPucksSelected;
        bigPucksText.text = "1";

        puckBuilderUI.SetActive(false);

        puckBuilt?.Invoke();
    }

    private void AddRemovePuckType(PuckType _puckType, bool _AddRemove)
    {
        switch (_puckType)
        {
            case PuckType.NORMAL:
                AddRemovePucks(_AddRemove, ref normalPucksSelected, normalPucksText);
                break;
            case PuckType.WEIGHT:
                AddRemovePucks(_AddRemove, ref weightPucksSelected, weightPucksText);
                break;
            case PuckType.BIG:
                AddRemovePucks(_AddRemove, ref bigPucksSelected, bigPucksText);
                break;
        }
    }

    public void AddRemovePucks(bool _AddRemove, ref int _pucksSelected, TMP_Text _updateUI)
    {
        if (_AddRemove)
        {
            if (normalPucksSelected + weightPucksSelected + bigPucksSelected < maxPucks)
            {
                _pucksSelected++;
            }
            else { }
        }
        else
        {
            if (_pucksSelected > 1)
            {
                _pucksSelected--;
            }
        }
        _updateUI.text = _pucksSelected.ToString();
        UpdateConfirmButton();
    }

    public void UpdateConfirmButton()
    {
        if (normalPucksSelected + weightPucksSelected + bigPucksSelected < maxPucks)
            confirmButton.interactable = false;
        else
            confirmButton.interactable = true;
    }
}
