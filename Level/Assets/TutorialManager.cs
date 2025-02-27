using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    [Header("----- Dialogue Box UI -----")]
    public GameObject dialogueBox;
    public TextMeshProUGUI objectiveName;
    public TextMeshProUGUI objectiveText;
    public GameObject beginButton;
    public GameObject completeButton;

    [Header("----- Objective Check UI -----")]
    public GameObject basicMoveUIObj;
    public GameObject advanceMoveUIObj;
    public GameObject inventoryUIObj;
    public GameObject meleeUIObj;
    public GameObject rangedUIObj;
    public Image[] basicMoveUI;
    public Image[] advanceMoveUI;
    public Image[] inventoryUI;
    public Image[] meleeUI;
    public Image[] rangedUI;

    [Header("----- Triggers -----")]
    public bool basicMoveTrigger;
    public bool advanceMoveTrigger;
    public bool inventoryTrigger;
    public bool meleeTrigger;
    public bool rangedTrigger;

    [Header("----- Objectives -----")]
    public GameObject basicPoint;
    public GameObject advancePoint;
    public GameObject inventoryPoint;
    public GameObject meleePoint;
    public GameObject rangedPoint;
    public GameObject nextPoint;

    [Header("----- Other -----")]
    public bool playerInRange;
    public GameObject skull;
    public int objectivesComplete;
    public int tutorialProgress;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        nextPoint = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialProgress == 0)
        {
            basicPoint.SetActive(true);
        }
        if (tutorialProgress == 1)
        {
            basicPoint.SetActive(false);
            advancePoint.SetActive(true);
        }
        if(tutorialProgress == 2)
        {
            advancePoint.SetActive(false);
            inventoryPoint.SetActive(true);
        }
    }

    public void Begin()
    {
        beginButton.SetActive(false);

        if (basicMoveTrigger)
        {
            basicMoveUIObj.SetActive(true);
            objectiveText.text = "Let's start with some basic movement! You can look around with your mouse and can move through the world using [W], [A], [S], [D]. Let's try it now!";
        }
        else if (advanceMoveTrigger && gameManager.instance.playerScript.enabled == true)
        {
            advanceMoveUIObj.SetActive(true);
            objectiveText.text = "Now let's take a look at some more " + '"' + "advanced" + '"' + " techniques. Use [SPACE] to Jump, Hold [SHIFT] while moving to sprint, and use [L-CTRL] to crouch";
        }
        else if (inventoryTrigger)
        {
            inventoryUIObj.SetActive(true);
            objectiveText.text = "Now go ahead and open your inventory by pressing [I]. Click the (+) in the corner of your ammo to equip it. It should now be in your active inventory. You can unequip from here with (-)";
        }
        else if (meleeTrigger)
        {
            meleeUIObj.SetActive(true);
            objectiveText.text = "Make sure your melee weapon is equipped by pressing [1]. Kill the enemies by lining up your reticle and pressing the [L-MOUSE BUTTON]";
        }
        else if (rangedTrigger)
        {
            rangedUIObj.SetActive(true);
            objectiveText.text = "Make sure your ranged weapon is equipped by pressing [2]. Kill the enemies by lining up your reticle and pressing the [L-MOUSE BUTTON]";
        }
    }

    public void Complete()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager.instance.cameraScript.enabled = true;

        if (tutorialProgress == 1)
        {
            completeButton.SetActive(false);
            basicMoveUIObj.SetActive(false);
            basicMoveTrigger = false;
            objectiveText.text = "Looks like your sea legs are land legs! Find me up a ways for your next lesson!";
            nextPoint.transform.position = advancePoint.transform.position;
        }
        if(tutorialProgress == 2)
        {
            completeButton.SetActive(false);
            advanceMoveUIObj.SetActive(false);
            advanceMoveTrigger = false;
            objectiveText.text = "Now that you know how to move, take a stroll over to your new ship and give it a shot. The controls are the same! Head to Chicken Head Enclave for your first clue.";
            nextPoint.transform.position = inventoryPoint.transform.position;
        }
        /*if (tutorialProgress == 3)
        {
            completeButton.SetActive(false);
            inventoryUIObj.SetActive(false);
            inventoryTrigger = false;
            objectiveText.text = "Now that you know how to stock yourself up, let's get prepared for some action!";
            nextPoint.transform.position = meleePoint.transform.position;
        }
        if(tutorialProgress == 4)
        {
            meleeUIObj.SetActive(false);
            objectiveText.text = "That was a swing and a hit, but perhaps a little close for comfort. Let's move onto some ranged attacks.";
        }
        if(tutorialProgress == 5)
        {
            objectiveText.text = "You're quite the sharpshooter! And with that, we're near the end of our lessons! Now that you've humored me, perhaps I can give you a hand. Come find me and I'll tell you what I know!";
        }*/

        StartCoroutine(CleanUp());
    }
    public IEnumerator CleanUp()
    {   
        objectivesComplete = 0;
        yield return new WaitForSeconds(4.5f);
        dialogueBox.SetActive(false);
        skull.SetActive(false);
        yield return new WaitForSeconds(2f);
        skull.transform.position = new Vector3(nextPoint.transform.position.x, nextPoint.transform.position.y, nextPoint.transform.position.z);
        skull.SetActive(true);
    }
}
