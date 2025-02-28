using UnityEditor;
using UnityEditor.SettingsManagement;
using UnityEngine;
using Unity;
using System.Collections.Generic;
using System;

namespace Rhizome.Unity.Editor
{
	[Serializable]
	public class RhizomeAccountSettings
	{
		public string serverUrl = "";
		public string sessionToken = "";
	}

	public static class RhizomeAccountSettingsManager
	{
		static RhizomeAccountSettings s_Instance;
		public static RhizomeAccountSettings instance => s_Instance ??= Load();

		static RhizomeAccountSettings Load()
		{
			return RhizomeSettingsManager.projectUserSettings.Get<RhizomeAccountSettings>("account") ?? new RhizomeAccountSettings();
		}

		static void Save()
		{
			RhizomeSettingsManager.projectUserSettings.Set("account", instance);
			RhizomeSettingsManager.projectUserSettings.Save();
		}

		[UserSettingBlock("Account")]
		static void AccountSettingsGUI(string searchContext)
		{
			EditorGUI.BeginChangeCheck();

			instance.serverUrl = SettingsGUILayout.SearchableTextField("Server URL", instance.serverUrl, searchContext);
			instance.sessionToken = SettingsGUILayout.SearchableTextField("Session token", instance.sessionToken, searchContext);

			if (EditorGUI.EndChangeCheck())
			{
				Save();
			}
		}
	}
}
