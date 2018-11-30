﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaExtendWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("LuaExtend");
		L.RegFunction("resGet", resGet);
		L.RegFunction("resRecyle", resRecyle);
		L.RegFunction("resUnLoad", resUnLoad);
		L.RegFunction("resDestroy", resDestroy);
		L.RegFunction("addRef", addRef);
		L.RegFunction("subRef", subRef);
		L.RegFunction("setSprite", setSprite);
		L.RegFunction("unloadSprite", unloadSprite);
		L.RegFunction("entityMgrCreate", entityMgrCreate);
		L.RegFunction("log", log);
		L.RegFunction("inputAddListener", inputAddListener);
		L.RegFunction("inputRemoveListener", inputRemoveListener);
		L.RegFunction("inputAddUpListener", inputAddUpListener);
		L.RegFunction("inputRemoveUpListener", inputRemoveUpListener);
		L.RegFunction("getUID", getUID);
		L.RegFunction("getVectorAngle", getVectorAngle);
		L.RegFunction("setUINode", setUINode);
		L.RegFunction("getNodeByRecursion", getNodeByRecursion);
		L.RegFunction("setMaterialFloat", setMaterialFloat);
		L.RegFunction("addEventListener", addEventListener);
		L.RegFunction("setObjPos", setObjPos);
		L.RegFunction("setActive", setActive);
		L.RegFunction("getAngle", getAngle);
		L.RegFunction("setParent2Role", setParent2Role);
		L.RegFunction("doUpDownScaleAnim", doUpDownScaleAnim);
		L.RegFunction("doLocalMoveTo", doLocalMoveTo);
		L.RegFunction("doFloatTo", doFloatTo);
		L.RegFunction("killTweener", killTweener);
		L.RegFunction("lerpRotation", lerpRotation);
		L.RegFunction("setCameraObj", setCameraObj);
		L.RegFunction("setCameraPlayer", setCameraPlayer);
		L.RegFunction("doShake", doShake);
		L.RegFunction("addSecHandler", addSecHandler);
		L.RegFunction("playEffect", playEffect);
		L.RegFunction("sendNetMsg", sendNetMsg);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resGet(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.GameObject> arg1 = (System.Action<UnityEngine.GameObject>)ToLua.CheckDelegate<System.Action<UnityEngine.GameObject>>(L, 2);
				LuaExtend.resGet(arg0, arg1);
				return 0;
			}
			else if (count == 3)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.GameObject> arg1 = (System.Action<UnityEngine.GameObject>)ToLua.CheckDelegate<System.Action<UnityEngine.GameObject>>(L, 2);
				E_PoolMode arg2 = (E_PoolMode)ToLua.CheckObject(L, 3, typeof(E_PoolMode));
				LuaExtend.resGet(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.GameObject> arg1 = (System.Action<UnityEngine.GameObject>)ToLua.CheckDelegate<System.Action<UnityEngine.GameObject>>(L, 2);
				E_PoolMode arg2 = (E_PoolMode)ToLua.CheckObject(L, 3, typeof(E_PoolMode));
				E_PoolType arg3 = (E_PoolType)ToLua.CheckObject(L, 4, typeof(E_PoolType));
				LuaExtend.resGet(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 5)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.GameObject> arg1 = (System.Action<UnityEngine.GameObject>)ToLua.CheckDelegate<System.Action<UnityEngine.GameObject>>(L, 2);
				E_PoolMode arg2 = (E_PoolMode)ToLua.CheckObject(L, 3, typeof(E_PoolMode));
				E_PoolType arg3 = (E_PoolType)ToLua.CheckObject(L, 4, typeof(E_PoolType));
				float arg4 = (float)LuaDLL.luaL_checknumber(L, 5);
				LuaExtend.resGet(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.resGet");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resRecyle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			LuaExtend.resRecyle(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resUnLoad(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string arg0 = ToLua.CheckString(L, 1);
			System.Action<UnityEngine.GameObject> arg1 = (System.Action<UnityEngine.GameObject>)ToLua.CheckDelegate<System.Action<UnityEngine.GameObject>>(L, 2);
			LuaExtend.resUnLoad(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resDestroy(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			LuaExtend.resDestroy(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addRef(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			LuaExtend.addRef(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int subRef(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				string arg0 = ToLua.CheckString(L, 1);
				LuaExtend.subRef(arg0);
				return 0;
			}
			else if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
				LuaExtend.subRef(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.subRef");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setSprite(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.Sprite,string> arg1 = (System.Action<UnityEngine.Sprite,string>)ToLua.CheckDelegate<System.Action<UnityEngine.Sprite,string>>(L, 2);
				LuaExtend.setSprite(arg0, arg1);
				return 0;
			}
			else if (count == 3)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.Sprite,string> arg1 = (System.Action<UnityEngine.Sprite,string>)ToLua.CheckDelegate<System.Action<UnityEngine.Sprite,string>>(L, 2);
				E_PoolMode arg2 = (E_PoolMode)ToLua.CheckObject(L, 3, typeof(E_PoolMode));
				LuaExtend.setSprite(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 4)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.Sprite,string> arg1 = (System.Action<UnityEngine.Sprite,string>)ToLua.CheckDelegate<System.Action<UnityEngine.Sprite,string>>(L, 2);
				E_PoolMode arg2 = (E_PoolMode)ToLua.CheckObject(L, 3, typeof(E_PoolMode));
				E_PoolType arg3 = (E_PoolType)ToLua.CheckObject(L, 4, typeof(E_PoolType));
				LuaExtend.setSprite(arg0, arg1, arg2, arg3);
				return 0;
			}
			else if (count == 5)
			{
				string arg0 = ToLua.CheckString(L, 1);
				System.Action<UnityEngine.Sprite,string> arg1 = (System.Action<UnityEngine.Sprite,string>)ToLua.CheckDelegate<System.Action<UnityEngine.Sprite,string>>(L, 2);
				E_PoolMode arg2 = (E_PoolMode)ToLua.CheckObject(L, 3, typeof(E_PoolMode));
				E_PoolType arg3 = (E_PoolType)ToLua.CheckObject(L, 4, typeof(E_PoolType));
				float arg4 = (float)LuaDLL.luaL_checknumber(L, 5);
				LuaExtend.setSprite(arg0, arg1, arg2, arg3, arg4);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.setSprite");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int unloadSprite(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			string arg0 = ToLua.CheckString(L, 1);
			System.Action<UnityEngine.Sprite,string> arg1 = (System.Action<UnityEngine.Sprite,string>)ToLua.CheckDelegate<System.Action<UnityEngine.Sprite,string>>(L, 2);
			LuaExtend.unloadSprite(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int entityMgrCreate(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			EntityData arg0 = (EntityData)ToLua.CheckObject<EntityData>(L, 1);
			BaseEntity o = LuaExtend.entityMgrCreate(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int log(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			LuaExtend.log(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int inputAddListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Action<UnityEngine.KeyCode> arg0 = (System.Action<UnityEngine.KeyCode>)ToLua.CheckDelegate<System.Action<UnityEngine.KeyCode>>(L, 1);
			LuaExtend.inputAddListener(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int inputRemoveListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Action<UnityEngine.KeyCode> arg0 = (System.Action<UnityEngine.KeyCode>)ToLua.CheckDelegate<System.Action<UnityEngine.KeyCode>>(L, 1);
			LuaExtend.inputRemoveListener(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int inputAddUpListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Action<UnityEngine.KeyCode> arg0 = (System.Action<UnityEngine.KeyCode>)ToLua.CheckDelegate<System.Action<UnityEngine.KeyCode>>(L, 1);
			LuaExtend.inputAddUpListener(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int inputRemoveUpListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			System.Action<UnityEngine.KeyCode> arg0 = (System.Action<UnityEngine.KeyCode>)ToLua.CheckDelegate<System.Action<UnityEngine.KeyCode>>(L, 1);
			LuaExtend.inputRemoveUpListener(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getUID(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int o = LuaExtend.getUID();
			LuaDLL.lua_pushinteger(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getVectorAngle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 1);
			UnityEngine.Vector2 arg1 = ToLua.ToVector2(L, 2);
			float o = LuaExtend.getVectorAngle(arg0, arg1);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setUINode(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			UnityEngine.GameObject arg1 = (UnityEngine.GameObject)ToLua.CheckObject(L, 2, typeof(UnityEngine.GameObject));
			int arg2 = (int)LuaDLL.luaL_checknumber(L, 3);
			LuaExtend.setUINode(arg0, arg1, arg2);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNodeByRecursion(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			string arg1 = ToLua.CheckString(L, 2);
			UnityEngine.GameObject o = LuaExtend.getNodeByRecursion(arg0, arg1);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setMaterialFloat(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.UI.Image arg0 = (UnityEngine.UI.Image)ToLua.CheckObject<UnityEngine.UI.Image>(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			LuaExtend.setMaterialFloat(arg0, arg1, arg2);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addEventListener(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			EventListener o = LuaExtend.addEventListener(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setObjPos(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 2);
				LuaExtend.setObjPos(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
				float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
				float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
				LuaExtend.setObjPos(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.setObjPos");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setActive(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			bool arg1 = LuaDLL.luaL_checkboolean(L, 2);
			LuaExtend.setActive(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAngle(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 1);
			float o = LuaExtend.getAngle(arg0);
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setParent2Role(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.Vector3 arg2 = ToLua.ToVector3(L, 3);
			LuaExtend.setParent2Role(arg0, arg1, arg2);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doUpDownScaleAnim(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				DG.Tweening.Tweener o = LuaExtend.doUpDownScaleAnim(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 2)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				string arg1 = ToLua.CheckString(L, 2);
				DG.Tweening.Tweener o = LuaExtend.doUpDownScaleAnim(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 3)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				string arg1 = ToLua.CheckString(L, 2);
				System.Action arg2 = (System.Action)ToLua.CheckDelegate<System.Action>(L, 3);
				DG.Tweening.Tweener o = LuaExtend.doUpDownScaleAnim(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.doUpDownScaleAnim");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doLocalMoveTo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 3)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.Vector3 arg2 = ToLua.ToVector3(L, 3);
				DG.Tweening.Tweener o = LuaExtend.doLocalMoveTo(arg0, arg1, arg2);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 4)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.Vector3 arg2 = ToLua.ToVector3(L, 3);
				DG.Tweening.TweenCallback arg3 = (DG.Tweening.TweenCallback)ToLua.CheckDelegate<DG.Tweening.TweenCallback>(L, 4);
				DG.Tweening.Tweener o = LuaExtend.doLocalMoveTo(arg0, arg1, arg2, arg3);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 5)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
				UnityEngine.Vector3 arg2 = ToLua.ToVector3(L, 3);
				DG.Tweening.TweenCallback arg3 = (DG.Tweening.TweenCallback)ToLua.CheckDelegate<DG.Tweening.TweenCallback>(L, 4);
				float arg4 = (float)LuaDLL.luaL_checknumber(L, 5);
				DG.Tweening.Tweener o = LuaExtend.doLocalMoveTo(arg0, arg1, arg2, arg3, arg4);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.doLocalMoveTo");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doFloatTo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4)
			{
				DG.Tweening.Core.DOSetter<float> arg0 = (DG.Tweening.Core.DOSetter<float>)ToLua.CheckDelegate<DG.Tweening.Core.DOSetter<float>>(L, 1);
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
				float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
				float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
				DG.Tweening.Tweener o = LuaExtend.doFloatTo(arg0, arg1, arg2, arg3);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 5)
			{
				DG.Tweening.Core.DOSetter<float> arg0 = (DG.Tweening.Core.DOSetter<float>)ToLua.CheckDelegate<DG.Tweening.Core.DOSetter<float>>(L, 1);
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
				float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
				float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
				DG.Tweening.TweenCallback arg4 = (DG.Tweening.TweenCallback)ToLua.CheckDelegate<DG.Tweening.TweenCallback>(L, 5);
				DG.Tweening.Tweener o = LuaExtend.doFloatTo(arg0, arg1, arg2, arg3, arg4);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.doFloatTo");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int killTweener(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
				LuaExtend.killTweener(arg0);
				return 0;
			}
			else if (count == 2)
			{
				DG.Tweening.Tweener arg0 = (DG.Tweening.Tweener)ToLua.CheckObject<DG.Tweening.Tweener>(L, 1);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 2);
				LuaExtend.killTweener(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.killTweener");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int lerpRotation(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			LuaExtend.lerpRotation(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setCameraObj(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			LuaExtend.setCameraObj(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setCameraPlayer(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
			LuaExtend.setCameraPlayer(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doShake(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 1);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 2);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg3 = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaExtend.doShake(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addSecHandler(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				System.Action<int> arg1 = (System.Action<int>)ToLua.CheckDelegate<System.Action<int>>(L, 2);
				long o = LuaExtend.addSecHandler(arg0, arg1);
				LuaDLL.tolua_pushint64(L, o);
				return 1;
			}
			else if (count == 3)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				System.Action<int> arg1 = (System.Action<int>)ToLua.CheckDelegate<System.Action<int>>(L, 2);
				System.Action<int> arg2 = (System.Action<int>)ToLua.CheckDelegate<System.Action<int>>(L, 3);
				long o = LuaExtend.addSecHandler(arg0, arg1, arg2);
				LuaDLL.tolua_pushint64(L, o);
				return 1;
			}
			else if (count == 4)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				System.Action<int> arg1 = (System.Action<int>)ToLua.CheckDelegate<System.Action<int>>(L, 2);
				System.Action<int> arg2 = (System.Action<int>)ToLua.CheckDelegate<System.Action<int>>(L, 3);
				int arg3 = (int)LuaDLL.luaL_checknumber(L, 4);
				long o = LuaExtend.addSecHandler(arg0, arg1, arg2, arg3);
				LuaDLL.tolua_pushint64(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaExtend.addSecHandler");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int playEffect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
			LuaExtend.playEffect(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int sendNetMsg(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			long arg0 = LuaDLL.tolua_checkint64(L, 1);
			short arg1 = (short)LuaDLL.luaL_checknumber(L, 2);
			byte[] arg2 = ToLua.CheckByteBuffer(L, 3);
			LuaExtend.sendNetMsg(arg0, arg1, arg2);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

