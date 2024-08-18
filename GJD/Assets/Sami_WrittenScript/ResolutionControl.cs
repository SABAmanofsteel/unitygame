using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutionList;

    float currentRefreshRate;
    int currentResolutionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutionList = new List<Resolution>();
        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;
        for(int i =  0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutionList.Add(resolutions[i]); 

            }
        }

        List<string> options = new List<string>();  
        for(int i = 0;i < filteredResolutionList.Count;i++)
        {
            string resolutionOption = filteredResolutionList[i].width + "x" + filteredResolutionList[i].height + " " + filteredResolutionList[i].refreshRate + "Hz";
            options.Add(resolutionOption);
            if (filteredResolutionList[i].width == Screen.width && filteredResolutionList[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutionList[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, true);
    }
}
