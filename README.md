# MeekNET
Small .Net wrapper for the meek.moe Vocaloid image API
Built on .NetStandard 2.0

This is made with Discord Bots in mind, so objects include a proxy URL that resizes the image to a height of 500px

## Usage

Just the URL
```cs
using MeekNET;
using MeeKNET.Enums;
using MeekNet.Entities;
//...//
MeekMoe mm = new MeekMoe();
ImgUrl iu = await m.GetImgUrl(Loids.ProjectDiva);
//The object holds the URL, Proxy URL and depending if it's set in the API DB, a creator message 
```

With image stream
```cs
using MeekNET;
using MeeKNET.Enums;
using MeekNet.Entities;
//...//
MeekMoe mm = new MeekMoe();
ImgUrl id = await m.GetImg(Loids.ProjectDiva, 500);
//This also contains a stream of the (if a value is set) proxy resized image and the filetype (for example "jpeg" or "png")
```
