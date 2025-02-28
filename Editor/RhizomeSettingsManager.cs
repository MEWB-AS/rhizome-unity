using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SettingsManagement;

namespace Rhizome.Unity.Editor
{
	static class RhizomeSettingsManager
	{
		internal const string k_PackageName = "no.mewb.rhizome.unity";

		static Settings s_Instance;

		internal static Settings instance => s_Instance ??= new Settings(k_PackageName);

		static ProjectUserSettings s_ProjectUserSettings;
		internal static ProjectUserSettings projectUserSettings => s_ProjectUserSettings ??= new ProjectUserSettings(k_PackageName);
	}
}
