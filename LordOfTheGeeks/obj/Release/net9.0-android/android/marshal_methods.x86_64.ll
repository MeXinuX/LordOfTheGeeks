; ModuleID = 'marshal_methods.x86_64.ll'
source_filename = "marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [135 x ptr] zeroinitializer, align 16

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [405 x i64] [
	i64 u0x0071cf2d27b7d61e, ; 0: lib_Xamarin.AndroidX.SwipeRefreshLayout.dll.so => 77
	i64 u0x02123411c4e01926, ; 1: lib_Xamarin.AndroidX.Navigation.Runtime.dll.so => 73
	i64 u0x022e81ea9c46e03a, ; 2: lib_CommunityToolkit.Maui.Core.dll.so => 36
	i64 u0x02abedc11addc1ed, ; 3: lib_Mono.Android.Runtime.dll.so => 133
	i64 u0x032267b2a94db371, ; 4: lib_Xamarin.AndroidX.AppCompat.dll.so => 56
	i64 u0x0363ac97a4cb84e6, ; 5: SQLitePCLRaw.provider.e_sqlite3.dll => 54
	i64 u0x043032f1d071fae0, ; 6: ru/Microsoft.Maui.Controls.resources => 24
	i64 u0x044440a55165631e, ; 7: lib-cs-Microsoft.Maui.Controls.resources.dll.so => 2
	i64 u0x046eb1581a80c6b0, ; 8: vi/Microsoft.Maui.Controls.resources => 30
	i64 u0x0517ef04e06e9f76, ; 9: System.Net.Primitives => 109
	i64 u0x0565d18c6da3de38, ; 10: Xamarin.AndroidX.RecyclerView => 75
	i64 u0x0581db89237110e9, ; 11: lib_System.Collections.dll.so => 89
	i64 u0x05989cb940b225a9, ; 12: Microsoft.Maui.dll => 47
	i64 u0x06076b5d2b581f08, ; 13: zh-HK/Microsoft.Maui.Controls.resources => 31
	i64 u0x0680a433c781bb3d, ; 14: Xamarin.AndroidX.Collection.Jvm => 59
	i64 u0x07c57877c7ba78ad, ; 15: ru/Microsoft.Maui.Controls.resources.dll => 24
	i64 u0x07dcdc7460a0c5e4, ; 16: System.Collections.NonGeneric => 87
	i64 u0x08f3c9788ee2153c, ; 17: Xamarin.AndroidX.DrawerLayout => 64
	i64 u0x0919c28b89381a0b, ; 18: lib_Microsoft.Extensions.Options.dll.so => 43
	i64 u0x092266563089ae3e, ; 19: lib_System.Collections.NonGeneric.dll.so => 87
	i64 u0x09d144a7e214d457, ; 20: System.Security.Cryptography => 121
	i64 u0x0b3b632c3bbee20c, ; 21: sk/Microsoft.Maui.Controls.resources => 25
	i64 u0x0b6aff547b84fbe9, ; 22: Xamarin.KotlinX.Serialization.Core.Jvm => 83
	i64 u0x0be2e1f8ce4064ed, ; 23: Xamarin.AndroidX.ViewPager => 78
	i64 u0x0c3ca6cc978e2aae, ; 24: pt-BR/Microsoft.Maui.Controls.resources => 21
	i64 u0x0c59ad9fbbd43abe, ; 25: Mono.Android => 134
	i64 u0x0c7790f60165fc06, ; 26: lib_Microsoft.Maui.Essentials.dll.so => 48
	i64 u0x0e14e73a54dda68e, ; 27: lib_System.Net.NameResolution.dll.so => 107
	i64 u0x102a31b45304b1da, ; 28: Xamarin.AndroidX.CustomView => 63
	i64 u0x10f6cfcbcf801616, ; 29: System.IO.Compression.Brotli => 98
	i64 u0x125b7f94acb989db, ; 30: Xamarin.AndroidX.RecyclerView.dll => 75
	i64 u0x13a01de0cbc3f06c, ; 31: lib-fr-Microsoft.Maui.Controls.resources.dll.so => 8
	i64 u0x13f1e5e209e91af4, ; 32: lib_Java.Interop.dll.so => 132
	i64 u0x13f1e880c25d96d1, ; 33: he/Microsoft.Maui.Controls.resources => 9
	i64 u0x143d8ea60a6a4011, ; 34: Microsoft.Extensions.DependencyInjection.Abstractions => 40
	i64 u0x16bf2a22df043a09, ; 35: System.IO.Pipes.dll => 101
	i64 u0x17125c9a85b4929f, ; 36: lib_netstandard.dll.so => 130
	i64 u0x17b56e25558a5d36, ; 37: lib-hu-Microsoft.Maui.Controls.resources.dll.so => 12
	i64 u0x17f9358913beb16a, ; 38: System.Text.Encodings.Web => 122
	i64 u0x18402a709e357f3b, ; 39: lib_Xamarin.KotlinX.Serialization.Core.Jvm.dll.so => 83
	i64 u0x18f0ce884e87d89a, ; 40: nb/Microsoft.Maui.Controls.resources.dll => 18
	i64 u0x1a91866a319e9259, ; 41: lib_System.Collections.Concurrent.dll.so => 85
	i64 u0x1aac34d1917ba5d3, ; 42: lib_System.dll.so => 129
	i64 u0x1aad60783ffa3e5b, ; 43: lib-th-Microsoft.Maui.Controls.resources.dll.so => 27
	i64 u0x1aea8f1c3b282172, ; 44: lib_System.Net.Ping.dll.so => 108
	i64 u0x1c753b5ff15bce1b, ; 45: Mono.Android.Runtime.dll => 133
	i64 u0x1e3d87657e9659bc, ; 46: Xamarin.AndroidX.Navigation.UI => 74
	i64 u0x1e71143913d56c10, ; 47: lib-ko-Microsoft.Maui.Controls.resources.dll.so => 16
	i64 u0x1ed8fcce5e9b50a0, ; 48: Microsoft.Extensions.Options.dll => 43
	i64 u0x209375905fcc1bad, ; 49: lib_System.IO.Compression.Brotli.dll.so => 98
	i64 u0x20fab3cf2dfbc8df, ; 50: lib_System.Diagnostics.Process.dll.so => 95
	i64 u0x2174319c0d835bc9, ; 51: System.Runtime => 120
	i64 u0x220fd4f2e7c48170, ; 52: th/Microsoft.Maui.Controls.resources => 27
	i64 u0x224538d85ed15a82, ; 53: System.IO.Pipes => 101
	i64 u0x237be844f1f812c7, ; 54: System.Threading.Thread.dll => 125
	i64 u0x2407aef2bbe8fadf, ; 55: System.Console => 93
	i64 u0x240abe014b27e7d3, ; 56: Xamarin.AndroidX.Core.dll => 61
	i64 u0x252073cc3caa62c2, ; 57: fr/Microsoft.Maui.Controls.resources.dll => 8
	i64 u0x25a0a7eff76ea08e, ; 58: SQLitePCLRaw.batteries_v2.dll => 51
	i64 u0x2662c629b96b0b30, ; 59: lib_Xamarin.Kotlin.StdLib.dll.so => 81
	i64 u0x268c1439f13bcc29, ; 60: lib_Microsoft.Extensions.Primitives.dll.so => 44
	i64 u0x273f3515de5faf0d, ; 61: id/Microsoft.Maui.Controls.resources.dll => 13
	i64 u0x2742545f9094896d, ; 62: hr/Microsoft.Maui.Controls.resources => 11
	i64 u0x27b410442fad6cf1, ; 63: Java.Interop.dll => 132
	i64 u0x2801845a2c71fbfb, ; 64: System.Net.Primitives.dll => 109
	i64 u0x2a128783efe70ba0, ; 65: uk/Microsoft.Maui.Controls.resources.dll => 29
	i64 u0x2a6507a5ffabdf28, ; 66: System.Diagnostics.TraceSource.dll => 96
	i64 u0x2ad156c8e1354139, ; 67: fi/Microsoft.Maui.Controls.resources => 7
	i64 u0x2af298f63581d886, ; 68: System.Text.RegularExpressions.dll => 124
	i64 u0x2afc1c4f898552ee, ; 69: lib_System.Formats.Asn1.dll.so => 97
	i64 u0x2b148910ed40fbf9, ; 70: zh-Hant/Microsoft.Maui.Controls.resources.dll => 33
	i64 u0x2c8bd14bb93a7d82, ; 71: lib-pl-Microsoft.Maui.Controls.resources.dll.so => 20
	i64 u0x2d169d318a968379, ; 72: System.Threading.dll => 126
	i64 u0x2d47774b7d993f59, ; 73: sv/Microsoft.Maui.Controls.resources.dll => 26
	i64 u0x2db915caf23548d2, ; 74: System.Text.Json.dll => 123
	i64 u0x2e6f1f226821322a, ; 75: el/Microsoft.Maui.Controls.resources.dll => 5
	i64 u0x2f02f94df3200fe5, ; 76: System.Diagnostics.Process => 95
	i64 u0x2f2e98e1c89b1aff, ; 77: System.Xml.ReaderWriter => 128
	i64 u0x309ee9eeec09a71e, ; 78: lib_Xamarin.AndroidX.Fragment.dll.so => 65
	i64 u0x31195fef5d8fb552, ; 79: _Microsoft.Android.Resource.Designer.dll => 34
	i64 u0x32243413e774362a, ; 80: Xamarin.AndroidX.CardView.dll => 58
	i64 u0x329753a17a517811, ; 81: fr/Microsoft.Maui.Controls.resources => 8
	i64 u0x32aa989ff07a84ff, ; 82: lib_System.Xml.ReaderWriter.dll.so => 128
	i64 u0x33829542f112d59b, ; 83: System.Collections.Immutable => 86
	i64 u0x33a31443733849fe, ; 84: lib-es-Microsoft.Maui.Controls.resources.dll.so => 6
	i64 u0x341abc357fbb4ebf, ; 85: lib_System.Net.Sockets.dll.so => 111
	i64 u0x34dfd74fe2afcf37, ; 86: Microsoft.Maui => 47
	i64 u0x34e292762d9615df, ; 87: cs/Microsoft.Maui.Controls.resources.dll => 2
	i64 u0x3508234247f48404, ; 88: Microsoft.Maui.Controls => 45
	i64 u0x3549870798b4cd30, ; 89: lib_Xamarin.AndroidX.ViewPager2.dll.so => 79
	i64 u0x355282fc1c909694, ; 90: Microsoft.Extensions.Configuration => 37
	i64 u0x380134e03b1e160a, ; 91: System.Collections.Immutable.dll => 86
	i64 u0x385c17636bb6fe6e, ; 92: Xamarin.AndroidX.CustomView.dll => 63
	i64 u0x38869c811d74050e, ; 93: System.Net.NameResolution.dll => 107
	i64 u0x393c226616977fdb, ; 94: lib_Xamarin.AndroidX.ViewPager.dll.so => 78
	i64 u0x395e37c3334cf82a, ; 95: lib-ca-Microsoft.Maui.Controls.resources.dll.so => 1
	i64 u0x3c7c495f58ac5ee9, ; 96: Xamarin.Kotlin.StdLib => 81
	i64 u0x3d9c2a242b040a50, ; 97: lib_Xamarin.AndroidX.Core.dll.so => 61
	i64 u0x3da7781d6333a8fe, ; 98: SQLitePCLRaw.batteries_v2 => 51
	i64 u0x407a10bb4bf95829, ; 99: lib_Xamarin.AndroidX.Navigation.Common.dll.so => 71
	i64 u0x41cab042be111c34, ; 100: lib_Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so => 57
	i64 u0x43375950ec7c1b6a, ; 101: netstandard.dll => 130
	i64 u0x434c4e1d9284cdae, ; 102: Mono.Android.dll => 134
	i64 u0x43950f84de7cc79a, ; 103: pl/Microsoft.Maui.Controls.resources.dll => 20
	i64 u0x4515080865a951a5, ; 104: Xamarin.Kotlin.StdLib.dll => 81
	i64 u0x45c40276a42e283e, ; 105: System.Diagnostics.TraceSource => 96
	i64 u0x46a4213bc97fe5ae, ; 106: lib-ru-Microsoft.Maui.Controls.resources.dll.so => 24
	i64 u0x47daf4e1afbada10, ; 107: pt/Microsoft.Maui.Controls.resources => 22
	i64 u0x49e952f19a4e2022, ; 108: System.ObjectModel => 113
	i64 u0x4a5667b2462a664b, ; 109: lib_Xamarin.AndroidX.Navigation.UI.dll.so => 74
	i64 u0x4b7b6532ded934b7, ; 110: System.Text.Json => 123
	i64 u0x4c7755cf07ad2d5f, ; 111: System.Net.Http.Json.dll => 105
	i64 u0x4cc5f15266470798, ; 112: lib_Xamarin.AndroidX.Loader.dll.so => 70
	i64 u0x4d479f968a05e504, ; 113: System.Linq.Expressions.dll => 102
	i64 u0x4d55a010ffc4faff, ; 114: System.Private.Xml => 115
	i64 u0x4d95fccc1f67c7ca, ; 115: System.Runtime.Loader.dll => 118
	i64 u0x4dcf44c3c9b076a2, ; 116: it/Microsoft.Maui.Controls.resources.dll => 14
	i64 u0x4dd9247f1d2c3235, ; 117: Xamarin.AndroidX.Loader.dll => 70
	i64 u0x4e32f00cb0937401, ; 118: Mono.Android.Runtime => 133
	i64 u0x4f21ee6ef9eb527e, ; 119: ca/Microsoft.Maui.Controls.resources => 1
	i64 u0x4fd5f3ee53d0a4f0, ; 120: SQLitePCLRaw.lib.e_sqlite3.android => 53
	i64 u0x5037f0be3c28c7a3, ; 121: lib_Microsoft.Maui.Controls.dll.so => 45
	i64 u0x5131bbe80989093f, ; 122: Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll => 68
	i64 u0x526ce79eb8e90527, ; 123: lib_System.Net.Primitives.dll.so => 109
	i64 u0x529ffe06f39ab8db, ; 124: Xamarin.AndroidX.Core => 61
	i64 u0x52ff996554dbf352, ; 125: Microsoft.Maui.Graphics => 49
	i64 u0x535f7e40e8fef8af, ; 126: lib-sk-Microsoft.Maui.Controls.resources.dll.so => 25
	i64 u0x53be1038a61e8d44, ; 127: System.Runtime.InteropServices.RuntimeInformation.dll => 116
	i64 u0x53c3014b9437e684, ; 128: lib-zh-HK-Microsoft.Maui.Controls.resources.dll.so => 31
	i64 u0x54795225dd1587af, ; 129: lib_System.Runtime.dll.so => 120
	i64 u0x556e8b63b660ab8b, ; 130: Xamarin.AndroidX.Lifecycle.Common.Jvm.dll => 66
	i64 u0x5588627c9a108ec9, ; 131: System.Collections.Specialized => 88
	i64 u0x55f8b48f0aee284c, ; 132: lib_LordOfTheGeeks.dll.so => 84
	i64 u0x571c5cfbec5ae8e2, ; 133: System.Private.Uri => 114
	i64 u0x578cd35c91d7b347, ; 134: lib_SQLitePCLRaw.core.dll.so => 52
	i64 u0x579a06fed6eec900, ; 135: System.Private.CoreLib.dll => 131
	i64 u0x57c542c14049b66d, ; 136: System.Diagnostics.DiagnosticSource => 94
	i64 u0x58601b2dda4a27b9, ; 137: lib-ja-Microsoft.Maui.Controls.resources.dll.so => 15
	i64 u0x58688d9af496b168, ; 138: Microsoft.Extensions.DependencyInjection.dll => 39
	i64 u0x5a89a886ae30258d, ; 139: lib_Xamarin.AndroidX.CoordinatorLayout.dll.so => 60
	i64 u0x5a8f6699f4a1caa9, ; 140: lib_System.Threading.dll.so => 126
	i64 u0x5ae9cd33b15841bf, ; 141: System.ComponentModel => 92
	i64 u0x5b5f0e240a06a2a2, ; 142: da/Microsoft.Maui.Controls.resources.dll => 3
	i64 u0x5c393624b8176517, ; 143: lib_Microsoft.Extensions.Logging.dll.so => 41
	i64 u0x5db0cbbd1028510e, ; 144: lib_System.Runtime.InteropServices.dll.so => 117
	i64 u0x5db30905d3e5013b, ; 145: Xamarin.AndroidX.Collection.Jvm.dll => 59
	i64 u0x5e467bc8f09ad026, ; 146: System.Collections.Specialized.dll => 88
	i64 u0x5ea92fdb19ec8c4c, ; 147: System.Text.Encodings.Web.dll => 122
	i64 u0x5eb8046dd40e9ac3, ; 148: System.ComponentModel.Primitives => 90
	i64 u0x5f36ccf5c6a57e24, ; 149: System.Xml.ReaderWriter.dll => 128
	i64 u0x5f7399e166075632, ; 150: lib_SQLitePCLRaw.lib.e_sqlite3.android.dll.so => 53
	i64 u0x5f9a2d823f664957, ; 151: lib-el-Microsoft.Maui.Controls.resources.dll.so => 5
	i64 u0x609f4b7b63d802d4, ; 152: lib_Microsoft.Extensions.DependencyInjection.dll.so => 39
	i64 u0x60cd4e33d7e60134, ; 153: Xamarin.KotlinX.Coroutines.Core.Jvm => 82
	i64 u0x60f62d786afcf130, ; 154: System.Memory => 104
	i64 u0x61be8d1299194243, ; 155: Microsoft.Maui.Controls.Xaml => 46
	i64 u0x61d2cba29557038f, ; 156: de/Microsoft.Maui.Controls.resources => 4
	i64 u0x61d88f399afb2f45, ; 157: lib_System.Runtime.Loader.dll.so => 118
	i64 u0x622eef6f9e59068d, ; 158: System.Private.CoreLib => 131
	i64 u0x63f1f6883c1e23c2, ; 159: lib_System.Collections.Immutable.dll.so => 86
	i64 u0x6400f68068c1e9f1, ; 160: Xamarin.Google.Android.Material.dll => 80
	i64 u0x658f524e4aba7dad, ; 161: CommunityToolkit.Maui.dll => 35
	i64 u0x65ecac39144dd3cc, ; 162: Microsoft.Maui.Controls.dll => 45
	i64 u0x65ece51227bfa724, ; 163: lib_System.Runtime.Numerics.dll.so => 119
	i64 u0x6692e924eade1b29, ; 164: lib_System.Console.dll.so => 93
	i64 u0x66a4e5c6a3fb0bae, ; 165: lib_Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll.so => 68
	i64 u0x66d13304ce1a3efa, ; 166: Xamarin.AndroidX.CursorAdapter => 62
	i64 u0x68558ec653afa616, ; 167: lib-da-Microsoft.Maui.Controls.resources.dll.so => 3
	i64 u0x68fbbbe2eb455198, ; 168: System.Formats.Asn1 => 97
	i64 u0x69063fc0ba8e6bdd, ; 169: he/Microsoft.Maui.Controls.resources.dll => 9
	i64 u0x699dffb2427a2d71, ; 170: SQLitePCLRaw.lib.e_sqlite3.android.dll => 53
	i64 u0x6a4d7577b2317255, ; 171: System.Runtime.InteropServices.dll => 117
	i64 u0x6ace3b74b15ee4a4, ; 172: nb/Microsoft.Maui.Controls.resources => 18
	i64 u0x6d12bfaa99c72b1f, ; 173: lib_Microsoft.Maui.Graphics.dll.so => 49
	i64 u0x6d79993361e10ef2, ; 174: Microsoft.Extensions.Primitives => 44
	i64 u0x6d86d56b84c8eb71, ; 175: lib_Xamarin.AndroidX.CursorAdapter.dll.so => 62
	i64 u0x6d9bea6b3e895cf7, ; 176: Microsoft.Extensions.Primitives.dll => 44
	i64 u0x6e25a02c3833319a, ; 177: lib_Xamarin.AndroidX.Navigation.Fragment.dll.so => 72
	i64 u0x6efbcb2716bfd2ec, ; 178: LordOfTheGeeks => 84
	i64 u0x6fd2265da78b93a4, ; 179: lib_Microsoft.Maui.dll.so => 47
	i64 u0x6fdfc7de82c33008, ; 180: cs/Microsoft.Maui.Controls.resources => 2
	i64 u0x70e99f48c05cb921, ; 181: tr/Microsoft.Maui.Controls.resources.dll => 28
	i64 u0x70fd3deda22442d2, ; 182: lib-nb-Microsoft.Maui.Controls.resources.dll.so => 18
	i64 u0x71a495ea3761dde8, ; 183: lib-it-Microsoft.Maui.Controls.resources.dll.so => 14
	i64 u0x71ad672adbe48f35, ; 184: System.ComponentModel.Primitives.dll => 90
	i64 u0x72b1fb4109e08d7b, ; 185: lib-hr-Microsoft.Maui.Controls.resources.dll.so => 11
	i64 u0x73e4ce94e2eb6ffc, ; 186: lib_System.Memory.dll.so => 104
	i64 u0x7441449d776035f5, ; 187: LordOfTheGeeks.dll => 84
	i64 u0x755a91767330b3d4, ; 188: lib_Microsoft.Extensions.Configuration.dll.so => 37
	i64 u0x76012e7334db86e5, ; 189: lib_Xamarin.AndroidX.SavedState.dll.so => 76
	i64 u0x76ca07b878f44da0, ; 190: System.Runtime.Numerics.dll => 119
	i64 u0x780bc73597a503a9, ; 191: lib-ms-Microsoft.Maui.Controls.resources.dll.so => 17
	i64 u0x783606d1e53e7a1a, ; 192: th/Microsoft.Maui.Controls.resources.dll => 27
	i64 u0x78a45e51311409b6, ; 193: Xamarin.AndroidX.Fragment.dll => 65
	i64 u0x7adb8da2ac89b647, ; 194: fi/Microsoft.Maui.Controls.resources.dll => 7
	i64 u0x7bef86a4335c4870, ; 195: System.ComponentModel.TypeConverter => 91
	i64 u0x7c0820144cd34d6a, ; 196: sk/Microsoft.Maui.Controls.resources.dll => 25
	i64 u0x7c2a0bd1e0f988fc, ; 197: lib-de-Microsoft.Maui.Controls.resources.dll.so => 4
	i64 u0x7cc637f941f716d0, ; 198: CommunityToolkit.Maui.Core => 36
	i64 u0x7d649b75d580bb42, ; 199: ms/Microsoft.Maui.Controls.resources.dll => 17
	i64 u0x7d8ee2bdc8e3aad1, ; 200: System.Numerics.Vectors => 112
	i64 u0x7dfc3d6d9d8d7b70, ; 201: System.Collections => 89
	i64 u0x7e946809d6008ef2, ; 202: lib_System.ObjectModel.dll.so => 113
	i64 u0x7ecc13347c8fd849, ; 203: lib_System.ComponentModel.dll.so => 92
	i64 u0x7f00ddd9b9ca5a13, ; 204: Xamarin.AndroidX.ViewPager.dll => 78
	i64 u0x7f9351cd44b1273f, ; 205: Microsoft.Extensions.Configuration.Abstractions => 38
	i64 u0x7fbd557c99b3ce6f, ; 206: lib_Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so => 67
	i64 u0x80fa55b6d1b0be99, ; 207: SQLitePCLRaw.provider.e_sqlite3 => 54
	i64 u0x812c069d5cdecc17, ; 208: System.dll => 129
	i64 u0x81ab745f6c0f5ce6, ; 209: zh-Hant/Microsoft.Maui.Controls.resources => 33
	i64 u0x8277f2be6b5ce05f, ; 210: Xamarin.AndroidX.AppCompat => 56
	i64 u0x828f06563b30bc50, ; 211: lib_Xamarin.AndroidX.CardView.dll.so => 58
	i64 u0x82f6403342e12049, ; 212: uk/Microsoft.Maui.Controls.resources => 29
	i64 u0x83144699b312ad81, ; 213: SQLite-net.dll => 50
	i64 u0x83c14ba66c8e2b8c, ; 214: zh-Hans/Microsoft.Maui.Controls.resources => 32
	i64 u0x84ae73148a4557d2, ; 215: lib_System.IO.Pipes.dll.so => 101
	i64 u0x86a909228dc7657b, ; 216: lib-zh-Hant-Microsoft.Maui.Controls.resources.dll.so => 33
	i64 u0x86b3e00c36b84509, ; 217: Microsoft.Extensions.Configuration.dll => 37
	i64 u0x87c69b87d9283884, ; 218: lib_System.Threading.Thread.dll.so => 125
	i64 u0x87f6569b25707834, ; 219: System.IO.Compression.Brotli.dll => 98
	i64 u0x8842b3a5d2d3fb36, ; 220: Microsoft.Maui.Essentials => 48
	i64 u0x88bda98e0cffb7a9, ; 221: lib_Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so => 82
	i64 u0x8930322c7bd8f768, ; 222: netstandard => 130
	i64 u0x897a606c9e39c75f, ; 223: lib_System.ComponentModel.Primitives.dll.so => 90
	i64 u0x89c5188089ec2cd5, ; 224: lib_System.Runtime.InteropServices.RuntimeInformation.dll.so => 116
	i64 u0x8ad229ea26432ee2, ; 225: Xamarin.AndroidX.Loader => 70
	i64 u0x8b4ff5d0fdd5faa1, ; 226: lib_System.Diagnostics.DiagnosticSource.dll.so => 94
	i64 u0x8b8d01333a96d0b5, ; 227: System.Diagnostics.Process.dll => 95
	i64 u0x8b9ceca7acae3451, ; 228: lib-he-Microsoft.Maui.Controls.resources.dll.so => 9
	i64 u0x8d0f420977c2c1c7, ; 229: Xamarin.AndroidX.CursorAdapter.dll => 62
	i64 u0x8d7b8ab4b3310ead, ; 230: System.Threading => 126
	i64 u0x8da188285aadfe8e, ; 231: System.Collections.Concurrent => 85
	i64 u0x8ed807bfe9858dfc, ; 232: Xamarin.AndroidX.Navigation.Common => 71
	i64 u0x8ee08b8194a30f48, ; 233: lib-hi-Microsoft.Maui.Controls.resources.dll.so => 10
	i64 u0x8ef7601039857a44, ; 234: lib-ro-Microsoft.Maui.Controls.resources.dll.so => 23
	i64 u0x8ef9414937d93a0a, ; 235: SQLitePCLRaw.core.dll => 52
	i64 u0x8f32c6f611f6ffab, ; 236: pt/Microsoft.Maui.Controls.resources.dll => 22
	i64 u0x8f8829d21c8985a4, ; 237: lib-pt-BR-Microsoft.Maui.Controls.resources.dll.so => 21
	i64 u0x8fd27d934d7b3a55, ; 238: SQLitePCLRaw.core => 52
	i64 u0x90263f8448b8f572, ; 239: lib_System.Diagnostics.TraceSource.dll.so => 96
	i64 u0x903101b46fb73a04, ; 240: _Microsoft.Android.Resource.Designer => 34
	i64 u0x90393bd4865292f3, ; 241: lib_System.IO.Compression.dll.so => 99
	i64 u0x90634f86c5ebe2b5, ; 242: Xamarin.AndroidX.Lifecycle.ViewModel.Android => 68
	i64 u0x907b636704ad79ef, ; 243: lib_Microsoft.Maui.Controls.Xaml.dll.so => 46
	i64 u0x91418dc638b29e68, ; 244: lib_Xamarin.AndroidX.CustomView.dll.so => 63
	i64 u0x9157bd523cd7ed36, ; 245: lib_System.Text.Json.dll.so => 123
	i64 u0x91a74f07b30d37e2, ; 246: System.Linq.dll => 103
	i64 u0x91fa41a87223399f, ; 247: ca/Microsoft.Maui.Controls.resources.dll => 1
	i64 u0x93cfa73ab28d6e35, ; 248: ms/Microsoft.Maui.Controls.resources => 17
	i64 u0x944077d8ca3c6580, ; 249: System.IO.Compression.dll => 99
	i64 u0x967fc325e09bfa8c, ; 250: es/Microsoft.Maui.Controls.resources => 6
	i64 u0x9732d8dbddea3d9a, ; 251: id/Microsoft.Maui.Controls.resources => 13
	i64 u0x978be80e5210d31b, ; 252: Microsoft.Maui.Graphics.dll => 49
	i64 u0x97b8c771ea3e4220, ; 253: System.ComponentModel.dll => 92
	i64 u0x97e144c9d3c6976e, ; 254: System.Collections.Concurrent.dll => 85
	i64 u0x991d510397f92d9d, ; 255: System.Linq.Expressions => 102
	i64 u0x99a00ca5270c6878, ; 256: Xamarin.AndroidX.Navigation.Runtime => 73
	i64 u0x99cdc6d1f2d3a72f, ; 257: ko/Microsoft.Maui.Controls.resources.dll => 16
	i64 u0x9d5dbcf5a48583fe, ; 258: lib_Xamarin.AndroidX.Activity.dll.so => 55
	i64 u0x9d74dee1a7725f34, ; 259: Microsoft.Extensions.Configuration.Abstractions.dll => 38
	i64 u0x9e4534b6adaf6e84, ; 260: nl/Microsoft.Maui.Controls.resources => 19
	i64 u0x9eaf1efdf6f7267e, ; 261: Xamarin.AndroidX.Navigation.Common.dll => 71
	i64 u0x9ef542cf1f78c506, ; 262: Xamarin.AndroidX.Lifecycle.LiveData.Core => 67
	i64 u0xa0d8259f4cc284ec, ; 263: lib_System.Security.Cryptography.dll.so => 121
	i64 u0xa1440773ee9d341e, ; 264: Xamarin.Google.Android.Material => 80
	i64 u0xa1b9d7c27f47219f, ; 265: Xamarin.AndroidX.Navigation.UI.dll => 74
	i64 u0xa2572680829d2c7c, ; 266: System.IO.Pipelines.dll => 100
	i64 u0xa46aa1eaa214539b, ; 267: ko/Microsoft.Maui.Controls.resources => 16
	i64 u0xa5e599d1e0524750, ; 268: System.Numerics.Vectors.dll => 112
	i64 u0xa5f1ba49b85dd355, ; 269: System.Security.Cryptography.dll => 121
	i64 u0xa67dbee13e1df9ca, ; 270: Xamarin.AndroidX.SavedState.dll => 76
	i64 u0xa68a420042bb9b1f, ; 271: Xamarin.AndroidX.DrawerLayout.dll => 64
	i64 u0xa78ce3745383236a, ; 272: Xamarin.AndroidX.Lifecycle.Common.Jvm => 66
	i64 u0xa7c31b56b4dc7b33, ; 273: hu/Microsoft.Maui.Controls.resources => 12
	i64 u0xa964304b5631e28a, ; 274: CommunityToolkit.Maui.Core.dll => 36
	i64 u0xaa2219c8e3449ff5, ; 275: Microsoft.Extensions.Logging.Abstractions => 42
	i64 u0xaa443ac34067eeef, ; 276: System.Private.Xml.dll => 115
	i64 u0xaa52de307ef5d1dd, ; 277: System.Net.Http => 106
	i64 u0xaaaf86367285a918, ; 278: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 40
	i64 u0xaaf84bb3f052a265, ; 279: el/Microsoft.Maui.Controls.resources => 5
	i64 u0xab9c1b2687d86b0b, ; 280: lib_System.Linq.Expressions.dll.so => 102
	i64 u0xac2af3fa195a15ce, ; 281: System.Runtime.Numerics => 119
	i64 u0xac5376a2a538dc10, ; 282: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 67
	i64 u0xacd46e002c3ccb97, ; 283: ro/Microsoft.Maui.Controls.resources => 23
	i64 u0xad89c07347f1bad6, ; 284: nl/Microsoft.Maui.Controls.resources.dll => 19
	i64 u0xadbb53caf78a79d2, ; 285: System.Web.HttpUtility => 127
	i64 u0xadc90ab061a9e6e4, ; 286: System.ComponentModel.TypeConverter.dll => 91
	i64 u0xae282bcd03739de7, ; 287: Java.Interop => 132
	i64 u0xae53579c90db1107, ; 288: System.ObjectModel.dll => 113
	i64 u0xae7ea18c61eef394, ; 289: SQLite-net => 50
	i64 u0xafe29f45095518e7, ; 290: lib_Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll.so => 69
	i64 u0xb05cc42cd94c6d9d, ; 291: lib-sv-Microsoft.Maui.Controls.resources.dll.so => 26
	i64 u0xb220631954820169, ; 292: System.Text.RegularExpressions => 124
	i64 u0xb2a3f67f3bf29fce, ; 293: da/Microsoft.Maui.Controls.resources => 3
	i64 u0xb3f0a0fcda8d3ebc, ; 294: Xamarin.AndroidX.CardView => 58
	i64 u0xb46be1aa6d4fff93, ; 295: hi/Microsoft.Maui.Controls.resources => 10
	i64 u0xb477491be13109d8, ; 296: ar/Microsoft.Maui.Controls.resources => 0
	i64 u0xb4bd7015ecee9d86, ; 297: System.IO.Pipelines => 100
	i64 u0xb5c7fcdafbc67ee4, ; 298: Microsoft.Extensions.Logging.Abstractions.dll => 42
	i64 u0xb7b7753d1f319409, ; 299: sv/Microsoft.Maui.Controls.resources => 26
	i64 u0xb81a2c6e0aee50fe, ; 300: lib_System.Private.CoreLib.dll.so => 131
	i64 u0xb9f64d3b230def68, ; 301: lib-pt-Microsoft.Maui.Controls.resources.dll.so => 22
	i64 u0xb9fc3c8a556e3691, ; 302: ja/Microsoft.Maui.Controls.resources => 15
	i64 u0xba48785529705af9, ; 303: System.Collections.dll => 89
	i64 u0xbb65706fde942ce3, ; 304: System.Net.Sockets => 111
	i64 u0xbc22a245dab70cb4, ; 305: lib_SQLitePCLRaw.provider.e_sqlite3.dll.so => 54
	i64 u0xbd0e2c0d55246576, ; 306: System.Net.Http.dll => 106
	i64 u0xbd437a2cdb333d0d, ; 307: Xamarin.AndroidX.ViewPager2 => 79
	i64 u0xbee38d4a88835966, ; 308: Xamarin.AndroidX.AppCompat.AppCompatResources => 57
	i64 u0xbfc1e1fb3095f2b3, ; 309: lib_System.Net.Http.Json.dll.so => 105
	i64 u0xc040a4ab55817f58, ; 310: ar/Microsoft.Maui.Controls.resources.dll => 0
	i64 u0xc0d928351ab5ca77, ; 311: System.Console.dll => 93
	i64 u0xc12b8b3afa48329c, ; 312: lib_System.Linq.dll.so => 103
	i64 u0xc1ff9ae3cdb6e1e6, ; 313: Xamarin.AndroidX.Activity.dll => 55
	i64 u0xc28c50f32f81cc73, ; 314: ja/Microsoft.Maui.Controls.resources.dll => 15
	i64 u0xc2bcfec99f69365e, ; 315: Xamarin.AndroidX.ViewPager2.dll => 79
	i64 u0xc4d3858ed4d08512, ; 316: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 69
	i64 u0xc50fded0ded1418c, ; 317: lib_System.ComponentModel.TypeConverter.dll.so => 91
	i64 u0xc519125d6bc8fb11, ; 318: lib_System.Net.Requests.dll.so => 110
	i64 u0xc5293b19e4dc230e, ; 319: Xamarin.AndroidX.Navigation.Fragment => 72
	i64 u0xc5325b2fcb37446f, ; 320: lib_System.Private.Xml.dll.so => 115
	i64 u0xc5a0f4b95a699af7, ; 321: lib_System.Private.Uri.dll.so => 114
	i64 u0xc7ce851898a4548e, ; 322: lib_System.Web.HttpUtility.dll.so => 127
	i64 u0xc858a28d9ee5a6c5, ; 323: lib_System.Collections.Specialized.dll.so => 88
	i64 u0xc9e54b32fc19baf3, ; 324: lib_CommunityToolkit.Maui.dll.so => 35
	i64 u0xca3a723e7342c5b6, ; 325: lib-tr-Microsoft.Maui.Controls.resources.dll.so => 28
	i64 u0xcab3493c70141c2d, ; 326: pl/Microsoft.Maui.Controls.resources => 20
	i64 u0xcacfddc9f7c6de76, ; 327: ro/Microsoft.Maui.Controls.resources.dll => 23
	i64 u0xcbd4fdd9cef4a294, ; 328: lib__Microsoft.Android.Resource.Designer.dll.so => 34
	i64 u0xcc2876b32ef2794c, ; 329: lib_System.Text.RegularExpressions.dll.so => 124
	i64 u0xcc5c3bb714c4561e, ; 330: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 82
	i64 u0xcc76886e09b88260, ; 331: Xamarin.KotlinX.Serialization.Core.Jvm.dll => 83
	i64 u0xccf25c4b634ccd3a, ; 332: zh-Hans/Microsoft.Maui.Controls.resources.dll => 32
	i64 u0xcd10a42808629144, ; 333: System.Net.Requests => 110
	i64 u0xcdd0c48b6937b21c, ; 334: Xamarin.AndroidX.SwipeRefreshLayout => 77
	i64 u0xcf23d8093f3ceadf, ; 335: System.Diagnostics.DiagnosticSource.dll => 94
	i64 u0xd1194e1d8a8de83c, ; 336: lib_Xamarin.AndroidX.Lifecycle.Common.Jvm.dll.so => 66
	i64 u0xd333d0af9e423810, ; 337: System.Runtime.InteropServices => 117
	i64 u0xd3426d966bb704f5, ; 338: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 57
	i64 u0xd3651b6fc3125825, ; 339: System.Private.Uri.dll => 114
	i64 u0xd373685349b1fe8b, ; 340: Microsoft.Extensions.Logging.dll => 41
	i64 u0xd3e4c8d6a2d5d470, ; 341: it/Microsoft.Maui.Controls.resources => 14
	i64 u0xd4645626dffec99d, ; 342: lib_Microsoft.Extensions.DependencyInjection.Abstractions.dll.so => 40
	i64 u0xd5507e11a2b2839f, ; 343: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 69
	i64 u0xd6694f8359737e4e, ; 344: Xamarin.AndroidX.SavedState => 76
	i64 u0xd6d21782156bc35b, ; 345: Xamarin.AndroidX.SwipeRefreshLayout.dll => 77
	i64 u0xd72329819cbbbc44, ; 346: lib_Microsoft.Extensions.Configuration.Abstractions.dll.so => 38
	i64 u0xd7b3764ada9d341d, ; 347: lib_Microsoft.Extensions.Logging.Abstractions.dll.so => 42
	i64 u0xda1dfa4c534a9251, ; 348: Microsoft.Extensions.DependencyInjection => 39
	i64 u0xdad05a11827959a3, ; 349: System.Collections.NonGeneric.dll => 87
	i64 u0xdb5383ab5865c007, ; 350: lib-vi-Microsoft.Maui.Controls.resources.dll.so => 30
	i64 u0xdbeda89f832aa805, ; 351: vi/Microsoft.Maui.Controls.resources.dll => 30
	i64 u0xdbf9607a441b4505, ; 352: System.Linq => 103
	i64 u0xdce2c53525640bf3, ; 353: Microsoft.Extensions.Logging => 41
	i64 u0xdd2b722d78ef5f43, ; 354: System.Runtime.dll => 120
	i64 u0xdd67031857c72f96, ; 355: lib_System.Text.Encodings.Web.dll.so => 122
	i64 u0xdde30e6b77aa6f6c, ; 356: lib-zh-Hans-Microsoft.Maui.Controls.resources.dll.so => 32
	i64 u0xde8769ebda7d8647, ; 357: hr/Microsoft.Maui.Controls.resources.dll => 11
	i64 u0xdfa254ebb4346068, ; 358: System.Net.Ping => 108
	i64 u0xe0142572c095a480, ; 359: Xamarin.AndroidX.AppCompat.dll => 56
	i64 u0xe02f89350ec78051, ; 360: Xamarin.AndroidX.CoordinatorLayout.dll => 60
	i64 u0xe192a588d4410686, ; 361: lib_System.IO.Pipelines.dll.so => 100
	i64 u0xe1a08bd3fa539e0d, ; 362: System.Runtime.Loader => 118
	i64 u0xe2420585aeceb728, ; 363: System.Net.Requests.dll => 110
	i64 u0xe29b73bc11392966, ; 364: lib-id-Microsoft.Maui.Controls.resources.dll.so => 13
	i64 u0xe3811d68d4fe8463, ; 365: pt-BR/Microsoft.Maui.Controls.resources.dll => 21
	i64 u0xe3a586956771a0ed, ; 366: lib_SQLite-net.dll.so => 50
	i64 u0xe494f7ced4ecd10a, ; 367: hu/Microsoft.Maui.Controls.resources.dll => 12
	i64 u0xe4a9b1e40d1e8917, ; 368: lib-fi-Microsoft.Maui.Controls.resources.dll.so => 7
	i64 u0xe5434e8a119ceb69, ; 369: lib_Mono.Android.dll.so => 134
	i64 u0xedc4817167106c23, ; 370: System.Net.Sockets.dll => 111
	i64 u0xedc632067fb20ff3, ; 371: System.Memory.dll => 104
	i64 u0xedc8e4ca71a02a8b, ; 372: Xamarin.AndroidX.Navigation.Runtime.dll => 73
	i64 u0xeeb7ebb80150501b, ; 373: lib_Xamarin.AndroidX.Collection.Jvm.dll.so => 59
	i64 u0xef72742e1bcca27a, ; 374: Microsoft.Maui.Essentials.dll => 48
	i64 u0xefec0b7fdc57ec42, ; 375: Xamarin.AndroidX.Activity => 55
	i64 u0xf00c29406ea45e19, ; 376: es/Microsoft.Maui.Controls.resources.dll => 6
	i64 u0xf09e47b6ae914f6e, ; 377: System.Net.NameResolution => 107
	i64 u0xf11b621fc87b983f, ; 378: Microsoft.Maui.Controls.Xaml.dll => 46
	i64 u0xf1c4b4005493d871, ; 379: System.Formats.Asn1.dll => 97
	i64 u0xf238bd79489d3a96, ; 380: lib-nl-Microsoft.Maui.Controls.resources.dll.so => 19
	i64 u0xf37221fda4ef8830, ; 381: lib_Xamarin.Google.Android.Material.dll.so => 80
	i64 u0xf3ddfe05336abf29, ; 382: System => 129
	i64 u0xf4c1dd70a5496a17, ; 383: System.IO.Compression => 99
	i64 u0xf6077741019d7428, ; 384: Xamarin.AndroidX.CoordinatorLayout => 60
	i64 u0xf77b20923f07c667, ; 385: de/Microsoft.Maui.Controls.resources.dll => 4
	i64 u0xf7e2cac4c45067b3, ; 386: lib_System.Numerics.Vectors.dll.so => 112
	i64 u0xf7e74930e0e3d214, ; 387: zh-HK/Microsoft.Maui.Controls.resources.dll => 31
	i64 u0xf84773b5c81e3cef, ; 388: lib-uk-Microsoft.Maui.Controls.resources.dll.so => 29
	i64 u0xf8e045dc345b2ea3, ; 389: lib_Xamarin.AndroidX.RecyclerView.dll.so => 75
	i64 u0xf915dc29808193a1, ; 390: System.Web.HttpUtility.dll => 127
	i64 u0xf96c777a2a0686f4, ; 391: hi/Microsoft.Maui.Controls.resources.dll => 10
	i64 u0xf9eec5bb3a6aedc6, ; 392: Microsoft.Extensions.Options => 43
	i64 u0xfa5ed7226d978949, ; 393: lib-ar-Microsoft.Maui.Controls.resources.dll.so => 0
	i64 u0xfa645d91e9fc4cba, ; 394: System.Threading.Thread => 125
	i64 u0xfb022853d73b7fa5, ; 395: lib_SQLitePCLRaw.batteries_v2.dll.so => 51
	i64 u0xfb06dd2338e6f7c4, ; 396: System.Net.Ping.dll => 108
	i64 u0xfbf0a31c9fc34bc4, ; 397: lib_System.Net.Http.dll.so => 106
	i64 u0xfc719aec26adf9d9, ; 398: Xamarin.AndroidX.Navigation.Fragment.dll => 72
	i64 u0xfd22f00870e40ae0, ; 399: lib_Xamarin.AndroidX.DrawerLayout.dll.so => 64
	i64 u0xfd49b3c1a76e2748, ; 400: System.Runtime.InteropServices.RuntimeInformation => 116
	i64 u0xfd583f7657b6a1cb, ; 401: Xamarin.AndroidX.Fragment => 65
	i64 u0xfdbe4710aa9beeff, ; 402: CommunityToolkit.Maui => 35
	i64 u0xfeae9952cf03b8cb, ; 403: tr/Microsoft.Maui.Controls.resources => 28
	i64 u0xff9b54613e0d2cc8 ; 404: System.Net.Http.Json => 105
], align 16

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [405 x i32] [
	i32 77, i32 73, i32 36, i32 133, i32 56, i32 54, i32 24, i32 2,
	i32 30, i32 109, i32 75, i32 89, i32 47, i32 31, i32 59, i32 24,
	i32 87, i32 64, i32 43, i32 87, i32 121, i32 25, i32 83, i32 78,
	i32 21, i32 134, i32 48, i32 107, i32 63, i32 98, i32 75, i32 8,
	i32 132, i32 9, i32 40, i32 101, i32 130, i32 12, i32 122, i32 83,
	i32 18, i32 85, i32 129, i32 27, i32 108, i32 133, i32 74, i32 16,
	i32 43, i32 98, i32 95, i32 120, i32 27, i32 101, i32 125, i32 93,
	i32 61, i32 8, i32 51, i32 81, i32 44, i32 13, i32 11, i32 132,
	i32 109, i32 29, i32 96, i32 7, i32 124, i32 97, i32 33, i32 20,
	i32 126, i32 26, i32 123, i32 5, i32 95, i32 128, i32 65, i32 34,
	i32 58, i32 8, i32 128, i32 86, i32 6, i32 111, i32 47, i32 2,
	i32 45, i32 79, i32 37, i32 86, i32 63, i32 107, i32 78, i32 1,
	i32 81, i32 61, i32 51, i32 71, i32 57, i32 130, i32 134, i32 20,
	i32 81, i32 96, i32 24, i32 22, i32 113, i32 74, i32 123, i32 105,
	i32 70, i32 102, i32 115, i32 118, i32 14, i32 70, i32 133, i32 1,
	i32 53, i32 45, i32 68, i32 109, i32 61, i32 49, i32 25, i32 116,
	i32 31, i32 120, i32 66, i32 88, i32 84, i32 114, i32 52, i32 131,
	i32 94, i32 15, i32 39, i32 60, i32 126, i32 92, i32 3, i32 41,
	i32 117, i32 59, i32 88, i32 122, i32 90, i32 128, i32 53, i32 5,
	i32 39, i32 82, i32 104, i32 46, i32 4, i32 118, i32 131, i32 86,
	i32 80, i32 35, i32 45, i32 119, i32 93, i32 68, i32 62, i32 3,
	i32 97, i32 9, i32 53, i32 117, i32 18, i32 49, i32 44, i32 62,
	i32 44, i32 72, i32 84, i32 47, i32 2, i32 28, i32 18, i32 14,
	i32 90, i32 11, i32 104, i32 84, i32 37, i32 76, i32 119, i32 17,
	i32 27, i32 65, i32 7, i32 91, i32 25, i32 4, i32 36, i32 17,
	i32 112, i32 89, i32 113, i32 92, i32 78, i32 38, i32 67, i32 54,
	i32 129, i32 33, i32 56, i32 58, i32 29, i32 50, i32 32, i32 101,
	i32 33, i32 37, i32 125, i32 98, i32 48, i32 82, i32 130, i32 90,
	i32 116, i32 70, i32 94, i32 95, i32 9, i32 62, i32 126, i32 85,
	i32 71, i32 10, i32 23, i32 52, i32 22, i32 21, i32 52, i32 96,
	i32 34, i32 99, i32 68, i32 46, i32 63, i32 123, i32 103, i32 1,
	i32 17, i32 99, i32 6, i32 13, i32 49, i32 92, i32 85, i32 102,
	i32 73, i32 16, i32 55, i32 38, i32 19, i32 71, i32 67, i32 121,
	i32 80, i32 74, i32 100, i32 16, i32 112, i32 121, i32 76, i32 64,
	i32 66, i32 12, i32 36, i32 42, i32 115, i32 106, i32 40, i32 5,
	i32 102, i32 119, i32 67, i32 23, i32 19, i32 127, i32 91, i32 132,
	i32 113, i32 50, i32 69, i32 26, i32 124, i32 3, i32 58, i32 10,
	i32 0, i32 100, i32 42, i32 26, i32 131, i32 22, i32 15, i32 89,
	i32 111, i32 54, i32 106, i32 79, i32 57, i32 105, i32 0, i32 93,
	i32 103, i32 55, i32 15, i32 79, i32 69, i32 91, i32 110, i32 72,
	i32 115, i32 114, i32 127, i32 88, i32 35, i32 28, i32 20, i32 23,
	i32 34, i32 124, i32 82, i32 83, i32 32, i32 110, i32 77, i32 94,
	i32 66, i32 117, i32 57, i32 114, i32 41, i32 14, i32 40, i32 69,
	i32 76, i32 77, i32 38, i32 42, i32 39, i32 87, i32 30, i32 30,
	i32 103, i32 41, i32 120, i32 122, i32 32, i32 11, i32 108, i32 56,
	i32 60, i32 100, i32 118, i32 110, i32 13, i32 21, i32 50, i32 12,
	i32 7, i32 134, i32 111, i32 104, i32 73, i32 59, i32 48, i32 55,
	i32 6, i32 107, i32 46, i32 97, i32 19, i32 80, i32 129, i32 99,
	i32 60, i32 4, i32 112, i32 31, i32 29, i32 75, i32 127, i32 10,
	i32 43, i32 0, i32 125, i32 51, i32 108, i32 106, i32 72, i32 64,
	i32 116, i32 65, i32 35, i32 28, i32 105
], align 16

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 u0x0000000000000000, ; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 16

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nofree norecurse nosync nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { "no-trapping-math"="true" noreturn nounwind "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+crc32,+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/9.0.1xx @ e7876a4f92d894b40c191a24c2b74f06d4bf4573"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
