#include "cuda_runtime.h"
#include <stdio.h>
#include "device_launch_parameters.h"

#define Erode 0
#define Dilate 1

__global__ void morphology(int* image, const int Width, const int Height, const int Operation, const int Radius)
{
	int i = blockIdx.x * blockDim.x + threadIdx.x;
	int j = blockIdx.y * blockDim.y + threadIdx.y;
	if (i >= Width || j >= Height) return;
	int index = j * Width + i;
	int value = (Operation == Erode) ? 0 : 255;
	for (int h = (i - Radius); h < (i + Radius); h++)
	{
		for (int w = (j - Radius); w < (j + Radius); w++)
		{
			if (w >= 0 && w < Width && h >= 0 && h < Height)
			{
				int maskIndex = h * Width + w;
				if (image[maskIndex] == value)
				{
					image[index] = value;
					w = j + Radius;
					h = i + Radius;
				}
			}			
		}
	}
}
 
int main()
{
    return 0;
}