# SpectraGuard-Unity-Vuforia

This project tests the functionality of the Vuforia Engine within Unity. Below are the key aspects of the project and instructions for setting up and running the project scenes.

## Project Overview

### Cbau
This scene contains the scanned Area Targets and augmented reality (AR) content placed at points of interest, such as rooms and fire alarms. A simple navigation system has been implemented, but there are still some bugs.

### Demo
For the demo, the university was scanned again because the room was set up differently.

## Setup Instructions

### Prerequisites
- Unity Hub
- Unity Editor (recommended version 2019.4 or higher)
- Vuforia Engine SDK

### Step-by-Step Guide

1. **Setting up the Vuforia Engine in Unity**

   Follow the tutorial provided by Vuforia to set up the Vuforia Engine in your Unity project:
   [Getting Started with Vuforia Engine in Unity](https://developer.vuforia.com/library/getting-started/getting-started-vuforia-engine-unity)

2. **Creating a New Unity Project**

   - Open Unity Hub.
   - Click on the `New` button to create a new project.
   - Choose the template (e.g., 3D) and name your project (e.g., SpectraGuard).
   - Click `Create` to open the new project in Unity.

3. **Importing Vuforia Engine**

   - In your Unity project, go to `Window > Package Manager`.
   - Click on the `+` button and select `Add package from git URL...`.
   - Enter the URL for the Vuforia Engine package: `https://github.com/Vuforia/vuforia-unity-package.git`.
   - Click `Add` to import the Vuforia Engine into your project.

4. **Importing the Cbau and Demo Scenes**

   - Download and extract the scene files.
   - In your Unity project, go to `Assets > Import Package > Custom Package...`.
   - Navigate to the location where you extracted the scene files and select the `Cbau.unitypackage` and `Demo.unitypackage` files to import them.
   - Ensure all assets are selected and click `Import`.

5. **Changing the Active Build Scene**

   - In the Unity Editor, go to `File > Build Settings`.
   - In the Build Settings window, locate the `Scenes In Build` section.
   - Click on `Add Open Scenes` to add the imported scenes to the build list.
   - Ensure that the `Cbau` scene is selected and click on the `Set Active` button to make it the active build scene.

6. **Running the Project**

   - Connect your device (if testing on a physical device).
   - Click on the `Play` button in the Unity Editor to run the project within the editor or build the project for your target platform using `File > Build Settings`.

### Additional Notes

- Feel free to edit or expand upon these instructions based on the specifics of your project.
- Ensure that you have the necessary permissions and licenses for using the Vuforia Engine in your project.
- If you encounter any issues with the navigation system or any other aspect of the project, refer to the Unity and Vuforia documentation for troubleshooting tips.

## Troubleshooting

- **Navigation System Bugs:** The navigation system in the Cbau scene has some bugs. Please review the scripts associated with the navigation and check for any logical errors or missing components.
- **Area Targets:** Ensure that the scanned Area Targets are correctly configured and that the AR content is placed accurately.

For further assistance, refer to the official documentation and community forums of Unity and Vuforia.

---

This README file provides a comprehensive guide to setting up and running the SpectraGuard-Unity-Vuforia project scenes. If you have any questions or need further assistance, feel free to reach out.
Contributers Osman Marangoz, Ghufran Bakarat, Rouven Bleich 
  








