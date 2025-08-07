#include<stdio.h>
void main()
{
	int a[] = {23,45,67,89,9};
	printf("Before sorting...\n");

	for(int i = 0; i < 5; i++)
	{
		printf("%d\n",a[i]);
	}

	for(int i = 0; i < 5 - 1; i++)
	{
		for(int j = i + 1; j < 5; j++)
		{
			if(a[i] > a[j])
			{
				int temp = a[i];
				a[i] = a[j];
				a[j] = temp;
			}
		}
	}

	printf("After sorting...\n");
	for(int i = 0; i < 5; i++)
	{
		printf("%d\n",a[i]);
	}
}