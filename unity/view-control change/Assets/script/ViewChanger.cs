using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class ViewChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public static ViewChanger Instance;

    [SerializeField] private List<GameObject> PlayerListe;
    [SerializeField] private  CinemachineFreeLook Cam;
    internal GameObject Player;
    private float Xaxis = 0;
    playerScript PlayerScript;
    private int currentIndex = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Xaxis = Cam.m_XAxis.Value;

        //start selectionne le premier joueur et met le focus a true
        Player = PlayerListe[currentIndex];                     //associe l'index du joueur en cours au joueur
        PlayerScript = Player.GetComponent<playerScript>();     //get les script playerscript du joueur
        PlayerScript.focus = true;                              //set le focus du joueur a true
    }

    // Update is called once per frame
    void Update()
    {   
        //set le joueur au joueur en cour
        Player = PlayerListe[currentIndex];

        //set les cible pour la camera
        Cam.Follow = Player.transform;
        Cam.LookAt = Player.transform;

        //get X axis form the cam
        Xaxis = Cam.m_XAxis.Value;
    }

    public void ChangerFocus()
    {
        if(currentIndex == PlayerListe.Count-1) //si on est rendue au max de la liste la reset
        {
            //reset l'index
            currentIndex = 0;
            
            //set le focus off du dernier joueur avec le focus
            LastFocusPlayer(true);
        }
        else
        {
            //augemente l'index
            currentIndex++;

            //set le focus off du dernier joueur avec le focus
            LastFocusPlayer(false);
        }
        //set a on le focus du player actuel    
        Player = PlayerListe[currentIndex];                      //associe l'index du joueur en cours au joueur
        PlayerScript = Player.GetComponent<playerScript>();      //get les script playerscript du joueur
        PlayerScript.focus = true;                               //set le focus du joueur a true
    }

    private void LastFocusPlayer(bool reset)
    {
        if(reset)
        {
            //set a off le focus du dernier dans la liste
            Player = PlayerListe[PlayerListe.Count - 1];            //associe l'index du joueur en cours au joueur
            PlayerScript = Player.GetComponent<playerScript>();     //get les script playerscript du joueur
            PlayerScript.focus = false;                             //set le focus du joueur a false
        }
        else
        {
            //set a off le focus de dernier focus   
            Player = PlayerListe[currentIndex - 1];                 //associe l'index du joueur en cours au joueur
            PlayerScript = Player.GetComponent<playerScript>();     //get les script playerscript du joueur
            PlayerScript.focus = false;                             //set le focus du joueur a false
        }
    }

    public float GetXAxis()
    { return Xaxis; }
}
