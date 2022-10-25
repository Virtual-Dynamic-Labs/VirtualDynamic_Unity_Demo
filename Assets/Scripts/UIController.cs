using MoralisUnity;
using MoralisUnity.Kits.AuthenticationKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoralisUnity.Demos.Introduction
{
    public class UIController : MonoBehaviour
    {

        [SerializeField]
        private GameObject authenticationKitObject = null;

        [SerializeField]
        private GameObject signedInUiObject = null;

        [SerializeField]
        private GameObject fireworksObject = null;

        private AuthenticationKit authKit = null;

        private void Start()
        {
            authKit = authenticationKitObject.GetComponent<AuthenticationKit>();
        }

        public void Authentication_OnConnect()
        {
            authenticationKitObject.SetActive(false);
            signedInUiObject.SetActive(true);
            fireworksObject.SetActive(true);
        }

        public void LogoutButton_OnClicked()
        {
            // Logout the Moralis User.
            authKit.Disconnect();

            authenticationKitObject.SetActive(true);
            signedInUiObject.SetActive(false);
            fireworksObject.SetActive(false);
        }

        public void ContinueButton_OnClick()
        {
            authenticationKitObject.SetActive(false);
            signedInUiObject.SetActive(false);
            fireworksObject.SetActive(false);

            SceneManager.LoadScene("Playground");
        }
    }
}
