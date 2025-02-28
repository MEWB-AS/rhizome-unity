using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SettingsManagement;
using UnityEngine;

namespace Rhizome.Unity.Editor
{
	public class RhizomeSettingsProvider
	{
		const string k_PreferencesPath = "Preferences/Rhizome";

		[SettingsProvider]
		static SettingsProvider CreateUserSettingsProvider()
		{
			var provider = new UserSettingsProvider(
				k_PreferencesPath,
				RhizomeSettingsManager.instance,
				new[] { typeof(RhizomeSettingsProvider).Assembly },
				SettingsScope.Project
			);
			return provider;
		}
	}
}
