using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//this gets the car/bikes destroyed and add it to challenges and if it reach the threshold set then challenge is completed and claim button is set active 
// and it also check if the player has claimed the reward. if claimed the challenge is removed from the list.
public class ChallengeManager : MonoBehaviour
{
    [System.Serializable]
    public class Challenge
    {
        public string challengeName;
        public int threshold;
        public int currentProgress;
        public Button claimButton;
        public Slider progressSlider;
        public GameObject challenge;
        public int reward;
        public bool isRewardClaimed=false;
    }

    public List<Challenge> bikeChallenges;
    public List<Challenge> carChallenges;
    public List<Challenge> swatChallenges;

    private int bikeDestroyed;
    private int carDestroyed;
    private int swatDestroyed;

   public AudioSource audioSource;

    int cashCount;

    private void Start()
    {
        bikeDestroyed = PlayerPrefs.GetInt("BikeDestroyedCount", 0);
        carDestroyed = PlayerPrefs.GetInt("CarDestroyedCount", 0);
        swatDestroyed = PlayerPrefs.GetInt("SwatDestroyedCount", 0);

        
        

        foreach (var challenge in bikeChallenges)
        {
            challenge.isRewardClaimed = PlayerPrefs.GetInt(challenge.challengeName + "_isRewardClaimed", 0) == 1;
          
        }
        foreach (var challenge in carChallenges)
        {
            challenge.isRewardClaimed = PlayerPrefs.GetInt(challenge.challengeName + "_isRewardClaimed", 0) == 1;
        }
        foreach (var challenge in swatChallenges)
        {
            challenge.isRewardClaimed = PlayerPrefs.GetInt(challenge.challengeName + "_isRewardClaimed", 0) == 1;
        }
        BikeChallenge(bikeChallenges);
        CarChallenge(carChallenges);
        SwatChallenge(swatChallenges);

    }

    private void BikeChallenge(List<Challenge> challenges)
    {
        foreach (var challenge in challenges)
        {
            
            float value;
            value = (float)bikeDestroyed / (float)challenge.threshold;
            challenge.progressSlider.value = value;
            if (bikeDestroyed >= challenge.threshold)
            {
                if (challenge.isRewardClaimed)
                {
                    challenge.challenge.SetActive(false);
                    
                }
                challenge.claimButton.gameObject.SetActive(true);
               
                challenge.claimButton.onClick.AddListener(() => ClaimButtonClicked(challenge));
            }
            
        }
    }
    private void CarChallenge(List<Challenge> challenges)
    {
        foreach (var challenge in challenges)
        {
           
            float value;
            value = (float)carDestroyed / (float)challenge.threshold;
            challenge.progressSlider.value = value;
            if (carDestroyed >= challenge.threshold)
            {
                if (challenge.isRewardClaimed)
                {
                    challenge.challenge.SetActive(false);
                }
                challenge.claimButton.gameObject.SetActive(true);
               
                challenge.claimButton.onClick.AddListener(() => ClaimButtonClicked(challenge));
            }
            
        }
    }
    private void SwatChallenge(List<Challenge> challenges)
    {
        foreach (var challenge in challenges)
        {
            Debug.Log(challenge.challengeName + ":" + swatDestroyed);
            float value;
            value = (float)swatDestroyed / (float)challenge.threshold;
            challenge.progressSlider.value = value;
           
            if (swatDestroyed >= challenge.threshold)
            {
                if (challenge.isRewardClaimed)
                {
                    challenge.challenge.SetActive(false);
                }
                challenge.claimButton.gameObject.SetActive(true);
               
                challenge.claimButton.onClick.AddListener(() => ClaimButtonClicked(challenge));
            }
           
        }
    }

    private void ClaimButtonClicked(Challenge challenge)
    {
        audioSource.Play();
        int cashCount = PlayerPrefs.GetInt("CashCount", 0);
        cashCount = cashCount + challenge.reward;
        PlayerPrefs.SetInt("CashCount", cashCount);
        PlayerPrefs.Save();

        challenge.isRewardClaimed= true;
       

        PlayerPrefs.SetInt(challenge.challengeName + "_isRewardClaimed", 1);
        PlayerPrefs.Save();

        
        challenge.challenge.SetActive(false);
    }
}  
