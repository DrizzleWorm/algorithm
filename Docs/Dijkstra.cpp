#include <cstdio>
#include <cstring>
#define MAXNODE 20
#define MAXCOST 9999
using namespace std;
void InputCost(int n, int Cost[][MAXNODE]);
void Dijkstra(int Cost[][MAXNODE], int n, int v0, int Distance[]);
int main()
{
	int Cost[MAXNODE][MAXNODE];
	int i, n, v0, Distance[MAXNODE];
	printf(“\n输入顶点个数：\n”);
	scanf(“%d”, &n);
	InputCost(n, Cost);
	printf(“\n输入源顶点序号：”);
	scanf(“%d”, &v0);
	Dijkstra(Cost, n, v0, Distance);
	for (i = 0; i<n; i++)
	{
		printf(“%d—–%d\n”, i, Distance[i]);
	}
}

void InputCost(int n, int Cost[][MAXNODE])
{
	int i, j, v1, v2, w;
	for (i = 0; i<n; i++)
	{
		for (j = 0; j<n; j++)
		{
			if (i != j)
			{
				Cost[i][j] = MAXCOST;
			}
			else
			{
				Cost[i][j] = 0;
			}
		}
	}
	printf(“\nInput V1 &V2 &Cost:\n”);
	scanf(“%d%d%d”, &v1, &v2, &w);
	while (v1 != -1 && v2 != -1)     //数去图的信息。
	{
		Cost[v1][v2] = w;
		scanf(“%d%d%d”, &v1, &v2, &w);
	}
	/*   for(int i=0 ;i<n;i++)   //可以输出输入的图的邻接矩阵。
	      {
		       for(int j=0;j<n;j++)
	           {
	                 if(Cost[i][j]==MAXCOST)
	                 {
	                      printf(“* “);

            	     }
	                 else
		             { 
		                  printf(“%d “,Cost[i][j]);
				     }
               }
               putchar(10);
          }*/
}

void Dijkstra(int Cost[][MAXNODE], int n, int v0, int Distance[])
{
	int s[MAXNODE];
    int mindis, dis;
	int i, j, u;
	for (i = 0; i<n; i++)   //对S数组初始化。
	{
		Distance[i] = Cost[v0][i];
		s[i] = 0;
	}
	s[v0] = 1;   //标记v0.
	for (i = 0; i<n; i++)
	{
		mindis = MAXCOST;
		for (j = 0; j<n; j++)
		{
			if (s[j] == 0 && Distance[j]<mindis)  //每一次循环比较得到最短值。
			{
				u = j;
				mindis = Distance[j];
			}
		}
		s[u] = 1;   //标记u.
		for (j = 0; j<n; j++)
		{
			if (s[j] == 0)
			{
				dis = Distance[u] + Cost[u][j];
				Distance[j] = (Distance[j]<dis) ? Distance[j] : dis;   //修改从v0到其他顶点的最短距离。
			}
		}
		/*  printf(“*********************\n”);            // 输出每一次比较后的结果。
		for(j=0;j<n;j++)
		{
        	printf(“%d——-%d—–%d\n”,j,Distance[j],s[j]);
		}
		putchar(10);*/
	}
}

测试数据
6
0 2 5
0 3 30
1 0 2
1 4 8
2 1 15
2 5 7
4 3 4
5 3 10
5 4 18
- 1 - 1 0
0

正确结果
0——0
1——20
2——5
3——22
4—— - 28
5—— - 12