using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
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
    public Button addNormalPuck;
    public Button removeNormalPuck;
    public Button addWeightPuck;
    public Button removeWeightPuck;
    public Button addBigPuck;
    public Button removeBigPuck;

    public Button confirmButton;
    [Header("TMP_Text")]
    public TMP_Text normalPucksText;
    public TMP_Text weightPucksText;
    public TMP_Text bigPucksText;

    [Header("Type Of Pucks")]
    public GameObject normalPuckPrefab;
    public GameObject weightPuckPrefab;
    public GameObject bigPuckPrefab;

    public int maxPucks = 7;
    public Transform[] puckSpawnPoints;
    private int puckSpawnIndex = 0;

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
            Instantiate(normalPuckPrefab, puckSpawnPoints[i].transform.position, Quaternion.identity);
            puckSpawnIndex++;
        }
        for (int i = 0; i < weightPucksSelected; i++)
        {
            Instantiate(weightPuckPrefab, puckSpawnPoints[i].transform.position, Quaternion.identity);
            puckSpawnIndex++;
        }
        for (int i = 0; i < bigPucksSelected; i++)
        {
            Instantiate(bigPuckPrefab, puckSpawnPoints[i].transform.position, Quaternion.identity);
            puckSpawnIndex++;
        }
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
