#include<cstdio>
#include<iostream>
#include<cstring>
using namespace std;

int main()
{
	void merge(int a[], int b[], int low, int mid, int high);
	void mergeSort(int a[], int b[], int low, int high);
	int a[100], b[100];
    int n;
	while (cin >> n)
	{
		memset(b, 0, sizeof(b));
		for (int i = 1; i <= n; i++)
		{
			cin >> a[i];
		}
		mergeSort(a, b, 1, n);
		for (int i = 1; i <= n; i++)
		{
			cout << a[i];
		}
		cout << endl;
	}
	return 0;
}

void merge(int a[], int b[], int low, int mid, int high) /*对俩个有序表进行排序*/
{
	int s = low, t = mid + 1, k = low;/*a[1]—a[mid] 和 a[mid+1] — a[high] 分别是俩个有序的有序表*/
	while (s <= mid && t <= high)/*将两个有序的有序表合并成一个有序的有序表*/
	{
		if (a[s] < a[t])
		{
			b[k] = a[s];
			s++;
		}
		else
		{
			b[k] = a[t];
			t++;
		}
		k++;
	}
	if (s == mid + 1)
	{
		for (int i = k; i <= high; i++)
		{
			b[i] = a[t++];
		}
	}
	else
	{
		for (int i = k; i <= high; i++)
		{
			b[i] = a[s++];
		}
	}
	for (int i = low; i <= high; i++)
	{
		a[i] = b[i];
	}
}

void mergeSort(int a[], int b[], int low, int high)
{
	if (low < high)
	{
		int mid = (low + high) / 2;/*求出mid划分*/
		mergeSort(a, b, low, mid);/*先对前半部分的划分进行排序*/
		mergeSort(a, b, mid + 1, high);/*对后半部分的划分进行排序*/
		merge(a, b, low, mid, high);/*二路归并排序*/
	}
}
