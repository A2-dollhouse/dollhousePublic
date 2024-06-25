using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AGrid : MonoBehaviour
{
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public List<ANode> path;
    ANode[,] grid;


    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    void Start()
    {
        nodeDiameter = nodeRadius * 2; // ������ ��� ���������� ������ ����
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter); // �׸����� x ũ��
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter); // �׸����� y ũ��
        CreateGrid();
    }

    //�׸��� ���� �޼���
    private void CreateGrid()
    {
        grid = new ANode[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;
        Vector3 worldPoint;

        for (int x = 0; x < gridSizeX; x++)
        {
            for(int y = 0; y < gridSizeY; y++)
            {
                worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask));
                grid[x, y] =new ANode(walkable, worldPoint, x, y);
            }
        }

    }

    // ���õ� ����� 8������ �̿���带 ��ȯ�ؼ� ���� ��Ͽ� �߰��ϱ� ���� �Լ�
    public List<ANode> GetNeighborNodes (ANode node)
    {
        List<ANode> neighbor = new List<ANode>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0) continue;     // �ڱ��ڽ��� ��� ��ŵ

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                // X, Y�� ���� Grid �����ȿ� ���� ���
                if(checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbor.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbor;
    }


    // ����Ƽ ���� WorldPosition ��ġ������ ������ �׸����� ��ġ�� ��ȯ�ؼ� ��带 ��ȯ�ϴ� �Լ� >>> Scene�� �ִ� ���� ������Ʈ�� ��ǥ ������Ʈ�� �ִ� ��带 ��� ���� �Լ�
    public ANode GetNodeFromWorldPoint(Vector3 worldPosition) 
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1)*percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1)*percentY);
        return grid[x, y];
    }


    //��带 �ð������� ǥ���ϴ� �޼���
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
        if(grid != null)
        {
            foreach(ANode node in grid)
            {
                Gizmos.color = (node.isWalkable) ? Color.green : Color.red;
                
                //Ž���� path�� ���ǥ��(������)
                if(path != null)
                {
                    if(path.Contains(node))
                        Gizmos.color = Color.black;
                }

                Gizmos.DrawCube(node.worldPos, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }
}
