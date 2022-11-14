using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Resource01;
    public int Resource02;
    public int Resource03;
    public int Resource04;
    public int Resource05;

    public string Resource01Name;
    public string Resource02Name;
    public string Resource03Name;
    public string Resource04Name;
    public string Resource05Name;

    public Image ResourceBar01;
    public Image ResourceBar02;
    public Image ResourceBar03;
    public Image ResourceBar04;
    public Image ResourceBar05;
    public Text ResourceBar01Text;
    public Text ResourceBar02Text;
    public Text ResourceBar03Text;
    public Text ResourceBar04Text;
    public Text ResourceBar05Text;

    public Text MainBodyText;

    public Text ChoiceOneText;
    public Text ChoiceTwoText;


    public List<EventTemplate> eventList;


    private bool eventSet;
    private bool showAfter;
    private string OutcomeText;

    public GameObject Choises;
    public GameObject WordsImage;

    public bool PawnMoved;

    // Start is called before the first frame update
    void Start()
    {
        GenerateEventList();

        ResourceBar01Text.text = Resource01Name;
        ResourceBar02Text.text = Resource02Name;
        ResourceBar03Text.text = Resource03Name;
        ResourceBar04Text.text = Resource04Name;
        ResourceBar05Text.text = Resource05Name;
    }

    // Update is called once per frame
    void Update()
    {

        if (PawnMoved == false)
        {
            Choises.SetActive(false);
            WordsImage.SetActive(false);
        }
        else if (PawnMoved == true)
        {
            Choises.SetActive(true);
            WordsImage.SetActive(true);
        }
        ResourceBar01.fillAmount = Resource01 / 100.00f;
        ResourceBar02.fillAmount = Resource02 / 100.00f;
        ResourceBar03.fillAmount = Resource03 / 100f;
        ResourceBar04.fillAmount = Resource04 / 100f;
        ResourceBar05.fillAmount = Resource05 / 100f;

        if (eventSet && showAfter)
        {
            ShowEventAftermath();

        //hide button 1
        //change button 2 to ok

        }

        if (!eventSet && PawnMoved)
        {
            ShowEventData();
            eventSet = true;
        }

    }

    public void GenerateEventList()
    {
        //Grab the deck from somewhere and shuffle the contents into the list on the manager

    }

    public void ShowEventData()
    {
        ChoiceOneText.transform.parent.gameObject.SetActive(true);
        MainBodyText.text = eventList[0].Description;
        ChoiceOneText.text = eventList[0].Choice01;
        ChoiceTwoText.text = eventList[0].Choice02;

    }

    public void ShowEventAftermath()
    {
        MainBodyText.text = OutcomeText;
        ChoiceTwoText.text = "OK";
        ChoiceOneText.transform.parent.gameObject.SetActive(false);
    }

    public void ShowEndingAftermath()
    {

    }


    public void ChooseOne()
    {
        if(eventSet && !showAfter)
        {
            //do choice 1
            Resource01 += eventList[0].Resource01_C01;
            Resource02 += eventList[0].Resource02_C01;
            Resource03 += eventList[0].Resource03_C01;
            Resource04 += eventList[0].Resource04_C01;
            Resource05 += eventList[0].Resource05_C01;

            OutcomeText = eventList[0].Choice01_Outcome;

            showAfter = true;
        }
        else if(eventSet && showAfter)
        {
            // this is hidden
        }
    }
    public void ChooseTwo()
    {
        if (eventSet && !showAfter)
        {
            //do choice 2
            Resource01 += eventList[0].Resource01_C02;
            Resource02 += eventList[0].Resource02_C02;
            Resource03 += eventList[0].Resource03_C02;
            Resource04 += eventList[0].Resource04_C02;
            Resource05 += eventList[0].Resource05_C02;
            OutcomeText = eventList[0].Choice02_Outcome;
            showAfter = true;
        }
        else if (eventSet && showAfter)
        {
            // this is currently an ok button
            eventList.Remove(eventList[0]);

            //delete 
            showAfter = false;
            eventSet = false;
            PawnMoved = false;


        }
    }
}
