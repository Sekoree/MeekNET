# MeekNET
Small .Net wrapper for the meek.moe Vocaloid image API

This is made with Discord Bots in mind, so objects include a proxy URL that resizes the image to a height of 500px

## Usage

Just the URL
```cs
using MeekNET;
using MeeKNET.Enums;
using MeekNet.Entities;
//...//
MeekMoe mm = new MeekMoe();
ImgUrl iu = await mm.GetImgUrl(Loids.ProjectDiva, 250);
//The object holds the URL, proxy URL and depending if it's set in the API DB, a creator message 
//The specified integer will be set height of the proxy URL
```

With image stream
```cs
using MeekNET;
using MeeKNET.Enums;
using MeekNet.Entities;
//...//
MeekMoe mm = new MeekMoe();
ImgData id = await mm.GetImg(Loids.ProjectDiva, 500);
//This also contains a stream of the (if a value is set) proxy resized image and the filetype (for example "jpeg" or "png")
```
