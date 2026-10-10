using UnityEngine;
using System;

public class DiscordManager : MonoBehaviour
{
    public long applicationId = 1549152182052458587; 
    private Discord.Discord discord;
    private Discord.ActivityManager activityManager;

    void Start()
    {
        // Inizializza la connessione con l'app di Discord aperta sul PC
        discord = new Discord.Discord(applicationId, (UInt64)Discord.CreateFlags.NoRequireDiscord);
        activityManager = discord.GetActivityManager();
        
        // Corretto lo spazio nella chiamata qui sotto
        AggiornaPresenza("Nel Menu Principale", "Preparazione all'avventura");
    }

    void Update()
    {
        // Mantiene aggiornata la comunicazione con Discord a ogni frame
        if (discord != null)
        {
            discord.RunCallbacks();
        }
    }

    // CORRETTO: "statoAttuale" ora è tutto unito senza spazi
    public void AggiornaPresenza(string statoAttuale, string dettagli)
    {
        var activity = new Discord.Activity
        {
            State = statoAttuale,
            Details = dettagli,
            Assets = {
                LargeImage = "Reflections", // Assicurati che si chiami ESATTAMENTE così sul portale sviluppatori
                LargeText = "Deltarune Reflections" // Corretto il typo "Reflectiond"
            }
        };

        activityManager.UpdateActivity(activity, (res) => {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Stato di Discord aggiornato con successo!");
            }
        });
    }

    void OnApplicationQuit()
    {
        // Chiude la comunicazione in modo pulito quando si esce dal gioco
        if (discord != null)
        {
            discord.Dispose();
        }
    }
}