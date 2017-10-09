# [OUTDATED] This project can not be used with the latest Watson SDK!
## Using Watson Speech-To-Text in Unity
### Made by Sophie Mai Chau

![alt text](https://github.com/sophiemaichau/SpeechToText/blob/master/img/img.png)


#Tutorial part 1 (set up in Unity)
1. Clone project
2. Open project in Unity
3. Make sure you have 'Watson' in your menu bar
![alt text](https://github.com/sophiemaichau/SpeechToText/blob/master/img/watson.png)
3.1 If 'Watson' doesn't appear in the menu bar: <br />
3.2 Download Watson SDK: https://github.com/watson-developer-cloud/unity-sdk <br />
3.3 Follow the tutorial <br />
3.4 If 'Watson' appear in the menu bar, but "Request Couldn't be Processed", refresh your access: Watson -> Configuration Editor. <br />
3.5 Insert your credentials from Bluemix
4. Make sure the following C# scripts is attached to the following gameObjects: <br />
4.1 SpeechScript is attached to Plane <br />
4.2 CameraScript is attached to Main Camera <br />
4.3 WinnerScript is attached to Winner
5. Open the C# script SpeechScript
6. Time to be creative :-)