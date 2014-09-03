#include "fatBinaryCtl.h"
#define __CUDAFATBINSECTION  ".nvFatBinSegment"
#define __CUDAFATBINDATASECTION  ".nv_fatbin"
#ifdef __cplusplus
extern "C" {
#endif

#pragma data_seg(__CUDAFATBINDATASECTION)
static const __declspec(allocate(__CUDAFATBINDATASECTION)) unsigned long long fatbinData[]= {
0x00100001ba55ed50,0x0000000000001238,0x000000e001010002,0x0000000000000a90,
0x0000000000000000,0x0000001e00010007,0x0000009800000040,0x0000000000001046,
0x0000000000000000,0x00000000000023f8,0x73726573552f3a43,0x6c4f2078656c412f,
0x75636f442f6e6573,0x65572f73746e656d,0x696c6c694b206465,0x616573655220676e,
0x6a6f725020686372,0x67616d492f746365,0x7365636f72502065,0x73795320676e6973,
0x747365542f6d6574,0x6d6172676f725020,0x206567616d492f73,0x69737365636f7250,
0x7269766e4520676e,0x432f746e656d6e6f,0x6e72654b20414455,0x657268742f736c65,
0x75632e646c6f6873,0x0000000000000000,0x475c6c6b5aed9c78,0x9a3f5debbbb99e15,
0x4957449d4ea41e6c,0xb8cfc3ef5929168c,0x2dc2568704ea4d94,0x59bedaf5a3888aad,
0xd96d7bdedddf586f,0x5c1478bcdb36234d,0xb423c2068700429a,0xe0144784da14923c,
0x611c255fe60fe20f,0x9510ac8425514b2c,0xdcd7dccce708ad4a,0xb58c822da0ff18dd,
0xce67333be77ce667,0xfbb33faee77bdecc,0x22f09064d2943de1,0x405bd3ed9a84ab91,
0x342b489ba26c84c8,0x1f546b45ee42247c,0xaacb420cc8cd0dd1,0x344613286d594727,
0x91f45344632ea9fd,0xd54485072fb87e42,0x4983b8503d4e68f1,0xac7e12f0ca68c91f,
0xb11aa32375505431,0x3a8e5bffc94d446a,0xec69b2c706561e9e,0x75d19eb4d929ad32,
0xf0aa332d01e0e512,0xc554e7caf6c0048e,0x345622e255a3e0f4,0x21eee8ec1951aa26,
0x194d41c199dbceb9,0xfd5819ee0b2b34b7,0x5eb910aa030e0467,0xe8e0ba5a61541b1c,
0x4f71566a32d75c80,0x4b52c6131b483a07,0xde5866daefdf255f,0xbcb033174f692f62,
0xcb784f607fc4f777,0x049791d647db5776,0x6f27ee828fe403fd,0x21af5ba904807a08,
0x221e82fd920f4149,0x1d7a084e4b5e8293,0xbd041fc9ebd05e79,0x993487bf5b924881,
0xb2abaf0eaf806bed,0x2ac56b59a32623b3,0x5c1b585a8fa208d0,0x33d0ed6022204945,
0x03b7db2dfb427409,0xe613af027d024ee6,0x2ebcda2ed003024f,0xc63c58088c0901c8,
0x4f319c60394c0888,0x13c4a3094e23208a,0x09310e0b9416788c,0x98cad822f38125b9,
0x4efe631b6038cc08,0x498a71ee33977900,0x22bc59cc41d7a4ac,0x8bb144cee73498cb,
0x064c64f46bf06161,0xb58d98f50f22a65d,0x22963c7e67750c33,0x4fa0613cce6745e8,
0x567bcec4015f18d8,0x4eebfa8cabe5f44f,0x30c930e9d136ed7f,0x49c99b07621c67d4,
0x9c088193b01ca600,0x53c7759e062ec075,0x758d82fd43f360ec,0xd8f99ccecbf50c32,
0x8b02391e09904233,0x3bdc802738a7c80e,0xd1bd46d3892c220c,0x8ce302e89b3112c6,
0x9b298c1301cc4089,0xff894286dd4301a0,0xd0908a54a470d269,0x852a54b048a523ed,
0x38a0cf1465838450,0x1ac028e38a18e28a,0x44a41128084ba109,0xe09129044a411290,
0xe7c5167c51271409,0x8b3c5017c51e7c50,0xa14cbd84be288be2,0xe28f3c5197c50e78,
0x57c5057c50178a14,0x475f1435f1469c51,0xf8a0ce28d3140df1,0xbe28b3d3b1178a26,
0x3be1a1ce28dbe285,0x8fbe287be28bbe28,0x1425e2807e28f386,0xe2847e2887e1a32f,
0x2e280b86827e28c7,0x14fc3415e284b8a2,0x3435e28abc50cfc5,0xfc51cfc50571465c,
0x57142bf144bf0d02,0xac32e53891a4c731,0x0149fe783434ff83,0x15edf4a4830911b7,
0xd804fc086e292075,0x5c5ade91af89fa3a,0x2a58ba46a5f9f45c,0x37d661bb65d428f9,
0xb47a64b422f2e54b,0x82dd2840cc094cf4,0xa464df20efe962cf,0x790d89fc03042945,
0xae3cb47707c862b1,0xc84caf33b2de9a2b,0x1853d2da8aebcf1f,0x42796f4354551b1a,
0x17b8797287e58651,0x4368c95d1547e566,0x190ca838569f7223,0x21b5055933477b2d,
0x50dd4989f191d745,0x2ce10374531e5b46,0x3c756ed64af5b4dc,0xc7c1e5a11c5415a7,
0xe4aa9a290fca767b,0x343a3ee5d6abd875,0xf0317edf8f5fe846,0xd0f58d0a139d9f7b,
0xadb9834d15e9f9f0,0x236e06773f2fbda7,0xcbcc1e981ffcde94,0xb9aed4c29b55c127,
0x8a0330c1174a69e4,0xe70c52a11492419f,0x42fbd4d687368ab8,0x105208534d70d28f,
0xda17c85489cd74a5,0x1a47cd77b35dd351,0x0b49075534d5d156,0x5e30f592ea940b10,
0xd4b1eadf0c1b453d,0x0f542b7048400374,0xec92b43d25c3d7d4,0x420fdac6835f535d,
0xf03ce130909dc213,0xdde43b280f51567c,0xffe271a35b951f3d,0x3cab74908b7aca2f,
0xd804efd8059fa3b8,0x77fd8064bfd8076f,0x0ae592b0085fb008,0xb1e43f5216d85fb0,
0xf00f2ec2057283ca,0xda63608c7fbb3e41,0xfe2f1e6b6ca1c397,0x61b913df41a814be,
0xb30f4b338cb6c463,0xf531e188ecb92af4,0xc3eb1ea8d663d332,0x9cbc3ef4127ff568,
0xf108f008ddd3a361,0x1785c5d4ea883b44,0x5e8d90d0c83814a8,0xa59826561d4e6862,
0xcd579c1682bcb6ce,0x20d539824c372178,0xb50d1b1da33a3f01,0x87bde7def7bbbad8,
0x5ef7af7e027c6117,0x8ddd50d64eb7e133,0xc3ded6256def6ef7,0x894e7d2d5a31f85d,
0xcd6c2a0ae742c38e,0x6431565a33cb9c18,0x69d9936d8c9d347d,0xa7ace0c3c333448e,
0xaf704c9c8a53dcf5,0x1614722bcc1b9e9c,0x289088462b949b4c,0xd2a264b1d1cb463b,
0xd165b6d8e9d8cfcc,0x924b479625a3cbe2,0xd1cacda07843910f,0x7f78b9b6b97b06a2,
0x5be0e989b740f63c,0xca0807689fddacdb,0x7364a83d28753181,0x58597c194b076c6a,
0xf7936eb660146c4f,0x6df82bbbfb8671dd,0xf04bedf855e3f04b,0xc093f04b1df85513,
0x8cacd71426521367,0x8fab7185a35422d1,0x0dc99190f3726dce,0xaae01778ddba2747,
0xe560be68f963c261,0x825d69fb861b0e2b,0xc95b02e9980e3c4b,0x18dde3c53b9323e6,
0x18ec25fb71021c41,0x15931056930ec526,0x45264c12feb2b441,0x4e0c21498c3336af,
0xa184048c2c6d6ee5,0xbb0490559a31462b,0x0c16a18028acc923,0x414986115ba0db7b,
0x5daeed7232d41e53,0xa63a3b409ba274b1,0x19e6ac23b30eb8e6,0x6a1ee3db95219cb6,
0x779808620c42a4d2,0x4210ee4949bb6b1e,0x4eed2858ba50c769,0x56e74d5bfe9e6d28,
0x0962ee6087d0e6be,0xdbd310f5c6732340,0x8867916426d1876e,0x8f923eafa25af959,
0x425602681d8e9a0e,0xb077e4f0bb6c03dc,0xda1f77cc162d6c8d,0x59c51d60898abb61,
0x1d8abec0c5c43a3a,0x193c3a064e9d032c,0x2b950033ced7d2b0,0x3b5689986ab244cc,
0x12a9b012a9b884cc,0x643ed0e0dd0b906d,0x62593bee6f4c67ef,0xc44a098876e4cc3a,
0x23898e46771c8faa,0xdc7ce371c4c42ac3,0xbbaac71cd3a71b04,0xafcda0d98314d6a0,
0xbbe30feb7c30ea01,0x6af5c04de375b85b,0x72fbff96ee443e50,0xefefcd17f06f62b8,
0x64bd277aca8ca8ee,0x1d3835d5fc6e955c,0xd14a6c7b10bafe26,0x0dbdff130fadf130,
0xb655c59303df09cc,0xecf8a74b9ad3e12e,0xc49f937d4159d2e5,0xb098f722155fe9a0,
0x051983c12ed3b57f,0xd96d4f55f5e12365,0xcb7a9c78db351cb1,0xc78db31de6a1e36c,
0xc6d980f0b4387c1d,0xefc2e15f0b9d4f43,0xc3cd2ca3fcb77796,0x24534c24fd85e6df,
0x6f8f1a171d91bf32,0xe9984867f3b5e660,0xb3e99913afd732d3,0x9255de59b8dfa631,
0xdbf718d237e79bca,0xb6f5053d3f7f70c9,0x338591d42d74fd85,0xc23ff5cffe812cf4,
0x3f68a3d34ff06c7e,0xf88f11d83f989521,0x89bf99a7ec17bdb8,0x6674ff9817a75c2f,
0xb5ffb927a59ff303,0xf3037d832492e45d,0x17c08fb32ddef6e7,0x2be808f67f934560,
0xfc82a4f9b236161a,0x4f4c4a4a0dc0fe55,0xdda61be6efd049cd,0x4e138e83e324fb3f,
0x6cb73f6034cd996d,0x2f9b99126bdfd8bb,0x1dfbc7cd7bf4324b,0xd1cf94ea0feadc40,
0xe7d518f007a6e74b,0x65ca27bd2f31969b,0x1cacdf6491bfb7ed,0xc8bf166f80c8d722,
0x78c723ab3ae177a4,0x7cf761e3665b4b9e,0xbe9082a61e3c1c60,0xf797e87e3b39aef2,
0xdefd617ad71d81b3,0xa6c72378cd1bf181,0x2c1f1639fc053d59,0x7fd79f15b222595f,
0x3e56fe3dfe59fc01,0xb94ff4249143cc6e,0xc16de56d53ba5de6,0x1794bedbeddccfc9,
0xea94f059964d6e5f,0xb454dbc0d3f8e973,0xb41ae05af0f7a963,0xe5f73babe1e4aa56,
0x70b8621637cfc7a9,0x3e5d97d2f7c5d278,0x006b8f6497c2b658,0x9fec841de1e336cb,
0xd67fbc3cdfdf12aa,0x4547dde4a91a03c2,0x5e1573ff447093de,0x0ab3780907d7878f,
0x543c9303dbc3c06f,0xd3de06bf787aa785,0x95e1f78794f7f255,0x115657787aaf79d5,
0xef0f0def374bd7fb,0xf24bc95b595bc02f,0xefc7de2c9221faca,0x2c375f08eb24b839,
0x112ff89b7af0f69f,0x0d71f0ebbc59d2d6,0x05e4127bf89a0643,0x2e23791512ea1e4c,
0xba2bc3ddb78b8d5e,0x709bc3cfaf174178,0x1589d4b3de2e42f1,0xe4ceaf260378094b,
0x304b591ccc357ee1,0x934bcee91efce4d7,0x3bfe46d4f531abc9,0xc4ca50ecb707f633,
0xf98bcac6fffeced1,0xf612ac31cd4272b1,0xfab958ad5edb8ff3,0x00000019ea6c1317,
0x0000011801010001,0x00000000000005b0,0x0000004000000000,0x0000001e00040000,
0x0000009800000078,0x0000000000001046,0x0000000000000000,0x0000000000001db3,
0x0000002c00000048,0x6e6f642d2d20672d,0x2d656772656d2d74,0x6f6c626369736162,
0x65722d2d20736b63,0x2d74612d6e727574,0x0000000020646e65,0x73726573552f3a43,
0x6c4f2078656c412f,0x75636f442f6e6573,0x65572f73746e656d,0x696c6c694b206465,
0x616573655220676e,0x6a6f725020686372,0x67616d492f746365,0x7365636f72502065,
0x73795320676e6973,0x747365542f6d6574,0x6d6172676f725020,0x206567616d492f73,
0x69737365636f7250,0x7269766e4520676e,0x432f746e656d6e6f,0x6e72654b20414455,
0x657268742f736c65,0x75632e646c6f6873,0x0000000000000000,0x36e46b5b58e59c78,
0x085883fe40de7e14,0x52c955f248f530b4,0x76d2e87d943e97ba,0xcb89945cc32c3429,
0x7fe969213db0678c,0xb765cf24b6476eaf,0x973a5b20f2681b49,0xb3f3a3c8e7477cef,
0x3729baf1dd1ffb73,0xbd69dade2c224a15,0xd08f1893d66a2de4,0x2c5d3b314b76cf82,
0xa383fca69334de6a,0x105fc5729bbd2a98,0x6c2363f8e5edf2f4,0xd571fa3df8af5f8c,
0x79addf336efc6af0,0xf7a05f395fe336d5,0x6f13f44b56556ae5,0xe6f50fa2df9eb4f8,
0x4ba7ac3fc76f3e77,0xf9f894bac2e6df2e,0x5a6f0bfc7af969a1,0xfa9426eba7acbd39,
0x8c3d254deb2bbabe,0x75e7bd1af77c7edf,0x6f3015bdb8cd57c5,0x211cbddf3445ab37,
0x08d9c59c73466092,0xb6729b2dc3a16925,0xfc9a03f5ca1228e2,0x257dfc5287d2acc6,
0x98bb4517e153b664,0xd3a3c138b513eb86,0xf8b944f47289c8e4,0x70853fb3f3ebecfc,
0x8bde82d6da2897cd,0x46b982bdbf822bed,0x54a72668afd45fa8,0x722294111ccdabcc,
0x5f1993e6abb3767e,0x0ae42f2bd4be1596,0xa5ca8904cfcee5f6,0x97bd742327517382,
0x9e407a7c81574f8c,0x7c80e9e40767c80c,0x7e522af2963e407e,0xdebb60197370c3cf,
0x462c18cee6f5a9ca,0x7f7445cb4ede62e8,0x7a616abe62679fd5,0x885444c50c4612b7,
0x03988842a399abd6,0x844ab23f203b5115,0x54485543a408295c,0xc78d7079e2d41b3d,
0x53408c940021e800,0x40e0f481a95ab988,0x076890d52d5aa2d2,0x92d1b76f0d484989,
0x810478db1717854b,0x369416c2d36af148,0xeacd19e277e7d2b6,0x1098a84f06f37a29,
0x5b513bd52aaed1cf,0xf960ba8df2193d52,0x72625856c709e21b,0x8a9599f468acc871,
0xa234c44499441d2f,0x4f5589273d4a22cc,0x985f62d21705c0bc,0x1d3b49d6a4a48a69,
0x6516647c9d025582,0x2366ab5459aed0ea,0x9a2aedfb45110df4,0x377750ab48f92b69,
0x30faeb9753a78da9,0x055975cb5cdc16a9,0x6ee5dc5112ca6b2e,0x2c2ac9ae6db1a4fa,
0xc3d675c75647b959,0xc69b075ce4b61b1b,0x8b7753616269b083,0x5a6a892a6945b152,
0x3f49293fa52d7535,0x7bc889b72d66856b,0x9081878a3f977278,0x17618c888176080e,
0xb7585b76a830d106,0x911c486001eb13dd,0xa8cdd15cb4b56f35,0x8db5ea97f396c85a,
0x7633a91bb1e4ff38,0xc4badb241b375652,0x0cc8159a3623c99c,0xf3566ce9d91bccd8,
0x17019881e894bd3b,0x330c112c03c310f0,0x98cd78128d4a5bd4,0x8cd4f5dc4e7ccd19,
0x16a00222a6466649,0xa45ef313f6bb9654,0xe812de26400d2900,0xc2ec50e821106964,
0xe67b07e03a2f99cb,0xa0e484606091a8ad,0xba83db242119f6cb,0x316d47c1ee9d7dc8,
0xd8cb9752fe169186,0x8067630db9f852b5,0x8633c4e2a1b6b809,0x956f99c10ecb493d,
0xcc88ddb905005c79,0x98597ee3d16c1ff3,0xd31c09271d2f7083,0x9a536d85971f8ad0,
0x2dec5fce9d9087ec,0x1219e97bf99b60b1,0x88355b84825f3199,0x7a7d6ca2bc7733bd,
0x455842da15ea03ad,0x921fd052fec14761,0x503333a24b6f73dc,0xb266d00b2d766158,
0x3d7bb7a11fa2ae81,0x45d0e86ee25efc5e,0xce828ba538a97519,0xa8bb71fe6b517513,
0x67828145dbfff48d,0xff4a6d45d45ffc58,0x2efa7c898cfa2eed,0x347ea8bbc9f3eb6a,
0x6092859cfc9aca32,0xb5bf553e90230c90,0x70383fe83f61c329,0xea633122c13a339f,
0x8cfe9dabbd0b0ab3,0x150a431413d1d5fc,0xc0e04713583d3816,0x3340ba1f8cf69201,
0xe3d4fa75d281cd5b,0x41e7f12811c24dcc,0x30e80ce0f2504321,0xa262e3dc16283dc5,
0x88de2fe38124f483,0x5a4626e076370b8f,0x7162d0ec8f75b1de,0x713e01c8daf1e2c2,
0x4a440dc8c80493e1,0xf569af67fa048c81,0xf157dc716ccded7c,0x74b6e822a3c2be99,
0x069d880e3e08ea6f,0xadff9a47ec181f08,0x73b55413a3acd6e7,0x8f640d01b0a23942,
0x1a0fcca818816ee4,0x995f457aff160bab,0x6bcee611ae960be8,0xbb2c7b598a7cf79c,
0x761cca9aea066835,0x213dbbd065ca6ba8,0xc713a338635e00ee,0x295318137e028b94,
0x2fdb4c0eb7ed5e73,0x64c75d466df8c1b6,0x1cffc316cec41b70,0x790d9fb6a5bd751c,
0xb8f17a7ce1c5dc4f,0x780137fe94f00c16,0x6412701abbdd0726,0x1b3184faea323407,
0xf2a3f429b8ec0832,0x41c5c4e8ca8e1c4c,0x6eedd7a81a7ec193,0x10a257b1bcd74d56,
0x33353dbca88df0f7,0xecf619c0aa54eee6,0x0330e706044cec3e,0xf17dd5f8ea5ab4f5,
0x000000971ba8c4df
};
#pragma data_seg()

#ifdef __cplusplus
}
#endif

#ifdef __cplusplus
extern "C" {
#endif
#pragma data_seg(".nvFatBinSegment")
__declspec(allocate(__CUDAFATBINSECTION)) __declspec(align(8)) static const __fatBinC_Wrapper_t __fatDeviceText= 
	{ 0x466243b1, 1, fatbinData, 0 };
#pragma data_seg()
#ifdef __cplusplus
}
#endif
