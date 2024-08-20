#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>


template <typename T1, typename T2, typename T3>
struct VirtualActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_virtual_invoke_data(slot, obj);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct GenericVirtualActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_virtual_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
struct InterfaceActionInvoker0
{
	typedef void (*Action)(void*, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1>
struct InterfaceActionInvoker1
{
	typedef void (*Action)(void*, T1, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct InterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};
template <typename R>
struct InterfaceFuncInvoker0
{
	typedef R (*Func)(void*, const RuntimeMethod*);

	static inline R Invoke (Il2CppMethodSlot slot, RuntimeClass* declaringInterface, RuntimeObject* obj)
	{
		const VirtualInvokeData& invokeData = il2cpp_codegen_get_interface_invoke_data(slot, obj, declaringInterface);
		return ((Func)invokeData.methodPtr)(obj, invokeData.method);
	}
};
template <typename T1, typename T2, typename T3>
struct GenericInterfaceActionInvoker3
{
	typedef void (*Action)(void*, T1, T2, T3, const RuntimeMethod*);

	static inline void Invoke (const RuntimeMethod* method, RuntimeObject* obj, T1 p1, T2 p2, T3 p3)
	{
		VirtualInvokeData invokeData;
		il2cpp_codegen_get_generic_interface_invoke_data(method, obj, &invokeData);
		((Action)invokeData.methodPtr)(obj, p1, p2, p3, invokeData.method);
	}
};

struct IEnumerator_1_t954B83675594270470C65F173F55E8AAEEE95A41;
struct IEnumerator_1_tFC6A1CB49A45C9198E5A5EC8CB8F1A9AC62D40F2;
struct IList_1_tD78714464F91CD31B7922DC3AC652CB242B17CC3;
struct IList_1_t9DF8D6F37197E40777D589C6874D1BEAAC22E03F;
struct List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183;
struct List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D;
struct List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8;
struct CharU5BU5D_t799905CF001DD5F13F7DBB310181FC4D8B7D0AAB;
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;
struct IChangeTokenU5BU5D_t8235E1D1D11DC79081170B4BE81359418450431A;
struct Int32U5BU5D_t19C97395396A72ECAF310612F0760F165060314C;
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
struct PostEvictionCallbackRegistrationU5BU5D_t948C00564B3E630BAD4F056B575A77FF4D954FFB;
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129;
struct ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F;
struct Delegate_t;
struct DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E;
struct ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B;
struct IChangeToken_tB14C21F22F312048580D1201C9162D542478E1E8;
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
struct MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C;
struct MethodInfo_t;
struct PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88;
struct PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4;
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
struct String_t;
struct SystemClock_t746A9D470820C3569C3A7D5622CAC8AB1F4A9BEE;
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;

IL2CPP_EXTERN_C RuntimeClass* ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICollection_1_t920E7170086F903FC3BF12B92F23C2A7E90492F7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* ICollection_1_tA2BA114AA0984296B4A4B5726B0D9FA953A904EE_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerable_1_t0D81CF3BA0ECA92EA8AE3B65AA009CE3FC31F3B6_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerable_1_tD0C13D9EFC8353DB4D8E8F1DB5C7A91E3A2305C2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerator_1_t954B83675594270470C65F173F55E8AAEEE95A41_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerator_1_tFC6A1CB49A45C9198E5A5EC8CB8F1A9AC62D40F2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteral46F273EF641E07D271D91E0DC24A4392582671F8;
IL2CPP_EXTERN_C String_t* _stringLiteralCF7DF948FC4905FED1A56776B9DFCCB86C46912A;
IL2CPP_EXTERN_C String_t* _stringLiteralD8A365180979BCD3C28DE1B0254E979F7D21306D;
IL2CPP_EXTERN_C String_t* _stringLiteralDC71B380AFF23A38F6029B32B61C6943CB960350;
IL2CPP_EXTERN_C String_t* _stringLiteralFFFD9E9DB7D22E3C6884E4D2ECA7BC7D58F53EF5;
IL2CPP_EXTERN_C const RuntimeMethod* CacheEntryExtensions_AddExpirationToken_mF52D97B909B2852C2B9704CD0055328D10FA0D58_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* CacheEntryExtensions_RegisterPostEvictionCallback_mF59853E49F4F5F02C2488566D19E4C98681136A6_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* CacheEntryExtensions_SetOptions_m91EACD54B90BA1214170BE6AD73EEB232CD41FB1_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_m3F2D9DE131AF14E888168691EF6D573932DE8A10_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* List_1__ctor_mA915907439E54DA9F02AC5F33BF6363FF54414FE_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* MemoryCacheEntryOptions_set_Size_m5AD4EAE6D7602764BD5182B744E86BA43AFD8D29_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_RuntimeMethod_var;
struct Delegate_t_marshaled_com;
struct Delegate_t_marshaled_pinvoke;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;

struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771;

IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
struct U3CModuleU3E_t8EC458AE02C339C69E34ED5295B72649BD3A22F4 
{
};
struct List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183  : public RuntimeObject
{
	IChangeTokenU5BU5D_t8235E1D1D11DC79081170B4BE81359418450431A* ____items;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8  : public RuntimeObject
{
	PostEvictionCallbackRegistrationU5BU5D_t948C00564B3E630BAD4F056B575A77FF4D954FFB* ____items;
	int32_t ____size;
	int32_t ____version;
	RuntimeObject* ____syncRoot;
};
struct CacheEntryExtensions_t309229525FEBBD7F1B4CBE8EE24D98E9D219FA5C  : public RuntimeObject
{
};
struct CacheExtensions_t3660D051DF69DC7F951EE56459125F45BF42B734  : public RuntimeObject
{
};
struct PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88  : public RuntimeObject
{
	PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* ___U3CEvictionCallbackU3Ek__BackingField;
	RuntimeObject* ___U3CStateU3Ek__BackingField;
};
struct String_t  : public RuntimeObject
{
	int32_t ____stringLength;
	Il2CppChar ____firstChar;
};
struct SystemClock_t746A9D470820C3569C3A7D5622CAC8AB1F4A9BEE  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};
struct Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 
{
	bool ___hasValue;
	int64_t ___value;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	bool ___m_value;
};
struct DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D 
{
	uint64_t ____dateData;
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2  : public ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_pinvoke
{
};
struct Enum_t2A1A94B24E3B776EEF4E5E485E290BB9D4D072E2_marshaled_com
{
};
struct Int64_t092CFB123BE63C28ACDAF65C68F21A526050DBA3 
{
	int64_t ___m_value;
};
struct IntPtr_t 
{
	void* ___m_value;
};
struct TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A 
{
	int64_t ____ticks;
};
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};
struct Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 
{
	bool ___hasValue;
	TimeSpan_t8195C5B013A2C532FEBDF0B64B6911982E750F5A ___value;
};
struct CacheItemPriority_tE684CF9FFB8A1304E07FC04B7AFA421273334E2A 
{
	int32_t ___value__;
};
struct DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 
{
	DateTime_t66193957C73913903DDAD89FEDC46139BCA5802D ____dateTime;
	int16_t ____offsetMinutes;
};
struct Delegate_t  : public RuntimeObject
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	RuntimeObject* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	bool ___method_is_virtual;
};
struct Delegate_t_marshaled_pinvoke
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct Delegate_t_marshaled_com
{
	intptr_t ___method_ptr;
	intptr_t ___invoke_impl;
	Il2CppIUnknown* ___m_target;
	intptr_t ___method;
	intptr_t ___delegate_trampoline;
	intptr_t ___extra_arg;
	intptr_t ___method_code;
	intptr_t ___interp_method;
	intptr_t ___interp_invoke_impl;
	MethodInfo_t* ___method_info;
	MethodInfo_t* ___original_method_info;
	DelegateData_t9B286B493293CD2D23A5B2B5EF0E5B1324C2B77E* ___data;
	int32_t ___method_is_virtual;
};
struct EvictionReason_tC85235A6CFA99DFEC1B57E23513EDF32D656A8AF 
{
	int32_t ___value__;
};
struct Exception_t  : public RuntimeObject
{
	String_t* ____className;
	String_t* ____message;
	RuntimeObject* ____data;
	Exception_t* ____innerException;
	String_t* ____helpURL;
	RuntimeObject* ____stackTrace;
	String_t* ____stackTraceString;
	String_t* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	RuntimeObject* ____dynamicMethods;
	int32_t ____HResult;
	String_t* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_pinvoke
{
	char* ____className;
	char* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_pinvoke* ____innerException;
	char* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	char* ____stackTraceString;
	char* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	char* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className;
	Il2CppChar* ____message;
	RuntimeObject* ____data;
	Exception_t_marshaled_com* ____innerException;
	Il2CppChar* ____helpURL;
	Il2CppIUnknown* ____stackTrace;
	Il2CppChar* ____stackTraceString;
	Il2CppChar* ____remoteStackTraceString;
	int32_t ____remoteStackIndex;
	Il2CppIUnknown* ____dynamicMethods;
	int32_t ____HResult;
	Il2CppChar* ____source;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces;
	Il2CppSafeArray* ___native_trace_ips;
	int32_t ___caught_in_unmanaged;
};
struct Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B 
{
	bool ___hasValue;
	DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 ___value;
};
struct MulticastDelegate_t  : public Delegate_t
{
	DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771* ___delegates;
};
struct MulticastDelegate_t_marshaled_pinvoke : public Delegate_t_marshaled_pinvoke
{
	Delegate_t_marshaled_pinvoke** ___delegates;
};
struct MulticastDelegate_t_marshaled_com : public Delegate_t_marshaled_com
{
	Delegate_t_marshaled_com** ___delegates;
};
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};
struct ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
	String_t* ____paramName;
};
struct MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C  : public RuntimeObject
{
	Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B ____absoluteExpiration;
	Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 ____absoluteExpirationRelativeToNow;
	Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 ____slidingExpiration;
	Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 ____size;
	RuntimeObject* ___U3CExpirationTokensU3Ek__BackingField;
	RuntimeObject* ___U3CPostEvictionCallbacksU3Ek__BackingField;
	int32_t ___U3CPriorityU3Ek__BackingField;
};
struct PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4  : public MulticastDelegate_t
{
};
struct ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
};
struct ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F  : public ArgumentException_tAD90411542A20A9C72D5CDA3A84181D8B947A263
{
	RuntimeObject* ____actualValue;
};
struct List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183_StaticFields
{
	IChangeTokenU5BU5D_t8235E1D1D11DC79081170B4BE81359418450431A* ___s_emptyArray;
};
struct List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8_StaticFields
{
	PostEvictionCallbackRegistrationU5BU5D_t948C00564B3E630BAD4F056B575A77FF4D954FFB* ___s_emptyArray;
};
struct String_t_StaticFields
{
	String_t* ___Empty;
};
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	String_t* ___TrueString;
	String_t* ___FalseString;
};
struct IntPtr_t_StaticFields
{
	intptr_t ___Zero;
};
struct DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4_StaticFields
{
	DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 ___MinValue;
	DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 ___MaxValue;
	DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 ___UnixEpoch;
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
struct DelegateU5BU5D_tC5AB7E8F745616680F337909D3A8E6C722CDF771  : public RuntimeArray
{
	ALIGN_FIELD (8) Delegate_t* m_Items[1];

	inline Delegate_t* GetAt(il2cpp_array_size_t index) const
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAt(il2cpp_array_size_t index)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		return m_Items + index;
	}
	inline void SetAt(il2cpp_array_size_t index, Delegate_t* value)
	{
		IL2CPP_ARRAY_BOUNDS_CHECK(index, (uint32_t)(this)->max_length);
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
	inline Delegate_t* GetAtUnchecked(il2cpp_array_size_t index) const
	{
		return m_Items[index];
	}
	inline Delegate_t** GetAddressAtUnchecked(il2cpp_array_size_t index)
	{
		return m_Items + index;
	}
	inline void SetAtUnchecked(il2cpp_array_size_t index, Delegate_t* value)
	{
		m_Items[index] = value;
		Il2CppCodeGenWriteBarrier((void**)m_Items + index, (void*)value);
	}
};


IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_gshared_inline (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_gshared_inline (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared (List_1_tA239CB83DE5615F348BB0507E45F490F4F7C9A8D* __this, const RuntimeMethod* method) ;

IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 DateTimeOffset_get_UtcNow_mD315065704E3FE153970E6BD06362AEDD3D9765F (const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* __this, String_t* ___0_paramName, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration__ctor_mC45ACA08E4AD62CA17F3EA00F1A0383DE926AD98 (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration_set_EvictionCallback_m571EB13791149B7FC6D32C0E26F34190229DAFDA_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration_set_State_m661F1D704730DE708E1659FDBAD5AA9CE8B1919F_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, RuntimeObject* ___0_value, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B MemoryCacheEntryOptions_get_AbsoluteExpiration_m1E6CDF0B762501B74E7E01CF942C8EE616F74A85_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 MemoryCacheEntryOptions_get_AbsoluteExpirationRelativeToNow_mE53AD9BF5D75E6DFD95EBEC8A662B0B2AC8597BF_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 MemoryCacheEntryOptions_get_SlidingExpiration_m1373FEE0586FE0DBAB6B7E5439CDD906DA446354_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MemoryCacheEntryOptions_get_Priority_m234BED13CAFEB65E98C56BE3AF2A24D0B2E0E1F5_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 MemoryCacheEntryOptions_get_Size_m0AFD60DD9B93CCA8D9590D3F873FAC1F83F0F4FB_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* MemoryCacheEntryOptions_get_ExpirationTokens_m080C9D4F10408E54E6C38D6A5410143FBA11A377_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CacheEntryExtensions_AddExpirationToken_mF52D97B909B2852C2B9704CD0055328D10FA0D58 (RuntimeObject* ___0_entry, RuntimeObject* ___1_expirationToken, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* MemoryCacheEntryOptions_get_PostEvictionCallbacks_mD0044504A34C8BA8F1F017359AD9698C607D85BD_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* PostEvictionCallbackRegistration_get_EvictionCallback_m5B314F47D0C95E00D759E4B77AECBE6B6F5C0E69_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) ;
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* PostEvictionCallbackRegistration_get_State_mBCA4277818EB46BFFB978C452E3FACF22E2DB6FA_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) ;
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CacheEntryExtensions_RegisterPostEvictionCallback_mF59853E49F4F5F02C2488566D19E4C98681136A6 (RuntimeObject* ___0_entry, PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* ___1_callback, RuntimeObject* ___2_state, const RuntimeMethod* method) ;
inline int64_t Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_inline (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17* __this, const RuntimeMethod* method)
{
	return ((  int64_t (*) (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17*, const RuntimeMethod*))Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_gshared_inline)(__this, method);
}
inline bool Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_inline (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17* __this, const RuntimeMethod* method)
{
	return ((  bool (*) (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17*, const RuntimeMethod*))Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_gshared_inline)(__this, method);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ArgumentOutOfRangeException__ctor_m60B543A63AC8692C28096003FBF2AD124B9D5B85 (ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F* __this, String_t* ___0_paramName, RuntimeObject* ___1_actualValue, String_t* ___2_message, const RuntimeMethod* method) ;
inline void List_1__ctor_mA915907439E54DA9F02AC5F33BF6363FF54414FE (List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
inline void List_1__ctor_m3F2D9DE131AF14E888168691EF6D573932DE8A10 (List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8* __this, const RuntimeMethod* method)
{
	((  void (*) (List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8*, const RuntimeMethod*))List_1__ctor_m7F078BB342729BDF11327FD89D7872265328F690_gshared)(__this, method);
}
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 SystemClock_get_UtcNow_m07B77C7C283F355CA666CD6EFB58FFD944177964 (SystemClock_t746A9D470820C3569C3A7D5622CAC8AB1F4A9BEE* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		il2cpp_codegen_runtime_class_init_inline(DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4_il2cpp_TypeInfo_var);
		DateTimeOffset_t4EE701FE2F386D6F932FAC9B11E4B74A5B30F0A4 L_0;
		L_0 = DateTimeOffset_get_UtcNow_mD315065704E3FE153970E6BD06362AEDD3D9765F(NULL);
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void SystemClock__ctor_m8A880F3A4E5AA291B8D0ACAF46CA4FBE593DD717 (SystemClock_t746A9D470820C3569C3A7D5622CAC8AB1F4A9BEE* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CacheEntryExtensions_AddExpirationToken_mF52D97B909B2852C2B9704CD0055328D10FA0D58 (RuntimeObject* ___0_entry, RuntimeObject* ___1_expirationToken, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_t920E7170086F903FC3BF12B92F23C2A7E90492F7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___1_expirationToken;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_1 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralFFFD9E9DB7D22E3C6884E4D2ECA7BC7D58F53EF5)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&CacheEntryExtensions_AddExpirationToken_mF52D97B909B2852C2B9704CD0055328D10FA0D58_RuntimeMethod_var)));
	}

IL_000e:
	{
		RuntimeObject* L_2 = ___0_entry;
		RuntimeObject* L_3;
		L_3 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(4, ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var, L_2);
		RuntimeObject* L_4 = ___1_expirationToken;
		InterfaceActionInvoker1< RuntimeObject* >::Invoke(2, ICollection_1_t920E7170086F903FC3BF12B92F23C2A7E90492F7_il2cpp_TypeInfo_var, L_3, L_4);
		RuntimeObject* L_5 = ___0_entry;
		return L_5;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CacheEntryExtensions_RegisterPostEvictionCallback_mF59853E49F4F5F02C2488566D19E4C98681136A6 (RuntimeObject* ___0_entry, PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* ___1_callback, RuntimeObject* ___2_state, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICollection_1_tA2BA114AA0984296B4A4B5726B0D9FA953A904EE_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* L_0 = ___1_callback;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_1 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralDC71B380AFF23A38F6029B32B61C6943CB960350)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&CacheEntryExtensions_RegisterPostEvictionCallback_mF59853E49F4F5F02C2488566D19E4C98681136A6_RuntimeMethod_var)));
	}

IL_000e:
	{
		RuntimeObject* L_2 = ___0_entry;
		RuntimeObject* L_3;
		L_3 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(5, ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var, L_2);
		PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* L_4 = (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88*)il2cpp_codegen_object_new(PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88_il2cpp_TypeInfo_var);
		PostEvictionCallbackRegistration__ctor_mC45ACA08E4AD62CA17F3EA00F1A0383DE926AD98(L_4, NULL);
		PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* L_5 = L_4;
		PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* L_6 = ___1_callback;
		PostEvictionCallbackRegistration_set_EvictionCallback_m571EB13791149B7FC6D32C0E26F34190229DAFDA_inline(L_5, L_6, NULL);
		PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* L_7 = L_5;
		RuntimeObject* L_8 = ___2_state;
		PostEvictionCallbackRegistration_set_State_m661F1D704730DE708E1659FDBAD5AA9CE8B1919F_inline(L_7, L_8, NULL);
		InterfaceActionInvoker1< PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* >::Invoke(2, ICollection_1_tA2BA114AA0984296B4A4B5726B0D9FA953A904EE_il2cpp_TypeInfo_var, L_3, L_7);
		RuntimeObject* L_9 = ___0_entry;
		return L_9;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* CacheEntryExtensions_SetOptions_m91EACD54B90BA1214170BE6AD73EEB232CD41FB1 (RuntimeObject* ___0_entry, MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* ___1_options, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerable_1_t0D81CF3BA0ECA92EA8AE3B65AA009CE3FC31F3B6_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerable_1_tD0C13D9EFC8353DB4D8E8F1DB5C7A91E3A2305C2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_1_t954B83675594270470C65F173F55E8AAEEE95A41_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_1_tFC6A1CB49A45C9198E5A5EC8CB8F1A9AC62D40F2_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	RuntimeObject* V_0 = NULL;
	RuntimeObject* V_1 = NULL;
	RuntimeObject* V_2 = NULL;
	PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* V_3 = NULL;
	{
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_0 = ___1_options;
		if (L_0)
		{
			goto IL_000e;
		}
	}
	{
		ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129* L_1 = (ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentNullException_t327031E412FAB2351B0022DD5DAD47E67E597129_il2cpp_TypeInfo_var)));
		ArgumentNullException__ctor_m444AE141157E333844FC1A9500224C2F9FD24F4B(L_1, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralCF7DF948FC4905FED1A56776B9DFCCB86C46912A)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_1, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&CacheEntryExtensions_SetOptions_m91EACD54B90BA1214170BE6AD73EEB232CD41FB1_RuntimeMethod_var)));
	}

IL_000e:
	{
		RuntimeObject* L_2 = ___0_entry;
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_3 = ___1_options;
		Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B L_4;
		L_4 = MemoryCacheEntryOptions_get_AbsoluteExpiration_m1E6CDF0B762501B74E7E01CF942C8EE616F74A85_inline(L_3, NULL);
		InterfaceActionInvoker1< Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B >::Invoke(1, ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var, L_2, L_4);
		RuntimeObject* L_5 = ___0_entry;
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_6 = ___1_options;
		Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 L_7;
		L_7 = MemoryCacheEntryOptions_get_AbsoluteExpirationRelativeToNow_mE53AD9BF5D75E6DFD95EBEC8A662B0B2AC8597BF_inline(L_6, NULL);
		InterfaceActionInvoker1< Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 >::Invoke(2, ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var, L_5, L_7);
		RuntimeObject* L_8 = ___0_entry;
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_9 = ___1_options;
		Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 L_10;
		L_10 = MemoryCacheEntryOptions_get_SlidingExpiration_m1373FEE0586FE0DBAB6B7E5439CDD906DA446354_inline(L_9, NULL);
		InterfaceActionInvoker1< Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 >::Invoke(3, ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var, L_8, L_10);
		RuntimeObject* L_11 = ___0_entry;
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_12 = ___1_options;
		int32_t L_13;
		L_13 = MemoryCacheEntryOptions_get_Priority_m234BED13CAFEB65E98C56BE3AF2A24D0B2E0E1F5_inline(L_12, NULL);
		InterfaceActionInvoker1< int32_t >::Invoke(6, ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var, L_11, L_13);
		RuntimeObject* L_14 = ___0_entry;
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_15 = ___1_options;
		Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 L_16;
		L_16 = MemoryCacheEntryOptions_get_Size_m0AFD60DD9B93CCA8D9590D3F873FAC1F83F0F4FB_inline(L_15, NULL);
		InterfaceActionInvoker1< Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 >::Invoke(7, ICacheEntry_t41BD68EBA052E8994B349B46C919A0E6A7E1D40B_il2cpp_TypeInfo_var, L_14, L_16);
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_17 = ___1_options;
		RuntimeObject* L_18;
		L_18 = MemoryCacheEntryOptions_get_ExpirationTokens_m080C9D4F10408E54E6C38D6A5410143FBA11A377_inline(L_17, NULL);
		RuntimeObject* L_19;
		L_19 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0, IEnumerable_1_t0D81CF3BA0ECA92EA8AE3B65AA009CE3FC31F3B6_il2cpp_TypeInfo_var, L_18);
		V_0 = L_19;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_0071:
			{
				{
					RuntimeObject* L_20 = V_0;
					if (!L_20)
					{
						goto IL_007a;
					}
				}
				{
					RuntimeObject* L_21 = V_0;
					InterfaceActionInvoker0::Invoke(0, IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var, L_21);
				}

IL_007a:
				{
					return;
				}
			}
		});
		try
		{
			{
				goto IL_0067_1;
			}

IL_0058_1:
			{
				RuntimeObject* L_22 = V_0;
				RuntimeObject* L_23;
				L_23 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0, IEnumerator_1_t954B83675594270470C65F173F55E8AAEEE95A41_il2cpp_TypeInfo_var, L_22);
				V_1 = L_23;
				RuntimeObject* L_24 = ___0_entry;
				RuntimeObject* L_25 = V_1;
				RuntimeObject* L_26;
				L_26 = CacheEntryExtensions_AddExpirationToken_mF52D97B909B2852C2B9704CD0055328D10FA0D58(L_24, L_25, NULL);
			}

IL_0067_1:
			{
				RuntimeObject* L_27 = V_0;
				bool L_28;
				L_28 = InterfaceFuncInvoker0< bool >::Invoke(0, IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var, L_27);
				if (L_28)
				{
					goto IL_0058_1;
				}
			}
			{
				goto IL_007b;
			}
		}
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_007b:
	{
		MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* L_29 = ___1_options;
		RuntimeObject* L_30;
		L_30 = MemoryCacheEntryOptions_get_PostEvictionCallbacks_mD0044504A34C8BA8F1F017359AD9698C607D85BD_inline(L_29, NULL);
		RuntimeObject* L_31;
		L_31 = InterfaceFuncInvoker0< RuntimeObject* >::Invoke(0, IEnumerable_1_tD0C13D9EFC8353DB4D8E8F1DB5C7A91E3A2305C2_il2cpp_TypeInfo_var, L_30);
		V_2 = L_31;
	}
	{
		auto __finallyBlock = il2cpp::utils::Finally([&]
		{

FINALLY_00ad:
			{
				{
					RuntimeObject* L_32 = V_2;
					if (!L_32)
					{
						goto IL_00b6;
					}
				}
				{
					RuntimeObject* L_33 = V_2;
					InterfaceActionInvoker0::Invoke(0, IDisposable_t030E0496B4E0E4E4F086825007979AF51F7248C5_il2cpp_TypeInfo_var, L_33);
				}

IL_00b6:
				{
					return;
				}
			}
		});
		try
		{
			{
				goto IL_00a3_1;
			}

IL_0089_1:
			{
				RuntimeObject* L_34 = V_2;
				PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* L_35;
				L_35 = InterfaceFuncInvoker0< PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* >::Invoke(0, IEnumerator_1_tFC6A1CB49A45C9198E5A5EC8CB8F1A9AC62D40F2_il2cpp_TypeInfo_var, L_34);
				V_3 = L_35;
				RuntimeObject* L_36 = ___0_entry;
				PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* L_37 = V_3;
				PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* L_38;
				L_38 = PostEvictionCallbackRegistration_get_EvictionCallback_m5B314F47D0C95E00D759E4B77AECBE6B6F5C0E69_inline(L_37, NULL);
				PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* L_39 = V_3;
				RuntimeObject* L_40;
				L_40 = PostEvictionCallbackRegistration_get_State_mBCA4277818EB46BFFB978C452E3FACF22E2DB6FA_inline(L_39, NULL);
				RuntimeObject* L_41;
				L_41 = CacheEntryExtensions_RegisterPostEvictionCallback_mF59853E49F4F5F02C2488566D19E4C98681136A6(L_36, L_38, L_40, NULL);
			}

IL_00a3_1:
			{
				RuntimeObject* L_42 = V_2;
				bool L_43;
				L_43 = InterfaceFuncInvoker0< bool >::Invoke(0, IEnumerator_t7B609C2FFA6EB5167D9C62A0C32A21DE2F666DAA_il2cpp_TypeInfo_var, L_42);
				if (L_43)
				{
					goto IL_0089_1;
				}
			}
			{
				goto IL_00b7;
			}
		}
		catch(Il2CppExceptionWrapper& e)
		{
			__finallyBlock.StoreException(e.ex);
		}
	}

IL_00b7:
	{
		RuntimeObject* L_44 = ___0_entry;
		return L_44;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B MemoryCacheEntryOptions_get_AbsoluteExpiration_m1E6CDF0B762501B74E7E01CF942C8EE616F74A85 (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B L_0 = __this->____absoluteExpiration;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 MemoryCacheEntryOptions_get_AbsoluteExpirationRelativeToNow_mE53AD9BF5D75E6DFD95EBEC8A662B0B2AC8597BF (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 L_0 = __this->____absoluteExpirationRelativeToNow;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 MemoryCacheEntryOptions_get_SlidingExpiration_m1373FEE0586FE0DBAB6B7E5439CDD906DA446354 (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 L_0 = __this->____slidingExpiration;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* MemoryCacheEntryOptions_get_ExpirationTokens_m080C9D4F10408E54E6C38D6A5410143FBA11A377 (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CExpirationTokensU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* MemoryCacheEntryOptions_get_PostEvictionCallbacks_mD0044504A34C8BA8F1F017359AD9698C607D85BD (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CPostEvictionCallbacksU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR int32_t MemoryCacheEntryOptions_get_Priority_m234BED13CAFEB65E98C56BE3AF2A24D0B2E0E1F5 (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CPriorityU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MemoryCacheEntryOptions_set_Priority_mD365A8BAF7A5994664E15DC232FAC5AE51102254 (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, int32_t ___0_value, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = ___0_value;
		__this->___U3CPriorityU3Ek__BackingField = L_0;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 MemoryCacheEntryOptions_get_Size_m0AFD60DD9B93CCA8D9590D3F873FAC1F83F0F4FB (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 L_0 = __this->____size;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MemoryCacheEntryOptions_set_Size_m5AD4EAE6D7602764BD5182B744E86BA43AFD8D29 (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 ___0_value, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_RuntimeMethod_var);
		s_Il2CppMethodInitialized = true;
	}
	Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 V_0;
	memset((&V_0), 0, sizeof(V_0));
	int64_t V_1 = 0;
	{
		Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 L_0 = ___0_value;
		V_0 = L_0;
		V_1 = ((int64_t)0);
		int64_t L_1;
		L_1 = Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_inline((&V_0), Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_RuntimeMethod_var);
		int64_t L_2 = V_1;
		bool L_3;
		L_3 = Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_inline((&V_0), Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_RuntimeMethod_var);
		if (!((int32_t)(((((int64_t)L_1) < ((int64_t)L_2))? 1 : 0)&(int32_t)L_3)))
		{
			goto IL_002f;
		}
	}
	{
		Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 L_4 = ___0_value;
		Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 L_5 = L_4;
		RuntimeObject* L_6 = Box(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17_il2cpp_TypeInfo_var)), &L_5);
		ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F* L_7 = (ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&ArgumentOutOfRangeException_tEA2822DAF62B10EEED00E0E3A341D4BAF78CF85F_il2cpp_TypeInfo_var)));
		ArgumentOutOfRangeException__ctor_m60B543A63AC8692C28096003FBF2AD124B9D5B85(L_7, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteral46F273EF641E07D271D91E0DC24A4392582671F8)), L_6, ((String_t*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&_stringLiteralD8A365180979BCD3C28DE1B0254E979F7D21306D)), NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_7, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&MemoryCacheEntryOptions_set_Size_m5AD4EAE6D7602764BD5182B744E86BA43AFD8D29_RuntimeMethod_var)));
	}

IL_002f:
	{
		Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 L_8 = ___0_value;
		__this->____size = L_8;
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void MemoryCacheEntryOptions__ctor_m081C30565768804AC0A098C251AB992632C96CA5 (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_m3F2D9DE131AF14E888168691EF6D573932DE8A10_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1__ctor_mA915907439E54DA9F02AC5F33BF6363FF54414FE_RuntimeMethod_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8_il2cpp_TypeInfo_var);
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183* L_0 = (List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183*)il2cpp_codegen_object_new(List_1_t24368CEB38F73B57121E4088A62D9C410B1D7183_il2cpp_TypeInfo_var);
		List_1__ctor_mA915907439E54DA9F02AC5F33BF6363FF54414FE(L_0, List_1__ctor_mA915907439E54DA9F02AC5F33BF6363FF54414FE_RuntimeMethod_var);
		__this->___U3CExpirationTokensU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CExpirationTokensU3Ek__BackingField), (void*)L_0);
		List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8* L_1 = (List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8*)il2cpp_codegen_object_new(List_1_t01CE6769D308C93101BD670D02FA293AFCA0FDE8_il2cpp_TypeInfo_var);
		List_1__ctor_m3F2D9DE131AF14E888168691EF6D573932DE8A10(L_1, List_1__ctor_m3F2D9DE131AF14E888168691EF6D573932DE8A10_RuntimeMethod_var);
		__this->___U3CPostEvictionCallbacksU3Ek__BackingField = L_1;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CPostEvictionCallbacksU3Ek__BackingField), (void*)L_1);
		__this->___U3CPriorityU3Ek__BackingField = 1;
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* PostEvictionCallbackRegistration_get_EvictionCallback_m5B314F47D0C95E00D759E4B77AECBE6B6F5C0E69 (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) 
{
	{
		PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* L_0 = __this->___U3CEvictionCallbackU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration_set_EvictionCallback_m571EB13791149B7FC6D32C0E26F34190229DAFDA (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* ___0_value, const RuntimeMethod* method) 
{
	{
		PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* L_0 = ___0_value;
		__this->___U3CEvictionCallbackU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CEvictionCallbackU3Ek__BackingField), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* PostEvictionCallbackRegistration_get_State_mBCA4277818EB46BFFB978C452E3FACF22E2DB6FA (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CStateU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration_set_State_m661F1D704730DE708E1659FDBAD5AA9CE8B1919F (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, RuntimeObject* ___0_value, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = ___0_value;
		__this->___U3CStateU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CStateU3Ek__BackingField), (void*)L_0);
		return;
	}
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration__ctor_mC45ACA08E4AD62CA17F3EA00F1A0383DE926AD98 (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_Multicast(PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method)
{
	il2cpp_array_size_t length = __this->___delegates->max_length;
	Delegate_t** delegatesToInvoke = reinterpret_cast<Delegate_t**>(__this->___delegates->GetAddressAtUnchecked(0));
	for (il2cpp_array_size_t i = 0; i < length; i++)
	{
		PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* currentDelegate = reinterpret_cast<PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4*>(delegatesToInvoke[i]);
		typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, RuntimeObject*, int32_t, RuntimeObject*, const RuntimeMethod*);
		((FunctionPointerType)currentDelegate->___invoke_impl)((Il2CppObject*)currentDelegate->___method_code, ___0_key, ___1_value, ___2_reason, ___3_state, reinterpret_cast<RuntimeMethod*>(currentDelegate->___method));
	}
}
void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenInst(PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, int32_t, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr)(___0_key, ___1_value, ___2_reason, ___3_state, method);
}
void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenStatic(PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method)
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, int32_t, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___method_ptr)(___0_key, ___1_value, ___2_reason, ___3_state, method);
}
void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenVirtual(PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method)
{
	VirtualActionInvoker3< RuntimeObject*, int32_t, RuntimeObject* >::Invoke(il2cpp_codegen_method_get_slot(method), ___0_key, ___1_value, ___2_reason, ___3_state);
}
void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenInterface(PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method)
{
	InterfaceActionInvoker3< RuntimeObject*, int32_t, RuntimeObject* >::Invoke(il2cpp_codegen_method_get_slot(method), il2cpp_codegen_method_get_declaring_type(method), ___0_key, ___1_value, ___2_reason, ___3_state);
}
void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenGenericVirtual(PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method)
{
	GenericVirtualActionInvoker3< RuntimeObject*, int32_t, RuntimeObject* >::Invoke(method, ___0_key, ___1_value, ___2_reason, ___3_state);
}
void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenGenericInterface(PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method)
{
	GenericInterfaceActionInvoker3< RuntimeObject*, int32_t, RuntimeObject* >::Invoke(method, ___0_key, ___1_value, ___2_reason, ___3_state);
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PostEvictionDelegate__ctor_m34B9EBFE4B5137D0B1C5265B5840CE7383EBB407 (PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_object, intptr_t ___1_method, const RuntimeMethod* method) 
{
	__this->___method_ptr = (intptr_t)il2cpp_codegen_get_method_pointer((RuntimeMethod*)___1_method);
	__this->___method = ___1_method;
	__this->___m_target = ___0_object;
	Il2CppCodeGenWriteBarrier((void**)(&__this->___m_target), (void*)___0_object);
	int parameterCount = il2cpp_codegen_method_parameter_count((RuntimeMethod*)___1_method);
	__this->___method_code = (intptr_t)__this;
	if (MethodIsStatic((RuntimeMethod*)___1_method))
	{
		bool isOpen = parameterCount == 4;
		if (isOpen)
			__this->___invoke_impl = (intptr_t)&PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenStatic;
		else
			{
				__this->___invoke_impl = __this->___method_ptr;
				__this->___method_code = (intptr_t)__this->___m_target;
			}
	}
	else
	{
		bool isOpen = parameterCount == 3;
		if (isOpen)
		{
			if (__this->___method_is_virtual)
			{
				if (il2cpp_codegen_method_is_generic_instance_method((RuntimeMethod*)___1_method))
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___1_method))
						__this->___invoke_impl = (intptr_t)&PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenGenericInterface;
					else
						__this->___invoke_impl = (intptr_t)&PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenGenericVirtual;
				else
					if (il2cpp_codegen_method_is_interface_method((RuntimeMethod*)___1_method))
						__this->___invoke_impl = (intptr_t)&PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenInterface;
					else
						__this->___invoke_impl = (intptr_t)&PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenVirtual;
			}
			else
			{
				__this->___invoke_impl = (intptr_t)&PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_OpenInst;
			}
		}
		else
		{
			if (___0_object == NULL)
				il2cpp_codegen_raise_exception(il2cpp_codegen_get_argument_exception(NULL, "Delegate to an instance method cannot have null 'this'."), NULL);
			__this->___invoke_impl = __this->___method_ptr;
			__this->___method_code = (intptr_t)__this->___m_target;
		}
	}
	__this->___extra_arg = (intptr_t)&PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65_Multicast;
}
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void PostEvictionDelegate_Invoke_mBF06E00FC0D06B6F682ACF92D30E01CDFDB8EF65 (PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* __this, RuntimeObject* ___0_key, RuntimeObject* ___1_value, int32_t ___2_reason, RuntimeObject* ___3_state, const RuntimeMethod* method) 
{
	typedef void (*FunctionPointerType) (RuntimeObject*, RuntimeObject*, RuntimeObject*, int32_t, RuntimeObject*, const RuntimeMethod*);
	((FunctionPointerType)__this->___invoke_impl)((Il2CppObject*)__this->___method_code, ___0_key, ___1_value, ___2_reason, ___3_state, reinterpret_cast<RuntimeMethod*>(__this->___method));
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration_set_EvictionCallback_m571EB13791149B7FC6D32C0E26F34190229DAFDA_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* ___0_value, const RuntimeMethod* method) 
{
	{
		PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* L_0 = ___0_value;
		__this->___U3CEvictionCallbackU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CEvictionCallbackU3Ek__BackingField), (void*)L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR void PostEvictionCallbackRegistration_set_State_m661F1D704730DE708E1659FDBAD5AA9CE8B1919F_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, RuntimeObject* ___0_value, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = ___0_value;
		__this->___U3CStateU3Ek__BackingField = L_0;
		Il2CppCodeGenWriteBarrier((void**)(&__this->___U3CStateU3Ek__BackingField), (void*)L_0);
		return;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B MemoryCacheEntryOptions_get_AbsoluteExpiration_m1E6CDF0B762501B74E7E01CF942C8EE616F74A85_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_t5127ABE6809BA32727C69CB2E076B28D676EB15B L_0 = __this->____absoluteExpiration;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 MemoryCacheEntryOptions_get_AbsoluteExpirationRelativeToNow_mE53AD9BF5D75E6DFD95EBEC8A662B0B2AC8597BF_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 L_0 = __this->____absoluteExpirationRelativeToNow;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 MemoryCacheEntryOptions_get_SlidingExpiration_m1373FEE0586FE0DBAB6B7E5439CDD906DA446354_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_tE151CE1F6892804B41C4004C95CB57020ABB3272 L_0 = __this->____slidingExpiration;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t MemoryCacheEntryOptions_get_Priority_m234BED13CAFEB65E98C56BE3AF2A24D0B2E0E1F5_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->___U3CPriorityU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 MemoryCacheEntryOptions_get_Size_m0AFD60DD9B93CCA8D9590D3F873FAC1F83F0F4FB_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17 L_0 = __this->____size;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* MemoryCacheEntryOptions_get_ExpirationTokens_m080C9D4F10408E54E6C38D6A5410143FBA11A377_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CExpirationTokensU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* MemoryCacheEntryOptions_get_PostEvictionCallbacks_mD0044504A34C8BA8F1F017359AD9698C607D85BD_inline (MemoryCacheEntryOptions_tC8C8F039F7C6DC42909C418D49B1257DA1625D6C* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CPostEvictionCallbacksU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* PostEvictionCallbackRegistration_get_EvictionCallback_m5B314F47D0C95E00D759E4B77AECBE6B6F5C0E69_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) 
{
	{
		PostEvictionDelegate_t319F384EE462B2BBCE0AA6D767F9C9952E4536E4* L_0 = __this->___U3CEvictionCallbackU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR RuntimeObject* PostEvictionCallbackRegistration_get_State_mBCA4277818EB46BFFB978C452E3FACF22E2DB6FA_inline (PostEvictionCallbackRegistration_tE434D60A824BB941CE624A58318AF5E70C45BA88* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CStateU3Ek__BackingField;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int64_t Nullable_1_GetValueOrDefault_m5270672823A1917D6D56F5ACF4AC1BA37A103FC5_gshared_inline (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17* __this, const RuntimeMethod* method) 
{
	{
		int64_t L_0 = __this->___value;
		return L_0;
	}
}
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR bool Nullable_1_get_HasValue_mB4991C0F4C2664AB3CB2584DEECF5BCE6AB7757D_gshared_inline (Nullable_1_t365991B3904FDA7642A788423B28692FDC7CDB17* __this, const RuntimeMethod* method) 
{
	{
		bool L_0 = __this->___hasValue;
		return L_0;
	}
}
