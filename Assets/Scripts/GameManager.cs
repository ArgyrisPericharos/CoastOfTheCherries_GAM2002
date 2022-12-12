using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public DeckTemplate starterDeck;
    //starter deck
    public DeckTemplate AddedDeckResource10;
    public DeckTemplate AddedDeckResource1100;
    public DeckTemplate AddedDeckResource175;
    public DeckTemplate AddedDeckResource125;
    //recourse 1 decks at 0, 25, 75 and 100;

    public DeckTemplate AddedDeckResource20;
    public DeckTemplate AddedDeckResource2100;
    public DeckTemplate AddedDeckResource275;
    public DeckTemplate AddedDeckResource225;
    //recourse 2 decks at 0, 25, 75 and 100;

    public DeckTemplate AddedDeckResource30;
    public DeckTemplate AddedDeckResource3100;
    public DeckTemplate AddedDeckResource375;
    public DeckTemplate AddedDeckResource325;
    //recourse 3 decks at 0, 25, 75 and 100;

    public DeckTemplate AddedDeckResource40;
    public DeckTemplate AddedDeckResource4100;
    public DeckTemplate AddedDeckResource475;
    public DeckTemplate AddedDeckResource425;
    //recourse 4 decks at 0, 25, 75 and 100;

    public DeckTemplate AddedDeckResource50;
    public DeckTemplate AddedDeckResource5100;
    public DeckTemplate AddedDeckResource575;
    public DeckTemplate AddedDeckResource525;
    //recourse 5 decks at 0, 25, 75 and 100;


    public List<DeckTemplate> availableDecks;
    public List<DeckTemplate> HotspotsDecks;

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
    public Text ChoiceThreeText;

    public bool Huntsman;
    public bool Revolutionairy;

    public bool HuntsmanCheck;
    public bool RevoCheck;

    public GameObject RevoPawn;
    public GameObject HuntsPawn;

    public Transform SpawnPosition;


    public List<EventTemplate> eventList;
    public List<EventTemplate> HotspotList;


    private bool eventSet;
    private bool showAfter;
    private bool endGame;
    private string OutcomeText;
    private string EndingText;

    public GameObject Choises;
    public GameObject WordsImage;

    public bool PawnMoved;

    public bool AddDeckResource10;
    public bool AddDeckResource1100;
    public bool AddDeckResource175;
    public bool AddDeckResource125;
    // boolean for recource 1 checks. Will also use them for caps.

    public bool AddDeckResource20;
    public bool AddDeckResource2100;
    public bool AddDeckResource275;
    public bool AddDeckResource225;
    // boolean for recource 2 checks. Will also use them for caps.

    public bool AddDeckResource30;
    public bool AddDeckResource3100;
    public bool AddDeckResource375;
    public bool AddDeckResource325;
    // boolean for recource 3 checks. Will also use them for caps.

    public bool AddDeckResource40;
    public bool AddDeckResource4100;
    public bool AddDeckResource475;
    public bool AddDeckResource425;
    // boolean for recource 4 checks. Will also use them for caps.

    public bool AddDeckResource50;
    public bool AddDeckResource5100;
    public bool AddDeckResource575;
    public bool AddDeckResource525;
    // boolean for recource 5 checks. Will also use them for caps.
    public bool NormalEvent;
    public bool FixareaEvent;

    public HotSpot hotspotScript;

    public bool HotSpot5event;
    public bool savedforlaterfor5;

    // Start is called before the first frame update
    void Start()
    {
         
        Huntsman = false;
        Revolutionairy = false;
        
        HuntsmanCheck = false;
        RevoCheck = false;

        AddDeckResource10 = false;
        AddDeckResource1100 = false;
        AddDeckResource175 = false;
        AddDeckResource125 = false;

        AddDeckResource20 = false;
        AddDeckResource2100 = false;
        AddDeckResource275 = false;
        AddDeckResource225 = false;

        AddDeckResource30 = false;
        AddDeckResource3100 = false;
        AddDeckResource375 = false;
        AddDeckResource325 = false;

        AddDeckResource40 = false;
        AddDeckResource4100 = false;
        AddDeckResource475 = false;
        AddDeckResource425 = false;

        AddDeckResource50 = false;
        AddDeckResource5100 = false;
        AddDeckResource575 = false;
        AddDeckResource525 = false;

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

        /*if (!eventSet && PawnMoved)
        {
            ShowEventData();
            eventSet = true;
        }
        */


        if (!AddDeckResource10 && Resource01 < 1)
        {
            foreach (EventTemplate eventCard in AddedDeckResource10.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource10 = true;

        }

        if (!AddDeckResource1100 && Resource01 >= 100)
        {
            foreach (EventTemplate eventCard in AddedDeckResource1100.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource1100 = true;

        }
        if (!AddDeckResource175 && Resource01 >= 75)
        {
            foreach (EventTemplate eventCard in AddedDeckResource175.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource175 = true;

        }
        if (!AddDeckResource125 && Resource01 <= 25)
        {
            foreach (EventTemplate eventCard in AddedDeckResource125.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource125 = true;

        }

        if (!AddDeckResource20 && Resource02 < 1)
        {
            foreach (EventTemplate eventCard in AddedDeckResource20.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource20 = true;

        }

        if (!AddDeckResource2100 && Resource02 >= 100)
        {
            foreach (EventTemplate eventCard in AddedDeckResource2100.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource2100 = true;

        }
        if (!AddDeckResource275 && Resource02 >= 75)
        {
            foreach (EventTemplate eventCard in AddedDeckResource275.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource275 = true;

        }
        if (!AddDeckResource225 && Resource02 <= 25)
        {
            foreach (EventTemplate eventCard in AddedDeckResource225.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource225 = true;

        }


        if (!AddDeckResource30 && Resource03 < 1)
        {
            foreach (EventTemplate eventCard in AddedDeckResource30.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource30 = true;

        }

        if (!AddDeckResource3100 && Resource03 >= 100)
        {
            foreach (EventTemplate eventCard in AddedDeckResource3100.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource3100 = true;

        }
        if (!AddDeckResource375 && Resource03 >= 75)
        {
            foreach (EventTemplate eventCard in AddedDeckResource375.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource375 = true;

        }
        if (!AddDeckResource325 && Resource03 <= 25)
        {
            foreach (EventTemplate eventCard in AddedDeckResource325.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource325 = true;

        }

        if (!AddDeckResource40 && Resource04 < 1)
        {
            foreach (EventTemplate eventCard in AddedDeckResource40.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource40 = true;

        }

        if (!AddDeckResource4100 && Resource04 >= 100)
        {
            foreach (EventTemplate eventCard in AddedDeckResource4100.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource4100 = true;

        }
        if (!AddDeckResource475 && Resource04 >= 75)
        {
            foreach (EventTemplate eventCard in AddedDeckResource475.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource475 = true;

        }
        if (!AddDeckResource425 && Resource04 <= 25)
        {
            foreach (EventTemplate eventCard in AddedDeckResource425.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource425 = true;

        }

        if (!AddDeckResource50 && Resource05 < 1)
        {
            foreach (EventTemplate eventCard in AddedDeckResource50.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource50 = true;

        }

        if (!AddDeckResource5100 && Resource05 >= 100)
        {
            foreach (EventTemplate eventCard in AddedDeckResource5100.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource5100 = true;

        }
        if (!AddDeckResource575 && Resource05 >= 75)
        {
            foreach (EventTemplate eventCard in AddedDeckResource575.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource575 = true;

        }
        if (!AddDeckResource525 && Resource05 <= 25)
        {
            foreach (EventTemplate eventCard in AddedDeckResource525.EventDeck)
            {
                eventList.Add(eventCard);

            }
            shuffleEventList();

            AddDeckResource525 = true;

        }

        if (Revolutionairy == true)
        {
            RevoCheck = true;
        }

        if (Huntsman == true)
        {
            HuntsmanCheck = true;
        }

        if (HuntsmanCheck == true)
        {
            HuntsPawn.SetActive(true);
        }

        if (RevoCheck == true)
        {
            RevoPawn.SetActive(true);
        }

        /*
        if ((Revolutionairy == true) && (RevoCheck == true)) 
        {
            Instantiate(RevoPrefab, SpawnPosition);
            RevoPrefab.transform.position = SpawnPosition.transform.position;
            RevoCheck = false;
        }

        if ((Huntsman == true) && (HuntsmanCheck == true)) 
        {
            Instantiate(HuntsPrefab, SpawnPosition);
            HuntsPrefab.transform.position = SpawnPosition.transform.position;
            HuntsmanCheck = false;
        }
        */

    }

    public void GenerateEventList()
    {
        //Grab the deck from somewhere and shuffle the contents into the list on the manager
        //reset the flags
        endGame = false;
        showAfter = false;
        eventSet = false;
        //Grab the deck from somewhere and shuffle the contents into the list on the manager
        //
        //eventList = starterDeck.EventDeck;
        foreach (EventTemplate eventCard in starterDeck.EventDeck)
        {
            eventList.Add(eventCard);
        }

       

        //shuffle
        shuffleEventList();

    }


    public void PawnArrivalSpot(HotSpot Mycurrenthotspotarrived)
    {
        hotspotScript = Mycurrenthotspotarrived;
        if (Mycurrenthotspotarrived.hsName == "hotspot1")
        {
            FixareaEvent = true;
            NormalEvent = false;
            showAfter = false;
            

            ChoiceOneText.transform.parent.gameObject.SetActive(true);
            ChoiceThreeText.transform.parent.gameObject.SetActive(false);

            foreach (DeckTemplate currentDeck in HotspotsDecks)
            {
                if (currentDeck.DeckDescription == "hotspot1 Deck")
                {
                    eventSet = true;

                    MainBodyText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Description;
                    ChoiceOneText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Choice01;
                    ChoiceTwoText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Choice02;

                    //HotspotList = currentDeck.EventDeck;

                    foreach (EventTemplate eventCard in currentDeck.EventDeck)
                    {
                        HotspotList.Add(eventCard);
                    }



                }
            }
        }
        else if (!eventSet && PawnMoved)
        {
            NormalEvent = true;
            FixareaEvent = false;
            ShowEventData();
            eventSet = true;
        }

        if (Mycurrenthotspotarrived.hsName == "hotspot2")
        {
            FixareaEvent = true;
            NormalEvent = false;
            showAfter = false;
            

            ChoiceOneText.transform.parent.gameObject.SetActive(true);
            ChoiceThreeText.transform.parent.gameObject.SetActive(false);

            foreach (DeckTemplate currentDeck in HotspotsDecks)
            {
                if (currentDeck.DeckDescription == "hotspot2 Deck")
                {
                    eventSet = true;
                    // GenereateHotspotList(currentDeck);
                    // HotspotShowData(Mycurrenthotspotarrived.progressNumber);

                    MainBodyText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Description;
                    ChoiceOneText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Choice01;
                    ChoiceTwoText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Choice02;

                    //HotspotList = currentDeck.EventDeck;

                    foreach (EventTemplate eventCard in currentDeck.EventDeck)
                    {
                        HotspotList.Add(eventCard);
                    }

                }
            }
        }
        else if (!eventSet && PawnMoved)
        {
            FixareaEvent = false;
            NormalEvent = true;
            ShowEventData();
            eventSet = true;
        }

        if (Mycurrenthotspotarrived.hsName == "hotspot5")
        {
            FixareaEvent = false;
            NormalEvent = false;
            showAfter = false;
            HotSpot5event = true;


            ChoiceOneText.transform.parent.gameObject.SetActive(true);
            ChoiceThreeText.transform.parent.gameObject.SetActive(true);

            foreach (DeckTemplate currentDeck in HotspotsDecks)
            {
                if (currentDeck.DeckDescription == "hotspot5 Deck")
                {
                    eventSet = true;

                    MainBodyText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Description;
                    ChoiceOneText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Choice01;
                    ChoiceTwoText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Choice02;
                    ChoiceThreeText.text = currentDeck.EventDeck[Mycurrenthotspotarrived.progressNumber].Choice03;

                    //HotspotList = currentDeck.EventDeck;

                    foreach (EventTemplate eventCard in currentDeck.EventDeck)
                    {
                        HotspotList.Add(eventCard);
                    }



                }
            }
        }
        else if (!eventSet && PawnMoved)
        {
            NormalEvent = true;
            FixareaEvent = false;
            ShowEventData();
            eventSet = true;
        }
    }
    /*
    public void GenereateHotspotList(DeckTemplate currentDeck)
    {
        //empty the list first?

        foreach (EventTemplate eventCard in currentDeck.EventDeck)
        {
            HotspotList.Add(eventCard);
        }
    }
    */
    /*public void HotspotShowData(int progressNumber)
    {
        MainBodyText.text = HotspotList[progressNumber].Description;
        ChoiceOneText.text = HotspotList[progressNumber].Choice01;
        ChoiceTwoText.text = HotspotList[progressNumber].Choice02;
    }
    */
    public void ShowEventData()
    {

        if (eventList.Count < 1)
        {
            EndingText = "No More Cards!";
            endGame = true;
        }
        else
        {
            ChoiceThreeText.transform.parent.gameObject.SetActive(false);
            ChoiceOneText.transform.parent.gameObject.SetActive(true);
            MainBodyText.text = eventList[0].Description;
            ChoiceOneText.text = eventList[0].Choice01;
            ChoiceTwoText.text = eventList[0].Choice02;

        }

    }

    public void ShowEventAftermath()
    {
        MainBodyText.text = OutcomeText;
        ChoiceTwoText.text = "Okay";
        ChoiceOneText.transform.parent.gameObject.SetActive(false);
        ChoiceThreeText.transform.parent.gameObject.SetActive(false);
    }

    public void ShowEndingAftermath()
    {

    }


    public void ChooseOne()
    {
        if((NormalEvent == true) &&(FixareaEvent == false))
        {
            ChoiceOneNorm();
        }

        if ((NormalEvent == false) && (FixareaEvent == true))
        {
            ChoiceOneFix();
        }
        if ((HotSpot5event == true) && (NormalEvent == false) && (FixareaEvent == false))
        {
            ChoiceOneFor5();
        }

    }

    public void ChooseThree()
    {
        if ((FixareaEvent == false) && (NormalEvent == false))
        {
            ChoiceThreeFor5();
        }
        else 
            ChoiceThreeText.transform.parent.gameObject.SetActive(false);
    }

    public void ChooseTwo()
    {
        if ((NormalEvent == true) && (FixareaEvent == false))
        {
            ChoiceTwoNorm();
        }

        if ((NormalEvent == false) && (FixareaEvent == true))
        {
            ChoiceTwoFix();
        }
        if ((HotSpot5event == true) && (NormalEvent == false) && (FixareaEvent == false))
        {
            ChoiceTwoFor5();
        }


        /*  if (eventSet && !showAfter)
          {
              //do choice 2
              Resource01 += eventList[0].Resource01_C02;
              Resource02 += eventList[0].Resource02_C02;
              Resource03 += eventList[0].Resource03_C02;
              Resource04 += eventList[0].Resource04_C02;
              Resource05 += eventList[0].Resource05_C02;
              OutcomeText = eventList[0].Choice02_Outcome;

              Resource01 += HotspotList[0].Resource01_C02;
              Resource02 += HotspotList[0].Resource02_C02;
              Resource03 += HotspotList[0].Resource03_C02;
              Resource04 += HotspotList[0].Resource04_C02;
              Resource05 += HotspotList[0].Resource05_C02;

              OutcomeText = HotspotList[0].Choice01_Outcome;
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
        */
    }

    public void ChoiceOneNorm()
    {
        if (eventSet && !showAfter)
        {
            //do choice 1
            Resource01 += eventList[0].Resource01_C01;
            Resource02 += eventList[0].Resource02_C01;
            Resource03 += eventList[0].Resource03_C01;
            Resource04 += eventList[0].Resource04_C01;
            Resource05 += eventList[0].Resource05_C01;

            Huntsman = eventList[0].Huntsman;

            OutcomeText = eventList[0].Choice01_Outcome;


            showAfter = true;
            
        }
        else if (eventSet && showAfter)
        {
            // this is hidden
        }
    }

    public void ChoiceOneFix()
    {
   
        if (eventSet && !showAfter)
        {
            Resource01 += HotspotList[hotspotScript.progressNumber].Resource01_C01;
            Resource02 += HotspotList[hotspotScript.progressNumber].Resource02_C01;
            Resource03 += HotspotList[hotspotScript.progressNumber].Resource03_C01;
            Resource04 += HotspotList[hotspotScript.progressNumber].Resource04_C01;
            Resource05 += HotspotList[hotspotScript.progressNumber].Resource05_C01;

            OutcomeText = HotspotList[hotspotScript.progressNumber].Choice01_Outcome;

            showAfter = true;
            eventSet = true;

        }
        else if (eventSet && showAfter)
        {
            // this is hidden
        }

    }

    public void ChoiceOneFor5()
    {

        if ((eventSet && !showAfter) && (Resource01 >= 75))
        {
            Resource01 += HotspotList[hotspotScript.progressNumber].Resource01_C01;
            Resource02 += HotspotList[hotspotScript.progressNumber].Resource02_C01;
            Resource03 += HotspotList[hotspotScript.progressNumber].Resource03_C01;
            Resource04 += HotspotList[hotspotScript.progressNumber].Resource04_C01;
            Resource05 += HotspotList[hotspotScript.progressNumber].Resource05_C01;

            OutcomeText = HotspotList[hotspotScript.progressNumber].Choice01_Outcome;

            showAfter = true;
            eventSet = true;
            savedforlaterfor5 = false;

        }
        else if (eventSet && showAfter)
        {
            // this is hidden
        }

    }

    public void ChoiceTwoNorm()
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

           Huntsman = eventList[0].Huntsman;
           Revolutionairy = eventList[0].Revolutionairy;

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

    public void ChoiceTwoFix()
    {
        if (eventSet && !showAfter)
        {

            Resource01 += HotspotList[hotspotScript.progressNumber].Resource01_C02;
            Resource02 += HotspotList[hotspotScript.progressNumber].Resource02_C02;
            Resource03 += HotspotList[hotspotScript.progressNumber].Resource03_C02;
            Resource04 += HotspotList[hotspotScript.progressNumber].Resource04_C02;
            Resource05 += HotspotList[hotspotScript.progressNumber].Resource05_C02;

            Huntsman = HotspotList[hotspotScript.progressNumber].Huntsman;
            Revolutionairy = HotspotList[hotspotScript.progressNumber].Revolutionairy;

            OutcomeText = HotspotList[hotspotScript.progressNumber].Choice02_Outcome;

            savedforlaterfor5 = false;
            showAfter = true;
            eventSet = true;
        }
        else if (showAfter)
        {
            // this is currently an ok button
            //eventList.Remove(HotspotList[0]);
            hotspotScript.GetComponent<HotSpot>().progressNumber++;

            HotspotList.Clear();

            //remove deck from hotspotList so the deck can be reused

            //delete 
            showAfter = false;
            eventSet = false;

            PawnMoved = false;

            


        }
    }


    public void ChoiceTwoFor5()
    {
        if ((eventSet && !showAfter) && (Resource02 >= 75))
        {

            Resource01 += HotspotList[hotspotScript.progressNumber].Resource01_C02;
            Resource02 += HotspotList[hotspotScript.progressNumber].Resource02_C02;
            Resource03 += HotspotList[hotspotScript.progressNumber].Resource03_C02;
            Resource04 += HotspotList[hotspotScript.progressNumber].Resource04_C02;
            Resource05 += HotspotList[hotspotScript.progressNumber].Resource05_C02;

            Huntsman = HotspotList[hotspotScript.progressNumber].Huntsman;
            Revolutionairy = HotspotList[hotspotScript.progressNumber].Revolutionairy;

            OutcomeText = HotspotList[hotspotScript.progressNumber].Choice02_Outcome;

            showAfter = true;
            eventSet = true;
        }
        else if (showAfter)
        {
            // this is currently an ok button
            //eventList.Remove(HotspotList[0]);
            if (savedforlaterfor5)
            {
                HotspotList.Clear();
            }
            else if (savedforlaterfor5 == false)
            {
                hotspotScript.GetComponent<HotSpot>().progressNumber++;
                HotspotList.Clear();
            }

            //remove deck from hotspotList so the deck can be reused

            //delete 
            showAfter = false;
            eventSet = false;

            PawnMoved = false;
        }
    }

    public void ChoiceThreeFor5()
    {
        if (eventSet && !showAfter)
        {
            OutcomeText = HotspotList[hotspotScript.progressNumber].Choice03_Outcome;

            savedforlaterfor5 = true;
            showAfter = true;
            eventSet = true;

        }
        else if (eventSet && showAfter)
        {
            // this is hidden
        }
    }
    void shuffleEventList()
    {
        for (int i = 0; i < eventList.Count; i++)
        {
            EventTemplate temp = eventList[i];
            int RandomIndex = Random.Range(i, eventList.Count);
            eventList[i] = eventList[RandomIndex];
            eventList[RandomIndex] = temp;
        }
    }

    void GenerateFileList()
    {

    }
}
