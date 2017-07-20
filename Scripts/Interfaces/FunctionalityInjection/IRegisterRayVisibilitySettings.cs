﻿#if UNITY_EDITOR
using System;
using UnityEngine;

namespace UnityEditor.Experimental.EditorVR
{
	public delegate void RegisterRayVisibilitySettingsDelegate<in T>(Transform rayOrigin, object caller, T settings);
	/// <summary>
	/// Implementors can show & hide the default ray
	/// </summary>
	public interface IRegisterRayVisibilitySettings<T> where T : struct
	{
	}

	public static class IRegisterRayVisibilitySettingsMethods<T>
	{
		public static RegisterRayVisibilitySettingsDelegate<T> registerRayVisibilitySettings;
	}

	public static class IRegisterRayVisibilitySettingsMethods
	{
		internal static Action<Transform, object> unregisterRayVisibilitySettings { get; set; }

		/// <summary>
		/// Register visibility settings to try and show/hide the ray/cone
		/// </summary>
		/// <param name="rayOrigin">The ray to hide or show</param>
		/// <param name="caller">The object which has locked the ray</param>
		/// <param name="rayVisible">Show or hide</param>
		/// <param name="coneVisible">An optional parameter to hide or show only the ray and not the cone</param>
		/// <param name="priority">The priority level of this request</param>
		public static void RegisterRayVisibilitySettings<T>(this IRegisterRayVisibilitySettings<T> customRay, Transform rayOrigin, object caller, T settings, int priority = 0) where T : struct
		{
			IRegisterRayVisibilitySettingsMethods<T>.registerRayVisibilitySettings(rayOrigin, caller, settings);
		}

		/// <summary>
		/// Unregister visibility settings
		/// </summary>
		/// <param name="rayOrigin">The ray to hide or show</param>
		/// <param name="caller">The object which has locked the ray</param>
		public static void UnregisterRayVisibilitySettings<T>(this IRegisterRayVisibilitySettings<T> customRay, Transform rayOrigin, object caller) where T : struct 
		{
			unregisterRayVisibilitySettings(rayOrigin, caller);
		}
	}
}
#endif
