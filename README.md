# HiSafe

██╗░░██╗██╗░██████╗░█████╗░███████╗███████╗
██║░░██║██║██╔════╝██╔══██╗██╔════╝██╔════╝
███████║██║╚█████╗░███████║█████╗░░█████╗░░
██╔══██║██║░╚═══██╗██╔══██║██╔══╝░░██╔══╝░░
██║░░██║██║██████╔╝██║░░██║██║░░░░░███████╗
╚═╝░░╚═╝╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚══════╝

2022 - 2023 @nimaaminz 

This is a test application and maybe a training application in C# .NET framework WindowsForm that do image processing and will 
detect motion using USB Camera and capture picture of detected frame .
using Aforge Library for connection but not the original 
cause i've been change the VideoCaptureDevice.NewFrame parameter from open source Aforge library because i needed very very fast processing in 30FPS 
and then in library i send only the address of first frame data in memory (RAM) of the computer with the length of data and then in HiSafeCore.MotionDetect in Camera_frame_recieve_isr 
i will read the address and then do processing algorithm 
- You can check the beep and saveing picture 
- the pictures taken to Picture windows original user address 
- for getting 30fps after start the camera , go to the settings and then change the expesure , then you have 30FPS ( Recommend -4 ~ -6 value ) 
- remmeber this program only works in 360 * 240 resolution ( because i didnt need to get better resolution) 
- the left graph is time of process frame in millisecond in time . 



