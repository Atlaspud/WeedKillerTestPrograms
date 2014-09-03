#define __NV_CUBIN_HANDLE_STORAGE__ static
#include "crt/host_runtime.h"
#include "morphology.fatbin.c"
extern void __device_stub__Z10morphologyPiiiii(int *, const int, const int, const int, const int);
static void __nv_cudaEntityRegisterCallback(void **);
static void __sti____cudaRegisterAll_18_morphology_cpp1_ii_a85e256d(void);
#pragma section(".CRT$XCU",read,write)
__declspec(allocate(".CRT$XCU"))static void (*__dummy_static_init__sti____cudaRegisterAll_18_morphology_cpp1_ii_a85e256d[])(void) = {__sti____cudaRegisterAll_18_morphology_cpp1_ii_a85e256d};
void __device_stub__Z10morphologyPiiiii(int *__par0, const int __par1, const int __par2, const int __par3, const int __par4){__cudaSetupArgSimple(__par0, 0U);__cudaSetupArgSimple(__par1, 4U);__cudaSetupArgSimple(__par2, 8U);__cudaSetupArgSimple(__par3, 12U);__cudaSetupArgSimple(__par4, 16U);__cudaLaunch(((char *)((void ( *)(int *, const int, const int, const int, const int))morphology)));}
#line 8 "C:/Users/Alex Olsen/Documents/Weed Killing Research Project/Image Processing System/Test Programs/Image Processing Environment/CUDA Kernels/morphology.cu"
void morphology( int *__cuda_0,const int __cuda_1,const int __cuda_2,const int __cuda_3,const int __cuda_4)
#line 9 "C:/Users/Alex Olsen/Documents/Weed Killing Research Project/Image Processing System/Test Programs/Image Processing Environment/CUDA Kernels/morphology.cu"
{__device_stub__Z10morphologyPiiiii( __cuda_0,__cuda_1,__cuda_2,__cuda_3,__cuda_4);
#line 31 "C:/Users/Alex Olsen/Documents/Weed Killing Research Project/Image Processing System/Test Programs/Image Processing Environment/CUDA Kernels/morphology.cu"
}
#line 1 "Debug/morphology.cudafe1.stub.c"
static void __nv_cudaEntityRegisterCallback( void **__T20) {  __nv_dummy_param_ref(__T20); __nv_save_fatbinhandle_for_managed_rt(__T20); __cudaRegisterEntry(__T20, ((void ( *)(int *, const int, const int, const int, const int))morphology), _Z10morphologyPiiiii, (-1)); }
static void __sti____cudaRegisterAll_18_morphology_cpp1_ii_a85e256d(void) {  __cudaRegisterBinary(__nv_cudaEntityRegisterCallback);  }
