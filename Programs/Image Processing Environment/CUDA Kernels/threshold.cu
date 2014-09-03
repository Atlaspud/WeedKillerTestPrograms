#include "cuda_runtime.h"
#include <stdio.h>
#include "device_launch_parameters.h"

__global__ void threshold(int* image, const int Width, const int Height, const int Threshold)
{
    int i = blockIdx.x * blockDim.x + threadIdx.x;
	int j = blockIdx.y * blockDim.y + threadIdx.y;
	if (i >= Width || j >= Height) return;
	int index = j * Width + i;
	if (image[index] >= Threshold)
	{
		image[index] = 255;
	}
	else
	{
		image[index] = 0;
	}
}