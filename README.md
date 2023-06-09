# Cloud Change

This is a [Neos Mod Loader](https://github.com/neos-modding-group/NeosModLoader) mod that allows you to change what cloud endpoints Neos uses. Possibly useful for a custom cloud server.

~~The current default options also fix some of the issues [here](https://github.com/Neos-Metaverse/NeosPublic/issues/3872). These include:~~ (This is no longer the case as all issues have been fixed)
- ~~Session thumbnails not being uploaded with the correct syntax~~ (Fixed with an update)
- ~~neosdb videos not loading~~ (Fixed with an update)
- ~~Linux native build being completely unusable~~ ("Fixed" by Karel fixing the old URLs)

## Installation
1. Install [NeosModLoader](https://github.com/neos-modding-group/NeosModLoader).
1. Place [CloudChange.dll](https://github.com/Lexevolution/Cloud-Change/releases/latest/download/CloudChange.dll) into your `nml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\nml_mods` for a default install. You can create it if it's missing, or if you launch the game once with NeosModLoader installed it will create the folder for you.
1. Start the game. If you want to verify that the mod is working you can check your Neos logs.

## Config Options

(Any change of the config will require a restart of Neos to take effect)

- API URL (Default `https://api.neos.com`): The endpoint for most of the API actions in Neos. Changing this will change where most cloud actions go to and from. You would likely need to host your own Neos Cloud to change this.
- Blob Storage URL (Default `https://assets.neos.com/`): The root endpoint which stores all the assets for all objects. Changing this would change which blob storage thyour neosdb assets go to. You would likely need to host your own blob storage server to change this.
- Blob Retrieval URL (Default `https://cloudxstorage.blob.core.windows.net/assets/`): The endpoint which retrieves the assets stored at the Blob Storage URL.
- CDN URL (Default `https://assets.neos.com/assets/`): The Content Delivery Network URL that is used to deliver assets faster than the Blob Retrieval URL. You would likely need to proxy the asset server through a CDN to change this.
- Video CDN URL (Default `https://assets.neos.com/assets/`): The endpoint which delivers specifically video assets saved to your inventory (neodb videos).
- Old Thumbnail URL (Default `https://cloudxstorage.blob.core.windows.net/thumbnails/`): The endpoint which used to store and retrieve thumbnails for sessions. This likely isn't used anymore and doesn't need to be changed. Added it in just in case.
- Thumbnail URL (Default `https://operationaldata.neos.com/thumbnails/`): The endpoint which stores and retrieves thumbnails for sessions.

## Building

Ensure that the required DLL's (listed in the `Directory.Build.props` file and in the individual `.csproj` files) can be found from standard installation paths (check `Directory.Build.props`).
Then use the `dotnet build` command to build.

Alternatively you can open the folder in Visual Studio and just use the GUI.
