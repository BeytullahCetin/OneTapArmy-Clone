using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SoldierMovement : MonoBehaviour
{
	NavMeshAgent navMeshAgent;
	SoldierAnimation soldierAnimation;

	Task moveTask;
	CancellationTokenSource moveCancellationToken;


	public void Initialize()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		soldierAnimation = GetComponent<SoldierAnimation>();
	}

	public async void Move(Vector3 target)
	{
		if (CanMove() == false)
			return;

		bool isReached = await MoveToPosition(target);
		if (isReached == false)
			return;

		soldierAnimation.StopRunAnimation();
	}

	private bool CanMove()
	{
		return true;
	}

	public void StopMovement()
	{
		moveCancellationToken?.Cancel();
		moveCancellationToken = new CancellationTokenSource();
	}

	public async Task<bool> MoveToPosition(Vector3 target)
	{
		StopMovement();
		return await MoveToPositionTask(GetRandomizedTarget(target), moveCancellationToken.Token);
	}

	public async Task<bool> MoveToPositionTask(Vector3 target, CancellationToken token)
	{
		navMeshAgent.avoidancePriority = Random.Range(20, 80);
		soldierAnimation.StartRunAnimation();
		navMeshAgent.SetDestination(target);

		try
		{
			await UniTask.WaitUntil(IsReached, cancellationToken: token);
		}
		catch (OperationCanceledException)
		{
			return false;
		}

		soldierAnimation.StopRunAnimation();
		return true;
	}

	public bool IsReached()
	{
		bool isDistance = navMeshAgent.remainingDistance != Mathf.Infinity;
		bool isPath = navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete;
		bool isRemainingDistance = navMeshAgent.remainingDistance == 0;

		return isDistance && isPath && isRemainingDistance;
	}

	private Vector3 GetRandomizedTarget(Vector3 target)
	{
		float randomOffset = Random.Range(-1f, 1f);
		Vector3 offset = new Vector3(randomOffset, 0, randomOffset);
		return target + offset;
	}
}
