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

            // ���� ��Ͽ��� F cost�� ���� ���� ��带 ã��, ���� F coust�� ���ٸ� �������� H cost�� ���ؼ� ã�´�
            for(int i = 1; i < openList.Count; i++)
            {
                if (openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }

            // Ž���� ���� ������Ͽ��� �����ϰ� ������Ͽ� �߰��Ѵ�
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            //Ž���� ��尡 ��ǥ����� Ž�� ����
            if(currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            //�̿� ���� ��� Ž��
            foreach(ANode n in grid.GetNeighborNodes(currentNode))
            {
                //�̵��Ұ� ���ų� ���� ��Ͽ� �ִ� ��쿡�� ��ŵ
                if(!n.isWalkable || closedList.Contains(n))
                    continue;

                //�̿� ������ G cost�� H cost�� ����Ͽ� ������Ͽ� �߰�
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


    // �� ��� ������ �Ÿ��� Cost�� ���
    private int GetDistanceCost(ANode nodeA, ANode nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        //X��, Y�� 1ĭ �̵��� 10, �밢�� �̵����� 14 Cost
        if(distX > distY)       
            return 14 * distY + 10 * (distX - distY);

        return 14 * distX + 10 * (distY - distX);        
    }

    // Ž�� ���� �� ���� ����� ParentNode�� �����ϸ� ����Ʈ�� ��´�
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
        grid.path = path; //grid�� �������ĵ� path ����Ʈ�� ��´�
    }
}
