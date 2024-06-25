using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    AGrid grid;

    public Transform startObject;
    public Transform targetObject;

    private void Awake()
    {
        grid = GetComponent<AGrid>();
    }

    private void Update()
    {
        FindPath(startObject.position, targetObject.position);
    }

    private void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        ANode startNode = grid.GetNodeFromWorldPoint(startPos);
        ANode targetNode = grid.GetNodeFromWorldPoint(targetPos);

        List<ANode> openList = new List<ANode>();
        HashSet<ANode> closedList = new HashSet<ANode>();
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            ANode currentNode = openList[0];

            // 열린 목록에서 F cost가 가장 작은 노드를 찾고, 만약 F coust가 같다면 차순위로 H cost를 비교해서 찾는다
            for(int i = 1; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }

            // 탐색된 노드는 열린목록에서 제거하고 끝난목록에 추가한다
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            //탐색된 노드가 목표노드라면 탐색 종료
            if(currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            //이웃 노드로 계속 탐색
            foreach(ANode n in grid.GetNeighborNodes(currentNode))
            {
                //이동불가 노드거나 끝난 목록에 있는 경우에는 스킵
                if(!n.isWalkable || closedList.Contains(n))
                    continue;

                //이웃 노드들의 G cost와 H cost를 계산하여 열린목록에 추가
                int newCurrentToNeighborCost = currentNode.gCost + GetDistanceCost(currentNode, n);
                if(newCurrentToNeighborCost < n.gCost || !openList.Contains(n))
                {
                    n.gCost = newCurrentToNeighborCost;
                    n.hCost = GetDistanceCost(n, targetNode);
                    n.parentNode = currentNode;

                    if(!openList.Contains(n))
                        openList.Add(n);
                }
            }
        }
    }


    // 두 노드 사이의 거리를 Cost로 계산
    private int GetDistanceCost(ANode nodeA, ANode nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        //X축, Y축 1칸 이동에 10, 대각선 이동으로 14 Cost
        if(distX > distY)       
            return 14 * distY + 10 * (distX - distY);

        return 14 * distX + 10 * (distY - distX);        
    }

    // 탐색 종료 후 최종 노드의 ParentNode를 추적하며 리스트에 담는다
    private void RetracePath(ANode startNode, ANode endNode)
    {
        List<ANode> path = new List<ANode>();
        ANode currentNode = endNode;

        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parentNode;
        }
        path.Reverse();
        grid.path = path; //grid에 순차정렬된 path 리스트를 담는다
    }
}
