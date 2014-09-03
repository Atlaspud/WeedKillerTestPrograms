#define __NV_CUBIN_HANDLE_STORAGE__ static
#include "crt/host_runtime.h"
#include "threshold.fatbin.c"
extern void __device_stub__Z9thresholdPiiii(int *, const int, const int, const int);
static void __nv_cudaEntityRegisterCallback(void **);
static void __sti____cudaRegisterAll_17_threshold_cpp1_ii_1893a079(void);
#pragma section(".CRT$XCU",read,write)
__declspec(allocate(".CRT$XCU"))static void (*__dummy_static_init__sti____cudaRegisterAll_17_threshold_cpp1_ii_1893a079[])(void) = {__sti____cudaRegisterAll_17_threshold_cpp1_ii_1893a079};
void __device_stub__Z9thresholdPiiii(int *__par0, const int __par1, const int __par2, const int __par3){__cudaSetupArgSimple(__par0, 0U);__cudaSetupArgSimple(__par1, 4U);__cudaSetupArgSimple(__par2, 8U);__cudaSetupArgSimple(__par3, 12U);__cudaLaunch(((char *)((void ( *)(int *, const int, const int, const int))threshold)));}
#line 5 "C:/Users/Alex Olsen/Documents/Weed Killing Research Project/Image Processing System/Test Programs/Image Processing Environment/CUDA Kernels/threshold.cu"
void threshold( int *__cuda_0,const int __cuda_1,const int __cuda_2,const int __cuda_3)
#line 6 "C:/Users/Alex Olsen/Documents/Weed Killing Research Project/Image Processing System/Test Programs/Image Processing Environment/CUDA Kernels/threshold.cu"
{__device_stub__Z9thresholdPiiii( __cuda_0,__cuda_1,__cuda_2,__cuda_3);
#line 19 "C:/Users/Alex Olsen/Documents/Weed Killing Research Project/Image Processing System/Test Programs/Image Processing Environment/CUDA Kernels/threshold.cu"
}
#line 1 "Debug/threshold.cudafe1.stub.c"
static void __nv_cudaEntityRegisterCallback( void **__T20) {  __nv_dummy_param_ref(__T20); __nv_save_fatbinhandle_for_managed_rt(__T20); __cudaRegisterEntry(__T20, ((void ( *)(int *, const int, const int, const int))threshold), _Z9thresholdPiiii, (-1)); }
static void __sti____cudaRegisterAll_17_threshold_cpp1_ii_1893a079(void) {  __cudaRegisterBinary(__nv_cudaEntityRegisterCallback);  }
