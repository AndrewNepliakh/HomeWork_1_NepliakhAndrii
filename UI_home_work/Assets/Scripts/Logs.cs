using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Logs : MonoBehaviour
{
   [SerializeField] private TMP_Dropdown _resolutionDropdown;
   [SerializeField] private TMP_Dropdown _qualityDropdown;
   
   [SerializeField] private Toggle _fullscreenToggle;
   [SerializeField] private Toggle _soundInBackgroundToggle;
   [SerializeField] private Toggle _enableChallengeToggle;
   [SerializeField] private Toggle _allowFriendsToggle;
   
   [SerializeField] private Slider _masterVolumeSlider;
   [SerializeField] private Slider _musicVolumeSlider;
   
   [SerializeField] private Button _creditsButton;
   [SerializeField] private Button _cinematicButton;

   private void Start()
   {
      _resolutionDropdown.onValueChanged.AddListener(OnResolutionDropdownHandler);
      _qualityDropdown.onValueChanged.AddListener(OnQualityDropdownHandler);
      
      _fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggleHandler);
      _soundInBackgroundToggle.onValueChanged.AddListener(OnSoundInBackgroundToggleHandler);
      _enableChallengeToggle.onValueChanged.AddListener(OnEnableChallengeToggleHandler);
      _allowFriendsToggle.onValueChanged.AddListener(OnAllowFriendsToggleHandler);
      
      _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeSliderHandler);
      _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeSliderHandler);
      
      _creditsButton.onClick.AddListener(OnCreditsButtonHandler);
      _cinematicButton.onClick.AddListener(OnCinematicButtonHandler);
   }

   private void OnDestroy()
   {
      _resolutionDropdown.onValueChanged.RemoveListener(OnResolutionDropdownHandler);
      _qualityDropdown.onValueChanged.RemoveListener(OnQualityDropdownHandler);
      
      _fullscreenToggle.onValueChanged.RemoveListener(OnFullscreenToggleHandler);
      _soundInBackgroundToggle.onValueChanged.RemoveListener(OnSoundInBackgroundToggleHandler);
      _enableChallengeToggle.onValueChanged.RemoveListener(OnEnableChallengeToggleHandler);
      _allowFriendsToggle.onValueChanged.RemoveListener(OnAllowFriendsToggleHandler);
      
      _masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeSliderHandler);
      _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeSliderHandler);
      
      _creditsButton.onClick.RemoveListener(OnCreditsButtonHandler);
      _cinematicButton.onClick.RemoveListener(OnCinematicButtonHandler);
   }

   private void OnResolutionDropdownHandler(int arg0) => Debug.Log("Resolution dropdown: option " + arg0);
   
   private void OnQualityDropdownHandler(int arg0)  => Debug.Log("Quality dropdown: option " + arg0);
   
   private void OnFullscreenToggleHandler(bool arg0) => Debug.Log("Full screen toggle: condition " + arg0);
   
   private void OnSoundInBackgroundToggleHandler(bool arg0) => Debug.Log("Sound in background toggle: condition " + arg0);
   
   private void OnEnableChallengeToggleHandler(bool arg0) => Debug.Log("Enable challenge toggle: condition " + arg0);
   
   private void OnAllowFriendsToggleHandler(bool arg0) => Debug.Log("Allow friends toggle: condition " + arg0);
   
   private void OnMasterVolumeSliderHandler(float arg0) => Debug.Log("Master volume slider: value " + arg0);
   
   private void OnMusicVolumeSliderHandler(float arg0) => Debug.Log("Music volume slider: value " + arg0);
   
   private void OnCreditsButtonHandler() => Debug.Log("Credits button: was clicked");
   
   private void OnCinematicButtonHandler() => Debug.Log("Cinematic button: was clicked");
 
   

}
