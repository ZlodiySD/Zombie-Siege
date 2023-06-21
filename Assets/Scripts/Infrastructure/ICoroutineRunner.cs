using System.Collections;
using UnityEngine;

namespace Didenko.Infrastructure
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);

    void StopCoroutine(IEnumerator coroutine);
  }
}