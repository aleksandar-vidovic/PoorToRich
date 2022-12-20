using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadReload : MonoBehaviour
{
    private IEnumerator LoadASync(int scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene);

        while (!asyncOperation.isDone)
            yield return null;
    }

    public void SceneLoading(int scene)
    {
        StartCoroutine(LoadASync(scene));
    }

    public void SceneReloading()
    {
        StartCoroutine(LoadASync(SceneManager.GetActiveScene().buildIndex));
    }
}
