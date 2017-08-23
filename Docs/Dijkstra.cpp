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
	printf(��\n���붥�������\n��);
	scanf(��%d��, &n);
	InputCost(n, Cost);
	printf(��\n����Դ������ţ���);
	scanf(��%d��, &v0);
	Dijkstra(Cost, n, v0, Distance);
	for (i = 0; i<n; i++)
	{
		printf(��%d���C%d\n��, i, Distance[i]);
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
	printf(��\nInput V1 &V2 &Cost:\n��);
	scanf(��%d%d%d��, &v1, &v2, &w);
	while (v1 != -1 && v2 != -1)     //��ȥͼ����Ϣ��
	{
		Cost[v1][v2] = w;
		scanf(��%d%d%d��, &v1, &v2, &w);
	}
	/*   for(int i=0 ;i<n;i++)   //������������ͼ���ڽӾ���
	      {
		       for(int j=0;j<n;j++)
	           {
	                 if(Cost[i][j]==MAXCOST)
	                 {
	                      printf(��* ��);

            	     }
	                 else
		             { 
		                  printf(��%d ��,Cost[i][j]);
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
	for (i = 0; i<n; i++)   //��S�����ʼ����
	{
		Distance[i] = Cost[v0][i];
		s[i] = 0;
	}
	s[v0] = 1;   //���v0.
	for (i = 0; i<n; i++)
	{
		mindis = MAXCOST;
		for (j = 0; j<n; j++)
		{
			if (s[j] == 0 && Distance[j]<mindis)  //ÿһ��ѭ���Ƚϵõ����ֵ��
			{
				u = j;
				mindis = Distance[j];
			}
		}
		s[u] = 1;   //���u.
		for (j = 0; j<n; j++)
		{
			if (s[j] == 0)
			{
				dis = Distance[u] + Cost[u][j];
				Distance[j] = (Distance[j]<dis) ? Distance[j] : dis;   //�޸Ĵ�v0�������������̾��롣
			}
		}
		/*  printf(��*********************\n��);            // ���ÿһ�αȽϺ�Ľ����
		for(j=0;j<n;j++)
		{
        	printf(��%d����-%d���C%d\n��,j,Distance[j],s[j]);
		}
		putchar(10);*/
	}
}

��������
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

��ȷ���
0����0
1����20
2����5
3����22
4���� - 28
5���� - 12