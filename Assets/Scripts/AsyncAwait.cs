using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwait : MonoBehaviour
{

    private CancellationTokenSource ctsSource = new();


    async void Start()
    {

        var cts = ctsSource.Token;

        Debug.Log("Start Ends");

        var task1 = WaitSecondAndPrint(cts);
        var task2 = Wait60Frames(cts);

        var taskResult = await WhatTaskFaster(cts, task1, task2);
        if (taskResult)
            Debug.Log($"Task 1 is faster [WaitSecondAndPrint], Result: {taskResult}");
        else
            Debug.Log($"Task 2 is faster [Wait60Frames], Result: {taskResult}");
        
    }

    private async Task WaitSecondAndPrint(CancellationToken cts)
    {

        Debug.Log("Task 1 started");

        if (cts.IsCancellationRequested)
        {
            Debug.Log("Token Cancelled");
            return;
        }

        await Task.Delay(1000);
        Debug.Log("Wait Second ends");


    }


    private async Task Wait60Frames(CancellationToken cts)
    {

        Debug.Log("Task 2 started");

        int frames = 0;
        while(frames <= 60)
        {
            frames++;
            if(cts.IsCancellationRequested)
            {
                Debug.Log("Token Cancelled");
                return;
            }

            await Task.Yield();
        }

        Debug.Log("Waited 60 frames ends");
    }


    private async Task<bool> WhatTaskFaster(CancellationToken cancellationToken, Task task1, Task task2)
    {
        
        Task resultTask = await Task.WhenAny(task1, task2);

        ctsSource.Cancel();
        return resultTask == task1;
    }
}
