using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using Unity.Services.Authentication.PlayerAccounts;
using UnityEngine.UI;
using Unity.VisualScripting;


namespace ABS_SaveLoadSystem
{
    public class AuthenticationManager : MonoBehaviour
    {


        public event Action<PlayerInfo, string> OnSignedIn;
        public PlayerInfo playerInfo;



        public async void LoginButtonPressed()
        {
            await InitSignIn();
        }

        async void Awake()
        {

            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            PlayerAccountService.Instance.SignedIn += SignedIn;
        }

        private async void SignedIn()
        {
            try
            {
                var accessToken = PlayerAccountService.Instance.AccessToken;
                await SignInWithUnityAsync(accessToken);

                Debug.Log("Finished Sign in async.");
            }
            catch (Exception e)
            {

            }
        }

        public async Task InitSignIn()
        {
            await PlayerAccountService.Instance.StartSignInAsync();
        }

        async Task SignInWithUnityAsync(string accessToken)
        {
            try
            {
                await AuthenticationService.Instance.SignInWithUnityAsync(accessToken);
                Debug.Log("SignIn is successful.");

                playerInfo = AuthenticationService.Instance.PlayerInfo;
                var name = await AuthenticationService.Instance.GetPlayerNameAsync();
                OnSignedIn?.Invoke(playerInfo, name);


                //TODO MOVE TO OTHR FUNCTION
                Debug.Log("Loading Player Data");
                await PlayerManager.saveLoadManager.LoadAllPlayerDataAsync();
                Debug.Log("Loading Scene...");
                var sceneLoadOperation = SceneManager.LoadSceneAsync("MainScene");
                while (!sceneLoadOperation.isDone)
                {
                    Debug.Log($"Loading Progress: {sceneLoadOperation.progress * 100}%");
                    await Task.Yield(); // Ensure the main thread remains responsive
                }

                Debug.Log("Scene Loaded Successfully.");
            }
            catch (AuthenticationException ex)
            {

                Debug.LogException(ex);
            }
            catch (RequestFailedException ex)
            {

                Debug.LogException(ex);
            }
        }


        private void OnDestroy()
        {
            PlayerAccountService.Instance.SignedIn -= SignedIn;
        }
    }
}