# MeekNET
Small .Net wrapper for the meek.moe Vocaloid image API
Built on .NetStandard 2.0

This is made with Discord Bots in mind, so objects include a proxy URL that resizes the image to a hegt of 500px

## Usage

Just the URL
```cs
var ImageObject = await MeeNET.GetImgUrl(MeekNET.loids.ProjectDiva);
//The object holds the URL, Proxy URL and depending if the its Set in the API DB, a creator message 
```

With image stream
```cs
var ImageObject = await MeeNET.GetImg(MeekNET.loids.ProjectDiva);
//This also contains a stream if the proxy resized image and the filetype 
```
