using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum PuckType
{
    NORMAL,
    WEIGHT,
    BIG
}

public class GamePuckBuilder : MonoBehaviour
{
    private int normalPucksSelected = 1;
    private int weightPucksSelected = 1;
    private int bigPucksSelected = 1;
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

    [Header("Type Of Pucks")]
    [SerializeField] private GameObject normalPuckPrefab;
    [SerializeField] private GameObject weightPuckPrefab;
    [SerializeField] private GameObject bigPuckPrefab;
    [Space]
    public int maxPucks = 7;
    public Transform[] puckSpawnPoints;
    private int puckSpawnIndex = 0;
    public UnityEvent pucksBuilded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //puckSpawnPoints = new Transform[maxPucks];

        addNormalPuck.onClick.AddListener(AddNormalPuck);
        removeNormalPuck.onClick.AddListener(RemoveNormalPuck);

        addWeightPuck.onClick.AddListener(AddWeightPuck);
        removeWeightPuck.onClick.AddListener(RemoveWeightPuck);

        addBigPuck.onClick.AddListener(AddBigPuck);
        removeBigPuck.onClick.AddListener(RemoveBigPuck);

        confirmButton.onClick.AddListener(Confirm);


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
    public void Confirm()
    {
        //Debug.Log("ho confermato e ho "+ maxPucks+ " Pucks ^^");
        for(int i = 0; i<normalPucksSelected; i++)
        {
            Instantiate(normalPuckPrefab, puckSpawnPoints[puckSpawnIndex].transform.position, Quaternion.identity);
            //Debug.Log("spawnati normal puck");
            puckSpawnIndex++;
        }
        for (int i = 0; i < weightPucksSelected; i++)
        {
            Instantiate(weightPuckPrefab, puckSpawnPoints[puckSpawnIndex].transform.position, Quaternion.identity);
            //Debug.Log("spawnati normal weight");
            puckSpawnIndex++;
        }
        for (int i = 0; i < bigPucksSelected; i++)
        {
            Instantiate(bigPuckPrefab, puckSpawnPoints[puckSpawnIndex].transform.position, Quaternion.identity);
            //Debug.Log("spawnati normal big");
            puckSpawnIndex++;
        }
        pucksBuilded.Invoke();
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
