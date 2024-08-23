Reproduce:

Step 1: Build a executable

Step 2: Run it

Step 3: Watch the scene not change and the error be displayed

```
Mono path[0] = 'C:/Users/J/OneDrive/Documents/BuildWinTest/AddressableSceneBug_Data/Managed'
Mono config path = 'C:/Users/J/OneDrive/Documents/BuildWinTest/MonoBleedingEdge/etc'
[PhysX] Initialized MultithreadedTaskDispatcher with 24 workers.
Initialize engine version: 2022.3.35f1 (011206c7a712)
[Subsystems] Discovering subsystems at path C:/Users/J/OneDrive/Documents/BuildWinTest/AddressableSceneBug_Data/UnitySubsystems
GfxDevice: creating device client; threaded=1; jobified=1
Direct3D:
    Version:  Direct3D 11.0 [level 11.1]
    Renderer: NVIDIA GeForce RTX 3080 (ID=0x2216)
    Vendor:   NVIDIA
    VRAM:     10053 MB
    Driver:   32.0.15.5599
Begin MonoManager ReloadAssembly
- Loaded All Assemblies, in  0.093 seconds
- Finished resetting the current domain, in  0.001 seconds
<RI> Initializing input.
<RI> Input initialized.
<RI> Initialized touch support.
[PhysX] Initialized MultithreadedTaskDispatcher with 24 workers.
UnloadTime: 0.581700 ms
Scene 'Assets/Scenes/DownloadedScene.unity' couldn't be loaded because it has not been added to the build settings or the AssetBundle has not been loaded.
To add a scene to the build settings use the menu File->Build Settings...
NullReferenceException: Object reference not set to an instance of an object
  at UnityEngine.ResourceManagement.ResourceProviders.SceneProvider+SceneOp.InternalLoadScene (UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation location, System.Boolean loadingFromBundle, UnityEngine.SceneManagement.LoadSceneParameters loadSceneParameters, System.Boolean activateOnLoad, System.Int32 priority) [0x00017] in <8ca064ccd930487f9d9e4a1371e793da>:0 
  at UnityEngine.ResourceManagement.ResourceProviders.SceneProvider+SceneOp.Execute () [0x00077] in <8ca064ccd930487f9d9e4a1371e793da>:0 
  at UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase`1[TObject].InvokeExecute () [0x00000] in <8ca064ccd930487f9d9e4a1371e793da>:0 
  at UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase`1[TObject].Start (UnityEngine.ResourceManagement.ResourceManager rm, UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle dependency, DelegateList`1[T] updateCallbacks) [0x0008b] in <8ca064ccd930487f9d9e4a1371e793da>:0 
  at UnityEngine.ResourceManagement.ResourceManager.StartOperation[TObject] (UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase`1[TObject] operation, UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle dependency) [0x00000] in <8ca064ccd930487f9d9e4a1371e793da>:0 
  at UnityEngine.ResourceManagement.ResourceProviders.SceneProvider.ProvideScene (UnityEngine.ResourceManagement.ResourceManager resourceManager, UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation location, UnityEngine.SceneManagement.LoadSceneParameters loadSceneParameters, System.Boolean activateOnLoad, System.Int32 priority) [0x0004b] in <8ca064ccd930487f9d9e4a1371e793da>:0 
  at UnityEngine.ResourceManagement.ResourceManager.ProvideScene (UnityEngine.ResourceManagement.ResourceProviders.ISceneProvider sceneProvider, UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation location, UnityEngine.SceneManagement.LoadSceneParameters loadSceneParameters, System.Boolean activateOnLoad, System.Int32 priority) [0x0000e] in <8ca064ccd930487f9d9e4a1371e793da>:0 
  at UnityEngine.AddressableAssets.AddressablesImpl.LoadSceneAsync (UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation location, UnityEngine.SceneManagement.LoadSceneParameters loadSceneParameters, System.Boolean activateOnLoad, System.Int32 priority, System.Boolean trackHandle) [0x00020] in <de4f843f379446e18f14228fd803abe8>:0 
  at UnityEngine.AddressableAssets.AddressablesImpl.LoadSceneAsync (System.Object key, UnityEngine.SceneManagement.LoadSceneParameters loadSceneParameters, System.Boolean activateOnLoad, System.Int32 priority, System.Boolean trackHandle) [0x0005d] in <de4f843f379446e18f14228fd803abe8>:0 
  at UnityEngine.AddressableAssets.Addressables.LoadSceneAsync (System.Object key, UnityEngine.SceneManagement.LoadSceneMode loadMode, System.Boolean activateOnLoad, System.Int32 priority) [0x0000c] in <de4f843f379446e18f14228fd803abe8>:0 
  at UnityEngine.AddressableAssets.AssetReference.LoadSceneAsync (UnityEngine.SceneManagement.LoadSceneMode loadMode, System.Boolean activateOnLoad, System.Int32 priority) [0x00027] in <de4f843f379446e18f14228fd803abe8>:0 
  at LoadingScreen+<Preload>d__9.MoveNext () [0x000c9] in <ddf5da6850b3418da299f9379d5432e3>:0 
  at UnityEngine.SetupCoroutine.InvokeMoveNext (System.Collections.IEnumerator enumerator, System.IntPtr returnValueAddress) [0x00026] in <e422ced3d0f64bb29423e8338d57bc04>:0 
```

Step 4: Close exe and re-run

Step 5: Scene changes fine.


When Unity downloads a scene it doesn't seem to register it until the application is restarted.
