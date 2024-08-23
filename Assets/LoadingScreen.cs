using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private Text _textField;

    [SerializeField]
    private AssetReference _sceneToLoad;

    private string _label = "downloadOnStart";
    private AsyncOperationHandle _asyncOperationHandle;
    private AsyncOperation _asyncOperation;
    private string _name = string.Empty;
    private bool _displayBytes = true;
    private void Start()
    {
        StartCoroutine(Preload());
    }

    public void Update()
    {
        if (_displayBytes)
        {
            if (!_asyncOperationHandle.IsValid())
            {
                return;
            }

            var downloadStatus = _asyncOperationHandle.GetDownloadStatus();
            var downloadedMb = (downloadStatus.DownloadedBytes / (1024m * 1024m));
            var totalMb = (downloadStatus.TotalBytes / (1024m * 1024m));
            _textField.text = $"{_name} Bytes {downloadedMb:F2}MB / {totalMb:F2}MB ({_asyncOperationHandle.PercentComplete:P2})";
        }
        else
        {
            var progress = _asyncOperation != null ? _asyncOperation.progress : (_asyncOperationHandle.IsValid() ? _asyncOperationHandle.PercentComplete : 0f);
            _textField.text = $"{_name} {progress:P2}";
        }
    }

    private IEnumerator Preload()
    {
        AsyncOperationHandle<long> getDownloadSize = Addressables.GetDownloadSizeAsync(_label);
        yield return getDownloadSize;

        //If the download size is greater than 0, download all the dependencies.
        if (getDownloadSize.Result > 0)
        {
            _displayBytes = true;
            _asyncOperationHandle = Addressables.DownloadDependenciesAsync(_label);
            _name = "Downloading Asset";
            yield return _asyncOperationHandle;
        }

        _displayBytes = false;
        _name = "Loading Scene";
        var sceneHandle = _sceneToLoad.LoadSceneAsync(LoadSceneMode.Additive, false);
        _asyncOperationHandle = sceneHandle;
        yield return _asyncOperationHandle;
        _asyncOperationHandle = default;

        if (sceneHandle.Status == AsyncOperationStatus.Succeeded)
        {
            _name = "Activating Scene";
            _asyncOperation = sceneHandle.Result.ActivateAsync();
            yield return _asyncOperation;
        }

        _name = "Unloading";
        _asyncOperation = SceneManager.UnloadSceneAsync(this.gameObject.scene);
    }
}
